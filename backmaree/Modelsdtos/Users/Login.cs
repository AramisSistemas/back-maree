using System.ComponentModel.DataAnnotations;

namespace backmaree.Modelsdtos.Users
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}