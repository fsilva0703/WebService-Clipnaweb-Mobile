using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface IRecursoRepository
    {
        List<RecursoResult> ListRecurso(RecursoListParameter paramObj);
        Boolean InsertRecurso(RecursoInsertParameter paramObj);
        Boolean UpdateRecurso(RecursoUpdateParameter paramObj);
        Boolean DeleteRecurso(RecursoDeleteParameter paramObj);
        List<TipoSolicitacaoResult> ListTipoSolicitacao();
    }
}
