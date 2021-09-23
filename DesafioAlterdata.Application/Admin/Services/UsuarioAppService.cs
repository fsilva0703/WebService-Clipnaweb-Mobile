using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;

namespace AlterdataVotador.Application.Admin.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private const String _thisClassName = "UsuarioAppService";
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService paramUsuarioService)
        {
            _usuarioService = paramUsuarioService;
        }

        public ServiceResult<List<UsuarioResult>> ListUsuario(UsuarioListParameter paramObj)
        {
            return _usuarioService.ListUsuario(paramObj);
        }

        public ServiceResult<Boolean> InsertUsuario(UsuarioInsertParameter paramObj)
        {
            return _usuarioService.InsertUsuario(paramObj);
        }

        public ServiceResult<Boolean> UpdateUsuario(UsuarioUpdateParameter paramObj)
        {
            return _usuarioService.UpdateUsuario(paramObj);
        }

        public ServiceResult<Boolean> DeleteUsuario(UsuarioDeleteParameter paramObj)
        {
            return _usuarioService.DeleteUsuario(paramObj);
        }
    }
}
