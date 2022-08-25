using System.Text.Json.Serialization;

namespace simo2api.Entities
{

    public class TokenInfo
    {
        public string? Token { get; set; }
        public string?DateCreate { get; set; }
        public string? DateExpired { get; set; }
        public string ? realPassword { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string ? Username { get; set; }
        public string ? Nama { get; set; }
        public string ? RoleName { get; set; }
        public string ? ProviderKD { get; set; }
        public string ? Prov_Nama { get; set; }

        public string ? RoleID { get; set; }
        public string ? Email { get; set; }
        public string ? ProviderID { get; set; }
        public string? KodeKpm { get; set; }

        public string ? Dist_Nama { get; set; }
        public string ? Dist_Email { get; set; }
        public string ? Cbng_Nama { get; set; }

        public string? DistID { get; set; }
        public string? CbngID{ get; set; }
        public string? Kpm_Nama { get; set; }


        [JsonIgnore]
        public string ? Password { get; set; }
    }
    public class GetPassword
    {
        public int UserID { get; set; }
        public string? Password { get; set; }

    }
}