using Dapper;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;
using MinhaApiAula.Infrastructure;

namespace MindPlusColaboradorApi.Repository
{
    public class AvaliacaoRepository : Connection, IAvaliacaoRepository
    {
        public async Task RealizarAvaliacao(AvaliacaoDTO avaliacao)
        {
            string sql = @"
                INSERT INTO AVALIACAO (resposta1, resposta2, resposta3, resposta4, resposta5, Colaborador_Id)
                    VALUE (@resposta1, @resposta2, @resposta3, @resposta4, @resposta5, @Colaborador_Id)
            ";
            await Execute(sql, avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoEntity>> VisualizarAvaliacoes()
        {
            string sql = @"SELECT * FROM AVALIACAO";
            return await GetConnection().QueryAsync<AvaliacaoEntity>(sql);
        }
    }
}
