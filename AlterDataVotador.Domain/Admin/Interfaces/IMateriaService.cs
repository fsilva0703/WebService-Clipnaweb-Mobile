using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System.Collections.Generic;

namespace AlterDataVotador.Domain.Admin.Interfaces
{
    public interface IMateriaService
    {
        ServiceResult<List<MateriaResult>> ListMateria(MateriaParameter paramObj, string ClientId);
    }
}