using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Common;
using AlterDataVotador.Domain.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository paramUsuarioRepository)
        {
            _usuarioRepository = paramUsuarioRepository;
        }

        public ServiceResult<List<UsuarioResult>> ListUsuario(UsuarioListParameter paramObj)
        {
            ServiceResult<List<UsuarioResult>> result = new ServiceResult<List<UsuarioResult>>();
            result.Data = _usuarioRepository.ListUsuario(paramObj);
            return result;
        }

        public ServiceResult<Boolean> InsertUsuario(UsuarioInsertParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();

            paramObj.Senha = Cryptography.HashPassword(paramObj.Senha);

            result.Data = _usuarioRepository.InsertUsuario(paramObj);            return result;
        }

        public ServiceResult<Boolean> UpdateUsuario(UsuarioUpdateParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();

            paramObj.Senha = Cryptography.HashPassword(paramObj.Senha);

            result.Data = _usuarioRepository.UpdateUsuario(paramObj);
            return result;
        }

        public ServiceResult<Boolean> DeleteUsuario(UsuarioDeleteParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _usuarioRepository.DeleteUsuario(paramObj);
            return result;
        }
    }
}
