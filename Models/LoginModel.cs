using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using simo2api.Entities;
using simo2api.Extensions;
using simo2api.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Helpers;
using static simo2api.Helpers.HelperByQuery;

namespace simo2api.Models
{
    public class LoginModel
    {
        public string strQuery = "";

        public bool VerifyPassword(VerifyPass pass)
        {
            bool check = Crypto.VerifyHashedPassword(pass.Hass, pass.Password);
            return check;
        }

        public User Login(string username,string password)
        {
            strQuery = "select top 1 * from users.fn_GetUserLogin('@Username', '@Password')";
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@Username", username);
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@Password", password);
            User inquiryPeg = new HelperByQuery().getUser(strQuery);
            return inquiryPeg;
        }
        public User LoginNew(string username, string password) // New Login Verify hash password
        {
            User userLog = new User();
            strQuery = "select top 1 UserId,Password from users.fn_GetUserLoginAll() where Username = '@Username'";
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@Username", username);
            ExcQuery excQuery = new HelperByQuery().ExcecuteQuery(strQuery);
            if(excQuery.Inquiry.Rows.Count > 0)
            {
                FuncDataStopWatch funcData = new HelperByQuery().DtTableToJSON3(excQuery.Inquiry);
                GetPassword pass = JsonConvert.DeserializeObject<GetPassword>(funcData.Data.ToString());
                bool checkPass = VerifyPassword(new VerifyPass() { Hass = pass.Password, Password = password, UserID = pass.UserID });

                if (checkPass)
                {
                    userLog = GetUserInfo(pass.UserID);
                }
            }

            return userLog;
        }
        public User GetUserInfo(int Id)
        {
            strQuery = "select top 1 * from users.fn_GetUserLoginAll() where UserID = @UserID";
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@UserID", Id.ToString());
            User inquiryPeg = new HelperByQuery().getUser(strQuery);
            return inquiryPeg;
        }
        public User GetUserInfoByDistCb(int DistId,string ? KodeCb = null)
        {
            if (KodeCb == null)
            {
                strQuery = "select top 1 * from users.fn_GetUserLoginAll() where DistId = @DistId";
            }
            else
            {
                strQuery = "select top 1 * from users.fn_GetUserLoginAll() where DistId = @DistId and CbngId = '@KodeCb'";
                strQuery = new HelperByQuery().AddParameterString(strQuery, "@KodeCb", KodeCb);
            }
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@DistId", DistId.ToString());

            User inquiryPeg = new HelperByQuery().getUser(strQuery);
            return inquiryPeg;
        }
        public User GetUsername(int Id)
        {
            strQuery = "select top 1 * from users.fn_GetUserLoginAll() where UserID = @UserID";
            strQuery = new HelperByQuery().AddParameterString(strQuery, "@UserID", Id.ToString());
            User inquiryPeg = new HelperByQuery().getUser(strQuery);
            return inquiryPeg;
        }
        public void UpdateLastLogin(int Id, string LastLogin)
        {
            List<SpParam> spParams = new List<SpParam>();
            strQuery = "users.sp_UpdateLastLogin";
            spParams.Add(new SpParam().Add("@UserID", Id.ToString()));
            spParams.Add(new SpParam().Add("@LastLogin", LastLogin.ToString()));
            ExcQuery excQuery = new HelperByQuery().ExcecuteSPNew(strQuery,spParams);
        }

    }
}
