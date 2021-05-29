using System;
//using System.IndentityModelTokens.Jwt;
using System.Security.Claims;
using System.Text;
using Shop1.Models;
using Microsoft.IdentityModel.Tokens;


namespace Shop1.Services{

public static class Services{


    // public static string GenerateToken(User user){
    //     // linha 15 gera nosso token
    //     // var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(Settings.Secret);
    //     var tokenDescriptor = new SecurityTokenDescriptor
    //     {
    //         // usando o claims para pegar o id do usuario e tambem a profissao da model ser ali em cima
    //          Subject = new ClaimsIdentity(new Claim[]
    //          {
    //              new Claim (ClaimTypes.Name, user.Id.ToString()),
    //              new Claim (ClaimTypes.Role , user.Role.ToString())
    //          }),
    //          Expires = DateTime.UtcNow.AddHours(2),
    //          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            
    //     };
    //     //  var token = tokenHandler.CreateToken(tokenDescriptor);
         // gera string do meu token
    //     //  return tokenHandler.WriteToken(token);
    // }


}
    
}



