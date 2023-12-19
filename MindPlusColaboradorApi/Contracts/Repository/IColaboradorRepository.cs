using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Contracts.Repository
{
    public interface IColaboradorRepository
    {
        Task CadastrarColaborador(ColaboradorDTO colaborador);
        Task AtualizarColaborador(ColaboradorEntity colaborador);
        Task RemoverColaborador(int id);
        Task<IEnumerable<ColaboradorEntity>> VisualizarColaboradores();
        Task<ColaboradorTokenDTO> LogIn(LoginDto colaborador);
    }
}