using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlterDataVotador.Controllers.Basic
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Basic/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService paramLoginAppService)
        {
            _loginAppService = paramLoginAppService;
        }

        /// <summary>
        /// Método utlizado para realizar a autenticação na API.
        /// </summary>
        /// <param name="LoginParameter">Utilizado para filtrar o resultado da consulta.</param>
        /// <returns>Retorna um objeto com os dados do usuário e o Token de autenticação.</returns>
        /// <response code="200" >Sucesso.</response>
        /// <response code="401">Token inválido.</response>
        /// <response code="415">Parâmetros com formato incorreto.</response>
        /// <response code="500">Erro inesperado do servidor, tente novamente mais tarde.</response>
        [HttpGet("Login")]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginParameter login)
        {
            try
            {
                var user = _loginAppService.Get(login.Login, login.Password).FirstOrDefault();

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                var token = _loginAppService.GenerateToken(user);
                user.Password = "";

                return new
                {
                    user = user,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}