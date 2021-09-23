using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        List<UserInfo> Get(String email, String senha);
    }
}
