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
    public class SistemaController
    {
        private readonly ISistemaAppService _sistemaAppService;

        public SistemaController(ISistemaAppService paramSistemaAppService)
        {
            _sistemaAppService = paramSistemaAppService;
        }

        /// <summary>
        /// Método utlizado para listar os sistemas.
        /// </summary>
        /// <param name="SistemaParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna a lista de sistemas de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(SistemaResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpGet, Route("ListSistema")]
        public IActionResult ListSistemaByPost([FromBody] SistemaListParameter SistemaParameter)
        {
            ServiceResult<List<SistemaResult>> result = _sistemaAppService.ListSistema(SistemaParameter);
            return AlterDataServiceResult<List<SistemaResult>>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para cadastrar os sistemas.
        /// </summary>
        /// <param name="SistemaParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPost, Route("InsertSistema")]
        public IActionResult InsertSistemaByPost([FromBody] SistemaInsertParameter SistemaParameter)
        {
            ServiceResult<Boolean> result = _sistemaAppService.InsertSistema(SistemaParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para atualizar os sistemas.
        /// </summary>
        /// <param name="SistemaParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpPut, Route("UpdateSistema")]
        public IActionResult UpdateSistemaByPost([FromBody] SistemaUpdateParameter SistemaParameter)
        {
            ServiceResult<Boolean> result = _sistemaAppService.UpdateSistema(SistemaParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }

        /// <summary>
        /// Método utlizado para deletar os sistemas.
        /// </summary>
        /// <param name="SistemaParameter">Utilizado para filtrar parametrizar .</param>
        /// <returns>Retorna True quando a operação é realizada com sucesso.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = true)]
        [HttpDelete, Route("DeleteSistema")]
        public IActionResult DeleteSistemaByPost([FromBody] SistemaDeleteParameter SistemaParameter)
        {
            ServiceResult<Boolean> result = _sistemaAppService.DeleteSistema(SistemaParameter);
            return AlterDataServiceResult<Boolean>.ExecuteResult(result);
        }
    }
}