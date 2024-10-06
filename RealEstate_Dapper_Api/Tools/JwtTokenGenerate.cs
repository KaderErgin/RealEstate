using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerate
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))//kulliciya deger atamasi yapildiysa
                claims.Add(new Claim(ClaimTypes.Role,model.Role));//rol atamasi yap

            claims.Add(new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(model.UserName))
                claims.Add(new Claim("username",model.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)); //Token icin basvuru
            var signinCredantials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);//          kullanilacak yapi algoritma
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);                //          hayatta kalma suresi
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience:
                JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires:
                expireDate, signingCredentials: signinCredantials);
            JwtSecurityTokenHandler tokenHandler=new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token),expireDate);
        }
    }
}
