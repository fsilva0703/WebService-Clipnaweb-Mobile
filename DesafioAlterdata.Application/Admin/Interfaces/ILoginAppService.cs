using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Interfaces
{
    public interface ILoginAppService
    {
        List<UserInfo> Get(String email, String senha);
        String GenerateToken(UserInfo user);
    }
}
