using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using simo2api.Entities;
using simo2api.Helpers;
using simo2api.Models;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using Prometheus;
using Sentry;
using simo2api.MetricsNamespace;
using User = simo2api.Entities.User;

namespace simo2api.Services
{

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { UserID = 36,  Username = "test", Password = "test" ,RoleID="0",Email = "test"}
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            //var user = new LoginModel().Login(model.Username, model.Password);
            var user = new LoginModel().LoginNew(model.Username, model.Password);
            
            // return null if user not found
            if (user.Username == null && user.Password ==null) return null;
            TokenInfo token = generateJwtToken(user);
            // authentication successful so generate jwt token
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            var user = new LoginModel().GetUserInfo(id);
            return user;
        }

        // helper methods
        private TokenInfo generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            TokenInfo tokenInfo = new TokenInfo();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserID", user.UserID.ToString()) }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenInfo.Token = tokenHandler.WriteToken(token);
            tokenInfo.DateCreate = DateTime.Now.ToString("dd-MMM-yyyy HH:m:ss");
            tokenInfo.DateExpired = DateTime.Now.AddHours(6).ToString("dd-MMM-yyyy HH:m:ss");
            tokenInfo.realPassword = Decrypt(user.Password);

            //update lastLogin
            new LoginModel().UpdateLastLogin(user.UserID, tokenInfo.DateCreate);

            return tokenInfo;
        }

        public static string Decrypt(string stringToDecrypt)
        {

            try
            {
                string base64Encoded = stringToDecrypt;
                string base64Decoded;
                byte[] data = System.Convert.FromBase64String(base64Encoded);
                base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                return base64Decoded;
            }
            catch (Exception e)
            {
                AppMetrics.DecryptErrorCounter.Inc();
                return e.Message;
                SentrySdk.CaptureException(e);
            }
        }
    }
}