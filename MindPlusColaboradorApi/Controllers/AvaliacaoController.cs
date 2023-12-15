using Microsoft.AspNetCore.Mvc;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;
using MindPlusColaboradorApi.Repository;

namespace MindPlusColaboradorApi.Controllers
{
    [ApiController]
    [Route("avaliacao")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarAvaliacao(AvaliacaoDTO avaliacao)
        {
            await _avaliacaoRepository.RealizarAvaliacao(avaliacao);
            return Ok("Avaliação realizada com sucesso.");
        }

        [HttpGet]
        public async Task<IActionResult> VisualizarAvaliacao()
        {
            return Ok(await _avaliacaoRepository.VisualizarAvaliacoes());
        }
    }
}
