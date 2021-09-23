using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Services
{
    public class LoginAppService : ILoginAppService
    {
        private const String _thisClassName = "LoginAppService";
        private readonly ILoginService _loginService;

        public LoginAppService(ILoginService paramLoginService)
        {
            _loginService = paramLoginService;
        }

        public List<UserInfo> Get(string email, string senha)
        {
            return _loginService.Get(email, senha);
        }

        public String GenerateToken(UserInfo user)
        {
            return _loginService.GenerateToken(user);
        }
    }
}
