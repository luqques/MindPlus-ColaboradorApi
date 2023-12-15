using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.Contracts.Repository
{
    public interface IAuthenticationRepository
    {
        Task<ColaboradorEntity> AutenticarLogin(string email, string senha);
    }
}
