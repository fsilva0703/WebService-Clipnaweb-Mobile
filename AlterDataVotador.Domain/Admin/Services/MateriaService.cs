using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository paramMateriaRepository)
        {
            _materiaRepository = paramMateriaRepository;
        }

        public ServiceResult<List<MateriaResult>> ListMateria(MateriaParameter paramObj, string ClientId)
        {
            ServiceResult<List<MateriaResult>> result = new ServiceResult<List<MateriaResult>>();
            result.Data = _materiaRepository.ListMateria(paramObj, ClientId);
            return result;
        }
    }
}