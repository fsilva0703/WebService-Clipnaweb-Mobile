using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Services
{
    public class RecursoAppService : IRecursoAppService
    {
        private const String _thisClassName = "RecursoAppService";
        private readonly IRecursoService _recursoService;

        public RecursoAppService(IRecursoService paramRecursoService)
        {
            _recursoService = paramRecursoService;
        }

        public ServiceResult<List<RecursoResult>> ListRecurso(RecursoListParameter paramObj)
        {
            return _recursoService.ListRecurso(paramObj);
        }

        public ServiceResult<Boolean> InsertRecurso(RecursoInsertParameter paramObj)
        {
            return _recursoService.InsertRecurso(paramObj);
        }

        public ServiceResult<Boolean> UpdateRecurso(RecursoUpdateParameter paramObj)
        {
            return _recursoService.UpdateRecurso(paramObj);
        }

        public ServiceResult<Boolean> DeleteRecurso(RecursoDeleteParameter paramObj)
        {
            return _recursoService.DeleteRecurso(paramObj);
        }

        public ServiceResult<List<TipoSolicitacaoResult>> ListTipoSolicitacao()
        {
            return _recursoService.ListTipoSolicitacao();
        }
    }
}
