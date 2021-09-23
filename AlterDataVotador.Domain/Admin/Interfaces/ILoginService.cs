using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces
{
    public interface ILoginService
    {
        List<UserInfo> Get(String email, String senha);
        String GenerateToken(UserInfo user);
    }
}
