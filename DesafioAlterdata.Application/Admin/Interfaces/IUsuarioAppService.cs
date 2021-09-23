using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterdataVotador.Application.Admin.Interfaces
{
    public interface IUsuarioAppService
    {
        ServiceResult<List<UsuarioResult>> ListUsuario(UsuarioListParameter paramObj);
        ServiceResult<Boolean> InsertUsuario(UsuarioInsertParameter paramObj);
        ServiceResult<Boolean> UpdateUsuario(UsuarioUpdateParameter paramObj);
        ServiceResult<Boolean> DeleteUsuario(UsuarioDeleteParameter paramObj);
    }
}
