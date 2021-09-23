using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System.Collections.Generic;

namespace AlterdataVotador.Application.Admin.Services
{
    public class MateriaAppService : IMateriaAppService
    {
        private readonly IMateriaService _materiaService;

        public MateriaAppService(IMateriaService paramMateriaService)
        {
            _materiaService = paramMateriaService;
        }

        public ServiceResult<List<MateriaResult>> ListMateria(MateriaParameter paramObj, string ClientId)
        {
            return _materiaService.ListMateria(paramObj, ClientId);
        }
    }
}