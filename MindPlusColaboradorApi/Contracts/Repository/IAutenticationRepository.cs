using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Contracts.Repository
{
    public interface IAutenticationRepository
    {
        Task<ColaboradorEntity> ConsultarEmail(string email);
        Task<ColaboradorEntity> AutenticarLogin(string senha);
    }
}
