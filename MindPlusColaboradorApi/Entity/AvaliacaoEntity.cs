namespace MindPlusColaboradorApi.Entity
{
    public class AvaliacaoEntity
    {
        public int? Id { get; set; }
        public int? resposta1 { get; set; }
        public int? resposta2 { get; set; }
        public int? resposta3 { get; set; }
        public int? resposta4 { get; set; }
        public int? resposta5 { get; set; }
        public int Colaborador_Id { get; set; }
    }
}