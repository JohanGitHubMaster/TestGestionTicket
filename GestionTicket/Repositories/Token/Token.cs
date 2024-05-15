using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GestionTicket.Repositories.Token
{
   public class Token
   {
      public string GenerateTokenAsync()
      {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsjZBjXWRgJMFPU4"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: null,
                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: cred
                    );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;       
      }
   }
}
