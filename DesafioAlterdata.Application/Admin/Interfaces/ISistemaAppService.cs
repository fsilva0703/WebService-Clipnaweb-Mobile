using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Interfaces
{
    public interface ISistemaAppService
    {
        ServiceResult<List<SistemaResult>> ListSistema(SistemaListParameter paramObj);
        ServiceResult<Boolean> InsertSistema(SistemaInsertParameter paramObj);
        ServiceResult<Boolean> UpdateSistema(SistemaUpdateParameter paramObj);
        ServiceResult<Boolean> DeleteSistema(SistemaDeleteParameter paramObj);
    }
}
