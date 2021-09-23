using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces
{
    public interface ISistemaService
    {
        ServiceResult<List<SistemaResult>> ListSistema(SistemaListParameter paramObj);
        ServiceResult<Boolean> InsertSistema(SistemaInsertParameter paramObj);
        ServiceResult<Boolean> UpdateSistema(SistemaUpdateParameter paramObj);
        ServiceResult<Boolean> DeleteSistema(SistemaDeleteParameter paramObj);
    }
}
