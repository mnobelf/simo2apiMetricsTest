using simo2api.Entities;

namespace simo2api.Models
{
    public class AuthenticateResponse
    {
        public int UserID { get; set; }
        public string ? Username { get; set; }
        public string ? RoleID { get; set; }
        public string ? Nama { get; set; }
        public string ? Email { get; set; }
        public string ? RoleName { get; set; }
        public string ? Prov_Nama { get; set; }
        public string ? ProviderKD { get; set; }
        public string ? ProviderID { get; set; }
        public string? KodeKpm { get; set; }
        
        public string ? Dist_Nama { get; set; }
        public string ? Dist_Email { get; set; }
        public string ? Cbng_Nama { get; set; }
        public string? DistID { get; set; }
        public string? CbngId { get; set; }
        public string? Kpm_Nama { get; set; }


        public string ? Token { get; set; }
        public string? DateCreate { get; set; }
        public string? DateExpired{ get; set; }
        public string? RealPassword { get; set; }



        public AuthenticateResponse(User user,TokenInfo token)
        {
            UserID = user.UserID;
            Prov_Nama = user.Prov_Nama;
            Username = user.Username;
            Nama = user.Nama;
            RoleName = user.RoleName;
            Email = user.Email;
            ProviderKD = user.ProviderKD;
            ProviderID = user.ProviderID;
            RoleID = user.RoleID;
            RoleID = user.RoleID;
            Dist_Nama = user.Dist_Nama;
            Dist_Email = user.Dist_Email;
            DistID= user.DistID;
            Cbng_Nama = user.Cbng_Nama;
            CbngId = user.CbngID;
            KodeKpm = user.KodeKpm;
            Token = token.Token;
            DateCreate = token.DateCreate;
            DateExpired = token.DateExpired;
            RealPassword = token.realPassword;
            Kpm_Nama = user.Kpm_Nama;
        }
    }
}