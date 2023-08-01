namespace ASP.NET.Netflix
{
    public class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public double Nota { get; set; }
        public string DescricaoAvaliacao { get; set; }
        public int MidiaId { get; set; }
        public string Usuario { get; set; }

        public Avaliacao(int idAvaliacao, double nota, string descricaoAvaliacao, int midiaId, string usuario)
        {
            this.IdAvaliacao = idAvaliacao;
            this.Nota = nota;
            this.DescricaoAvaliacao = descricaoAvaliacao;
            this.MidiaId = midiaId;
            this.Usuario = usuario;
        }
        public Avaliacao()
        {
            
        }
    }
}