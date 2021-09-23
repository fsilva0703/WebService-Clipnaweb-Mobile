using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface ISistemaRepository
    {
        List<SistemaResult> ListSistema(SistemaListParameter paramObj);
        Boolean InsertSistema(SistemaInsertParameter paramObj);
        Boolean UpdateSistema(SistemaUpdateParameter paramObj);
        Boolean DeleteSistema(SistemaDeleteParameter paramObj);
    }
}
