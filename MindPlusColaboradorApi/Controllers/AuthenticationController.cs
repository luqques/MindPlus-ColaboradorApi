using Microsoft.AspNetCore.Mvc;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Controllers
{
    [ApiController]
    [Route("colaborador/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AutenticarLogin([FromBody] LoginRequestDto loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            ColaboradorEntity colaboradorLogado = await _authenticationRepository.AutenticarLogin(loginRequest.Email, loginRequest.Senha);

            if (colaboradorLogado.Senha == loginRequest.Senha)
            {
                return Ok("Usuário autenticado com sucesso.");
            }
            else
            {
                return Unauthorized("Credenciais inválidas.");
            }
        }
    }
}