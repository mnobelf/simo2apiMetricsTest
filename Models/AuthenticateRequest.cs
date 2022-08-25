using System.ComponentModel.DataAnnotations;

namespace simo2api.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class VerifyPass
    {
        [Required]
        public int  UserID { get; set; }
        [Required]
        public string ? Hass { get; set; }

        [Required]
        public string ? Password { get; set; }
    }
}