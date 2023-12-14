using Microsoft.AspNetCore.Mvc;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Controllers
{
    [ApiController]
    [Route("colaborador/autentication")]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationRepository _autenticationRepository;

        public AutenticationController(IAutenticationRepository autenticationRepository)
        {
            _autenticationRepository = autenticationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarEmail(string email)
        {
            return Ok(await _autenticationRepository.ConsultarEmail(email));
        }

        [HttpGet]
        public async Task<IActionResult> AutenticarLogin(string senha)
        {
            return Ok(await _autenticationRepository.AutenticarLogin(senha));
        }
    }
}
