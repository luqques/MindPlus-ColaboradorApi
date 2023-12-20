using Dapper;
using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.DTO;
using MindPlusColaboradorApi.Entity;
using MindPlusColaboradorApi.Infrastructure;
using MinhaApiAula.Infrastructure;

namespace MindPlusColaboradorApi.Repository
{
    public class ColaboradorRepository : Connection, IColaboradorRepository
    {
        public async Task AtualizarColaborador(ColaboradorEntity colaborador)
        {
            string sql = @"
                    UPDATE COLABORADOR
                        SET Nome = @Nome,
                            Email = @Email,
                            Senha = @Senha,
                            Telefone = @Telefone,
                            Endereco = @Endereco,
                            Empresa = @Empresa,
                            Cargo = @Cargo
                            Role = @Role
                        WHERE Id = @Id
            ";
            await Execute(sql, colaborador);
        }

        public async Task CadastrarColaborador(ColaboradorDTO colaborador)
        {
            string sql = @"
                INSERT INTO COLABORADOR (Nome, Email, Senha, Telefone, Endereco, Empresa, Cargo, Role)
                            VALUE (@Nome, @Email, @Senha, @Telefone, @Endereco, @Empresa, @Cargo, @Role)
            ";
            await Execute(sql, colaborador);
        }

        public async Task RemoverColaborador(int id)
        {
            string sql = @"DELETE FROM COLABORADOR WHERE Id = @id";
            await Execute(sql, new { id });
        }

        public async Task<IEnumerable<ColaboradorEntity>> VisualizarColaboradores()
        {
            string sql = @"SELECT * FROM COLABORADOR";
            return await GetConnection().QueryAsync<ColaboradorEntity>(sql);
        }

        public async Task<ColaboradorTokenDTO> LogIn(LoginDto colaborador)
        {
            string sql = "SELECT * FROM colaborador WHERE Email = @Email AND Senha = @Senha";
            ColaboradorEntity colaboradorLogin = await GetConnection().QueryFirstAsync<ColaboradorEntity>(sql, colaborador);
            return new ColaboradorTokenDTO
            {
                Token = Authentication.GenerateToken(colaboradorLogin),
                Colaborador = colaboradorLogin
            };
        }
    }
}
