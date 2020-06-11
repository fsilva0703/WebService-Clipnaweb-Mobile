using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WS.Models;
using WS.Models.Dto;
using WS.Models.Repositories;


namespace WS.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("admin/[controller]")]
    public class LoginController : Controller
    {
        private ILoginRepository _LoginRepository;

        public LoginController(ILoginRepository _loginRepository)
        {
            _LoginRepository = _loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loginList = await _LoginRepository.GetAll();
            return Ok(loginList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _LoginRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost, Route("GetLogin")]
        public async Task<IActionResult> GetLoginByProc([FromBody] LoginDto dadosLogin)
        {
            var item = await _LoginRepository.FindLoginByProc(dadosLogin.login, dadosLogin.senha);
            if (item == null)
            {
                return BadRequest("Login ou senha são inválidos");
            }
            return Ok(item);
        }

        [HttpPost, Route("GetMidias")]
        public async Task<IActionResult> GetMidiasPermitidasByProc([FromBody] LoginDto dadosLogin)
        {
            var item = await _LoginRepository.FindMidiasPermitidasByProc(dadosLogin.login, dadosLogin.senha);
            if (item == null)
            {
                return BadRequest("Erro ao retornar as mídias");
            }
            return Ok(item);
        }

        [HttpPost, Route("GetAssuntos")]
        public async Task<IActionResult> GetAssuntosByProc([FromBody] String NomeBanco)
        {
            var item = await _LoginRepository.FindAssuntosByProc(NomeBanco);
            if (item == null)
            {
                return BadRequest("Erro ao retornar os assuntos");
            }
            return Ok(item);
        }

        [HttpPost, Route("GetMaterias")]
        public async Task<IActionResult> GetMateriasByProc([FromBody] DtoFiltro filtro)
        {
            var item = await _LoginRepository.FindMateriasByProc(filtro);
            if (item == null)
            {
                return BadRequest("Erro ao retornar os assuntos");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario item)
        {
            if (item == null)
            {
                return BadRequest("Usuário ou senha são inválidos.");
            }
            await _LoginRepository.Add(item);
            return CreatedAtRoute("GetLogin", new { Controller = "Login", id = item.Login }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = await _LoginRepository.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            await _LoginRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _LoginRepository.Remove(id);
            return NoContent();
        }
    }
}