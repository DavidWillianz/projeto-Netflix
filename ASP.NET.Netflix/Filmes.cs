using System.Collections.Generic;
using System.Linq;

namespace ASP.NET.Netflix
{
    public class Filmes
    {
        public int IdFilme { get; set; }
        public string TituloFilme { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public bool Ativo { get; set; }
        public Genero GeneroFilme { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
        public string Resumo { get { return GetResumo(); } }
        public double CalcularMedia { get { return CalcularMediaNota(); } }

        public Filmes(int idfilme, string titulofilme, string sinopse, int anolancamento, Genero generofilme, List<Avaliacao> avaliacoes)
        {
            this.IdFilme = idfilme;
            this.TituloFilme = titulofilme;
            this.Sinopse = sinopse;
            this.AnoLancamento = anolancamento;
            this.Ativo = true;
            this.GeneroFilme = generofilme;
            this.Avaliacoes = avaliacoes;
        }

        public Filmes(int idfilme, string titulofilme, string sinopse, int anolancamento, Genero generofilme)
        {
            this.IdFilme = idfilme;
            this.TituloFilme = titulofilme;
            this.Sinopse = sinopse;
            this.AnoLancamento = anolancamento;
            this.Ativo = true;
            this.GeneroFilme = generofilme;
        }

        public Filmes()
        {
            this.Ativo = true;
        }

        public string GetResumo()
        {
            string generoString = "";
            if (GeneroFilme == Genero.Ação)
            {
                generoString = "ação";
            }
            if (GeneroFilme == Genero.Comédia)
            {
               generoString = "Comédia";
            }
            if (GeneroFilme == Genero.Documentário)
            {
                generoString = "Documentário";
            }
            if (GeneroFilme == Genero.Drama)
            {
                generoString = "Drama";
            }
            if (GeneroFilme == Genero.Ficção)
            {
                generoString = "Ficção";
            }
            if (GeneroFilme == Genero.Terror)
            {
                generoString = "Terror";
            }
            return $"Titulo:{TituloFilme} - Ano de lançamento: {AnoLancamento} - Gênero: {generoString}";
        }

        public enum Genero
        {
            Ação,
            Comédia,
            Documentário,
            Drama,
            Ficção,
            Terror
        }

        private double CalcularMediaNota()
        {
            var mediaNota = this.Avaliacoes.Average(a => a.Nota);
            return System.Math.Round(mediaNota, 2);
        }
    }
}