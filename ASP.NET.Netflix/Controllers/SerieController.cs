using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Netflix.Controllers
{
    [ApiController]
    [Route("api/series")]
    public class SerieController : ControllerBase
    {
        public static List<Avaliacao> avaliacoes1 = new List<Avaliacao>()
        {
            new Avaliacao(1, 10, "ótimo", 123, "Thiago"),
            new Avaliacao(2, 9, "bom", 123, "Alberto"),
            new Avaliacao(3, 9, "bom", 123, "Jonas")

        };
        public static List<Avaliacao> avaliacoes2 = new List<Avaliacao>()
        {
            new Avaliacao(4, 10, "ótimo", 124, "Thiago"),
            new Avaliacao(5, 8, "bom", 124, "Alberto"),
            new Avaliacao(6, 8, "bom", 124, "Jonas")
        };

        private List<Series> listaSeries = new List<Series>
        {
            new Series(1, "House of the dragon", 1, 2022, Series.GeneroSeries.Ficcao, avaliacoes1),
            new Series(2, "Supernarutal", 15, 2005, Series.GeneroSeries.Ficcao, avaliacoes2)
        };

        [HttpGet]
        public IActionResult GetListaSerie()
        {
            if (listaSeries == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }
            return Ok(listaSeries);
        }

        [HttpPost]
        public IActionResult PostSerie(Series novaSerie)
        {
            if (listaSeries == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }
            listaSeries.Add(novaSerie);
            return Ok(listaSeries);
        }

        [HttpGet]
        [Route("{idSerie}")]
        public IActionResult GetSerieId(int idSerie)
        {
            var serieBuscada = listaSeries.Find(s => s.IdSerie == idSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }

            return Ok(serieBuscada);
        }

        [HttpPut]
        public IActionResult PutEditarSerie(Series serieEditada)
        {
            var serieBuscada = listaSeries.Find(s => s.IdSerie == serieEditada.IdSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }

            serieBuscada.TituloSerie = serieEditada.TituloSerie;
            serieBuscada.QuantidadeTemporadas = serieEditada.QuantidadeTemporadas;
            serieBuscada.AnoLancamento = serieEditada.AnoLancamento;
            serieBuscada.GeneroSerie = serieEditada.GeneroSerie;

            return Ok(listaSeries);
        }

        [HttpDelete("{idSerie}")]
        public IActionResult DeletarSerie(int idSerie)
        {
            var serieBuscada = listaSeries.Find(s => s.IdSerie == idSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }

            listaSeries.Remove(serieBuscada);

            return Ok(listaSeries);
        }

        [HttpPatch("{idSerie}")]
        public IActionResult PatchDesativarSerie(int idSerie)
        {
            var serieBuscada = listaSeries.Find(s => s.IdSerie == idSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma série encontrada"));
            }

            serieBuscada.Ativo = false;

            return Ok(listaSeries);
        }
    }
}