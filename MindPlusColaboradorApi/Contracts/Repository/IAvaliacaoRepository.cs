using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Contracts.Repository
{
    public interface IAvaliacaoRepository
    {
        Task RealizarAvaliacao(AvaliacaoDTO avaliacao);
        Task<IEnumerable<AvaliacaoEntity>> VisualizarAvaliacoes();
    }
}
