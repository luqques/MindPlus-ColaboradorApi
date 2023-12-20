using MindPlusColaboradorApi.Entity;

namespace MindPlusColaboradorApi.DTO
{
    public class ColaboradorTokenDTO
    {
        public string Token { get; set; }
        public ColaboradorEntity Colaborador { get; set; }
    }
}
