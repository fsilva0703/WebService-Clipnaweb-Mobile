using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using AlterDataVotador.Domain.ViewModel.Entity;
using DesafioAlterData.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAlterData.Controllers.Admin
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Admin/[controller]")]
    public class SetorController
    {
        private readonly ISetorAppService _SetorAppService;

        public SetorController(ISetorAppService paramSetorAppService)
        {
            _SetorAppService = paramSetorAppService;
        }

        /// <summary>
        /// Método utlizado para listar os setores.
        /// </summary>
        /// <param name="SetorParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna a lista de setores de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(SetorResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpGet, Route("ListSetor")]
        [Authorize]
        public IActionResult ListSetorByPost([FromBody] SetorListParameter SetorParameter)
        {
            ServiceResult<List<SetorResult>> result = _SetorAppService.ListSetor(SetorParameter);
            return AlterDataServiceResult<List<SetorResult>>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para cadastrar os setores.
        /// </summary>
        /// <param name="SetorParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(SetorResult), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(ResultErrorCode), 409)]
        [ProducesResponseType(typeof(ResultError), 415)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPost, Route("InsertSetor")]
        public IActionResult InsertSetorByPost([FromBody] SetorInsertParameter SetorParameter)
        {
            ServiceResult<Task<Setor>> result = _SetorAppService.InsertSetor(SetorParameter);
            return AlterDataServiceResult<Task<Setor>>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para atualizar os setores.
        /// </summary>
        /// <param name="SetorParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPut, Route("UpdateSetor")]
        public IActionResult UpdateSetorByPost([FromBody] SetorUpdateParameter SetorParameter)
        {
            ServiceResult<Boolean> result = _SetorAppService.UpdateSetor(SetorParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para deletar os setores.
        /// </summary>
        /// <param name="SetorParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpDelete, Route("DeleteSetor")]
        public IActionResult DeleteSetorByPost([FromBody] SetorDeleteParameter SetorParameter)
        {
            ServiceResult<Boolean> result = _SetorAppService.DeleteSetor(SetorParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }
    }
}