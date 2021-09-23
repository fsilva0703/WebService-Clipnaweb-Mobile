using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System.Collections.Generic;

namespace AlterdataVotador.Application.Admin.Interfaces
{
    public interface IMateriaAppService
    {
        ServiceResult<List<MateriaResult>> ListMateria(MateriaParameter paramObj, string ClientId);
    }
}