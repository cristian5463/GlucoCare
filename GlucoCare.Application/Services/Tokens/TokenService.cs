using GlucoCare.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GlucoCare.Application.Services.Tokens;

public class TokenService
{
    public string GenerateToken(UserEntity userEntity)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("id", userEntity.UserId.ToString()),
            new Claim("email", userEntity.Email),
            new Claim("name", userEntity.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SADHA87DAH1DSAH873HD7912GEAD712GA"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}