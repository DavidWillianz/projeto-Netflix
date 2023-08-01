using System.Collections.Generic;
using System.Linq;

namespace ASP.NET.Netflix
{
    public class Series
    {
         public int IdSerie { get; set; }
        public string TituloSerie { get; set; }
        public int QuantidadeTemporadas { get; set; }
        public int AnoLancamento { get; set; }
        public bool Ativo { get; set; }
        public GeneroSeries GeneroSerie { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
        public string Resumo { get { return $"{GetResumo()}"; } }
        public double MediaNota { get { return CalcularMediaNota(); } }

        public Series(int idserie, string tituloserie, int quantidadetemporadas, int anolancamento, GeneroSeries generoserie)
        {
            this.IdSerie = idserie;
            this.TituloSerie = tituloserie;
            this.QuantidadeTemporadas = quantidadetemporadas;
            this.AnoLancamento = anolancamento;
            this.Ativo = true;
            this.GeneroSerie = generoserie;
        }

        public Series(int idserie, string tituloserie, int quantidadetemporadas, int anolancamento, GeneroSeries generoserie, List<Avaliacao> avaliacoes)
        {
            this.IdSerie = idserie;
            this.TituloSerie = tituloserie;
            this.QuantidadeTemporadas = quantidadetemporadas;
            this.AnoLancamento = anolancamento;
            this.Ativo = true;
            this.GeneroSerie = generoserie;
            this.Avaliacoes = avaliacoes;
        }

        public string GetResumo()
        {
            string GeneroString = "";
            if (GeneroSerie == GeneroSeries.Ação)
            {
                GeneroString = "ação";
            }
            if (GeneroSerie == GeneroSeries.Comédia)
            {
                GeneroString = "Comédia";
            }
            if (GeneroSerie == GeneroSeries.Documentário)
            {
                GeneroString = "Documentário";
            }
            if (GeneroSerie == GeneroSeries.Drama)
            {
                GeneroString = "Drama";
            }
            if (GeneroSerie == GeneroSeries.Ficcao)
            {
                GeneroString = "Ficção";
            }
            if (GeneroSerie == GeneroSeries.Terror)
            {
                GeneroString = "Terroe";
            }
            return $"Titulo:{TituloSerie} - Ano de lançamento: {AnoLancamento} - Gênero: {GeneroString}";
        }

        public enum GeneroSeries
        {
            Ação,
            Comédia,
            Documentário,
            Drama,
            Ficcao,
            Terror
        }

        public Series() { }

        private double CalcularMediaNota()
        {
            var mediaNota = this.Avaliacoes.Average(a => a.Nota);
            return System.Math.Round(mediaNota, 2);
        }
    }
}