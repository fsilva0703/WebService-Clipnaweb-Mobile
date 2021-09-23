using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using DesafioAlterData.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlterDataVotador.Controllers.Admin
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Admin/[controller]")]
    public class MateriaController : Controller
    {
        private readonly IMateriaAppService _materiaAppService;

        public MateriaController(IMateriaAppService paramMateriaAppService)
        {
            _materiaAppService = paramMateriaAppService;
        }

        /// <summary>
        /// Método utlizado para listar as matérias.
        /// </summary>
        /// <param name="MateriaParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna a lista de matérias de acordo com os filtros informados.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [ProducesResponseType(typeof(MateriaResult[]), 200)]
        [ApiExplorerSettings(GroupName = "admin", IgnoreApi = false)]
        [HttpGet, Route("ListMaterias")]
        [Authorize]
        public IActionResult ListUsuarioByPost([FromBody] MateriaParameter MateriaParameter)
        {
            Request.Headers.TryGetValue("ClientId", out var clientId);

            ServiceResult<List<MateriaResult>> result = _materiaAppService.ListMateria(MateriaParameter, clientId);
            return AlterDataServiceResult<List<MateriaResult>>.ExecuteResult(result);
        }
    }
}