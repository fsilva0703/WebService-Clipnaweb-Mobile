using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces
{
    public interface IRecursoService
    {
        ServiceResult<List<RecursoResult>> ListRecurso(RecursoListParameter paramObj);
        ServiceResult<Boolean> InsertRecurso(RecursoInsertParameter paramObj);
        ServiceResult<Boolean> UpdateRecurso(RecursoUpdateParameter paramObj);
        ServiceResult<Boolean> DeleteRecurso(RecursoDeleteParameter paramObj);
        ServiceResult<List<TipoSolicitacaoResult>> ListTipoSolicitacao();
    }
}
