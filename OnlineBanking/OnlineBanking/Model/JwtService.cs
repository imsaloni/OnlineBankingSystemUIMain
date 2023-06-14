using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Model
{
    public class JwtService
    {
        public String SecretKey { get; set; }
        public int TokenDuration { get; set; }
        private readonly IConfiguration config;
        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);

        }

        public String GenerateToken(String id, String FullName,String MobileNumber,String Email,String
            AadharNumber,String DateOfBirth,String Address,String Occupation ,String AnnualIncome)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));

            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("id",id),
                new Claim("FullName",FullName),
                new Claim("MobileNumber",MobileNumber),
                new Claim("Email",Email),
                new Claim("AadharNumber",AadharNumber),
                new Claim("DateOfBirth", DateOfBirth),
                new Claim("Address",Address),
                new Claim("Occupation",Occupation),
                new Claim("AnnualIncome",AnnualIncome),
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

          
        }
    }
}
