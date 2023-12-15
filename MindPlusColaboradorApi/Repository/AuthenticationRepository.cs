using Dapper;
using Microsoft.VisualBasic;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;
using MinhaApiAula.Infrastructure;

namespace MindPlusColaboradorApi.Repository
{
    public class AuthenticationRepository : Connection, IAuthenticationRepository
    {
        public async Task<ColaboradorEntity> AutenticarLogin(string email, string senha)
        {
            string sql = "SELECT * FROM COLABORADOR WHERE Email = @email AND Senha = @senha;";

            return await GetConnection().QueryFirstAsync<ColaboradorEntity>(sql, new { Email = email, Senha = senha });
        }
    }
}
