using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public Profile Profile { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]//Permite que se pueda usar como string y como int
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