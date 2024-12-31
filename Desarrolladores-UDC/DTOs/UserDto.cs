using DB;
using System.ComponentModel.DataAnnotations;

namespace Desarrolladores_UDC.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public UserRole Role { get; set; }
        public bool Verified { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
