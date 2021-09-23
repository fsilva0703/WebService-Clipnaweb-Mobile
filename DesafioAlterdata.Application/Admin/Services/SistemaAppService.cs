using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Services
{
    public class SistemaAppService : ISistemaAppService
    {
        private const String _thisClassName = "SistemaAppService";
        private readonly ISistemaService _sistemaService;

        public SistemaAppService(ISistemaService paramSistemaService)
        {
            _sistemaService = paramSistemaService;
        }

        public ServiceResult<List<SistemaResult>> ListSistema(SistemaListParameter paramObj)
        {
            return _sistemaService.ListSistema(paramObj);
        }

        public ServiceResult<Boolean> InsertSistema(SistemaInsertParameter paramObj)
        {
            return _sistemaService.InsertSistema(paramObj);
        }

        public ServiceResult<Boolean> UpdateSistema(SistemaUpdateParameter paramObj)
        {
            return _sistemaService.UpdateSistema(paramObj);
        }

        public ServiceResult<Boolean> DeleteSistema(SistemaDeleteParameter paramObj)
        {
            return _sistemaService.DeleteSistema(paramObj);
        }
    }
}
