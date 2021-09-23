using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AlterDataVotador.Domain.ViewModel.Dto;
using AlterDataVotador.Domain.Security;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel.Common;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _loginRepository;

        public LoginService(ILoginRepository paramLoginRepository)
        {
            _loginRepository = paramLoginRepository;
        }

        public String GenerateToken(UserInfo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, user.Cliente.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public List<UserInfo> Get(String email, String senha)
        {
            //senha = Cryptography.HashPassword(senha);
            return _loginRepository.Get(email, senha);
        }
    }
}