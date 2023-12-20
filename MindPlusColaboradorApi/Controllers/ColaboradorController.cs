using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;
using Org.BouncyCastle.Utilities;

namespace MindPlusColaboradorApi.Controllers
{
    [ApiController]
    [Route("colaborador")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> VisualizarColaboradores()
        {
            return Ok(await _colaboradorRepository.VisualizarColaboradores());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CadastrarColaborador(ColaboradorDTO colaborador)
        {
            await _colaboradorRepository.CadastrarColaborador(colaborador);
            return Ok("Colaborador cadastrado com sucesso.");
        }
        
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AtualizarColaborador(ColaboradorEntity colaborador)
        {
            await _colaboradorRepository.AtualizarColaborador(colaborador);
            return Ok("Colaborador atualizado com sucesso.");
        }
        
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoverColaborador(int id)
        {
            await _colaboradorRepository.RemoverColaborador(id);
            return Ok("Colaborador removido com sucesso.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(LoginDto colaborador)
        {
            try
            {
                return Ok(await _colaboradorRepository.LogIn(colaborador));
            }
            catch (Exception ex)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }
        }
    }
}
