using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        List<UsuarioResult> ListUsuario(UsuarioListParameter paramObj);
        Boolean InsertUsuario(UsuarioInsertParameter paramObj);
        Boolean UpdateUsuario(UsuarioUpdateParameter paramObj);
        Boolean DeleteUsuario(UsuarioDeleteParameter paramObj);
    }
}
