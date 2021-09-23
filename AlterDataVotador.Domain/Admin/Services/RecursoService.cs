using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class RecursoService : IRecursoService
    {
        private IRecursoRepository _recursoRepository;

        public RecursoService(IRecursoRepository paramRecursoRepository)
        {
            _recursoRepository = paramRecursoRepository;
        }

        public ServiceResult<List<RecursoResult>> ListRecurso(RecursoListParameter paramObj)
        {
            ServiceResult<List<RecursoResult>> result = new ServiceResult<List<RecursoResult>>();
            result.Data = _recursoRepository.ListRecurso(paramObj);
            return result;
        }
      

        public ServiceResult<Boolean> InsertRecurso(RecursoInsertParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _recursoRepository.InsertRecurso(paramObj);
            return result;
        }

        public ServiceResult<Boolean> UpdateRecurso(RecursoUpdateParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _recursoRepository.UpdateRecurso(paramObj);
            return result;
        }

        public ServiceResult<Boolean> DeleteRecurso(RecursoDeleteParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _recursoRepository.DeleteRecurso(paramObj);
            return result;
        }

        public ServiceResult<List<TipoSolicitacaoResult>> ListTipoSolicitacao()
        {
            ServiceResult<List<TipoSolicitacaoResult>> result = new ServiceResult<List<TipoSolicitacaoResult>>();
            result.Data = _recursoRepository.ListTipoSolicitacao();
            return result;
        }
    }
}
