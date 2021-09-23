using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class SistemaService : ISistemaService
    {
        private ISistemaRepository _sistemaRepository;

        public SistemaService(ISistemaRepository paramSistemaRepository)
        {
            _sistemaRepository = paramSistemaRepository;
        }

        public ServiceResult<List<SistemaResult>> ListSistema(SistemaListParameter paramObj)
        {
            ServiceResult<List<SistemaResult>> result = new ServiceResult<List<SistemaResult>>();
            result.Data = _sistemaRepository.ListSistema(paramObj);
            return result;
        }

        public ServiceResult<Boolean> InsertSistema(SistemaInsertParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _sistemaRepository.InsertSistema(paramObj);
            return result;
        }

        public ServiceResult<Boolean> UpdateSistema(SistemaUpdateParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _sistemaRepository.UpdateSistema(paramObj);
            return result;
        }

        public ServiceResult<Boolean> DeleteSistema(SistemaDeleteParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _sistemaRepository.DeleteSistema(paramObj);
            return result;
        }
    }
}
