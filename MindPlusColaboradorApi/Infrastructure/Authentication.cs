﻿using Microsoft.IdentityModel.Tokens;
using MindPlusColaboradorApi.Entity;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MindPlusColaboradorApi.Infrastructure
{
    public class Authentication
    {
        public static string GenerateToken(ColaboradorEntity colaborador)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, colaborador.Nome),
                    new Claim(ClaimTypes.Email, colaborador.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
