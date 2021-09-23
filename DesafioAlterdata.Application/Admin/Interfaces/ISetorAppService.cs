using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using AlterDataVotador.Domain.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterdataVotador.Application.Admin.Interfaces
{
    public interface ISetorAppService
    {
        ServiceResult<List<SetorResult>> ListSetor(SetorListParameter paramObj);
        ServiceResult<Task<Setor>> InsertSetor(SetorInsertParameter paramObj);
        ServiceResult<Boolean> UpdateSetor(SetorUpdateParameter paramObj);
        ServiceResult<Boolean> DeleteSetor(SetorDeleteParameter paramObj);
    }
}
