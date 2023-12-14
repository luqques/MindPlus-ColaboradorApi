using Dapper;
using Microsoft.VisualBasic;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.Entity;
using MinhaApiAula.Infrastructure;

namespace MindPlusColaboradorApi.Repository
{
    public class AutenticationRepository : Connection, IAutenticationRepository
    {
        public async Task<ColaboradorEntity> ConsultarEmail(string email)
        {
            string sql = "SELECT * FROM COLABORADOR WHERE Email like @email;";
            return await GetConnection().QueryFirstAsync<ColaboradorEntity>(sql, new { email });
        }

        public async Task<ColaboradorEntity> AutenticarLogin(string senha)
        {
            string sql = "SELECT * FROM COLABORADOR WHERE Email like @senha;";
            return await GetConnection().QueryFirstAsync<ColaboradorEntity>(sql, new { senha });
        }
    }
}
