using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface ISetorRepository
    {
        List<SetorResult> ListSetor(SetorListParameter paramObj);
        Task<Setor> InsertSetor(SetorInsertParameter paramObj);
        Boolean UpdateSetor(SetorUpdateParameter paramObj);
        Boolean DeleteSetor(SetorDeleteParameter paramObj);
    }
}
