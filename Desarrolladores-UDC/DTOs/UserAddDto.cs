﻿using DB;

namespace Desarrolladores_UDC.DTOs
{
    public class UserAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
