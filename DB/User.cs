using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }
        public bool Verified { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}

public enum UserRole
{
    Estudiante,
    Profesor,
    Egresado,
    Externo,
    Admin
}