using System;
using System.Collections.Generic;
using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using DesafioAlterData.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAlterData.Controllers.Admin
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Admin/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService paramUsuarioAppService)
        {
            _usuarioAppService = paramUsuarioAppService;
        }

        /// <summary>
        /// Método utlizado para listar os usuários.
        /// </summary>
        /// <param name="UsuarioParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna a lista de usuários de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(UsuarioResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpGet, Route("ListUsuario")]
        public IActionResult ListUsuarioByPost([FromBody] UsuarioListParameter UsuarioParameter)
        {
            ServiceResult<List<UsuarioResult>> result = _usuarioAppService.ListUsuario(UsuarioParameter);
            return AlterDataServiceResult<List<UsuarioResult>>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para cadastrar os usuários.
        /// </summary>
        /// <param name="UsuarioParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPost, Route("InsertUsuario")]
        [Authorize]
        public IActionResult InsertUsuarioByPost([FromBody] UsuarioInsertParameter UsuarioParameter)
        {
            ServiceResult<Boolean> result = _usuarioAppService.InsertUsuario(UsuarioParameter);
            if (!result.Data)
                return BadRequest(new { message = "Cadastro não realizado. Verifique se este e-mail já está cadastrado." });
            else
                return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para atualizar os usuários.
        /// </summary>
        /// <param name="UsuarioParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPut, Route("UpdateUsuario")]
        public IActionResult UpdateUsuarioByPost([FromBody] UsuarioUpdateParameter UsuarioParameter)
        {
            ServiceResult<Boolean> result = _usuarioAppService.UpdateUsuario(UsuarioParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para deletar os usuários.
        /// </summary>
        /// <param name="UsuarioParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpDelete, Route("DeleteUsuario")]
        [Authorize(Roles = "Diretoria")]
        public IActionResult DeleteUsuarioByPost([FromBody] UsuarioDeleteParameter UsuarioParameter)
        {
            ServiceResult<Boolean> result = _usuarioAppService.DeleteUsuario(UsuarioParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }
    }
}