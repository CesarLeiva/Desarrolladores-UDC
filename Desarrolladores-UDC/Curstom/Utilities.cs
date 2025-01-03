﻿using System.Runtime.Intrinsics.Arm;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DB;

namespace Desarrolladores_UDC.Curstom
{
    public class Utilities
    {
        private readonly IConfiguration _configuration;
        public Utilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string encripterSHA256(string input)
        {
            using(SHA256 sha256Hash = SHA256.Create())
            {
                //Computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                //bytes to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string generateJWT(User user)
        {
            //Crear la información del usuario para el token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
