using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using DesafioAlterData.Util;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAlterData.Controllers.Admin
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Admin/[controller]")]
    public class RecursoController
    {
        private readonly IRecursoAppService _recursoAppService;

        public RecursoController(IRecursoAppService paramRecursoAppService)
        {
            _recursoAppService = paramRecursoAppService;
        }

        /// <summary>
        /// Método utlizado para listar os recursos.
        /// </summary>
        /// <param name="RecursoParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna a lista de recursos de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(RecursoResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpGet, Route("ListRecurso")]
        public IActionResult ListRecursoByPost([FromBody] RecursoListParameter RecursoParameter)
        {
            ServiceResult<List<RecursoResult>> result = _recursoAppService.ListRecurso(RecursoParameter);
            return AlterDataServiceResult<List<RecursoResult>>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para cadastrar os recursos.
        /// </summary>
        /// <param name="RecursoParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPost, Route("InsertRecurso")]
        public IActionResult InsertRecursoByPost([FromBody] RecursoInsertParameter RecursoParameter)
        {
            ServiceResult<Boolean> result = _recursoAppService.InsertRecurso(RecursoParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para atualizar os recursos.
        /// </summary>
        /// <param name="RecursoParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPut, Route("UpdateRecurso")]
        public IActionResult UpdateRecursoByPost([FromBody] RecursoUpdateParameter RecursoParameter)
        {
            ServiceResult<Boolean> result = _recursoAppService.UpdateRecurso(RecursoParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para deletar os recursos.
        /// </summary>
        /// <param name="RecursoParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpDelete, Route("DeleteRecurso")]
        public IActionResult DeleteRecursoByPost([FromBody] RecursoDeleteParameter RecursoParameter)
        {
            ServiceResult<Boolean> result = _recursoAppService.DeleteRecurso(RecursoParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para listar os tipos de solicitação.
        /// </summary>
        /// <returns>Retorna a lista de tipos de solicitação de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(TipoSolicitacaoResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpGet, Route("ListTipoSolicitacao")]
        public IActionResult ListTipoByPost()
        {
            ServiceResult<List<TipoSolicitacaoResult>> result = _recursoAppService.ListTipoSolicitacao();
            return AlterDataServiceResult<List<TipoSolicitacaoResult>>.ExecuteResult(result);
        }
    }
}