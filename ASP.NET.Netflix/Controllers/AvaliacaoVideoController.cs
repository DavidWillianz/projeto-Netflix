using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Netflix.Controllers
{
    [ApiController]
    [Route("api/avaliacao")]
    public class AvaliacaoVideoController : ControllerBase
    {
        public static List<Avaliacao> listaAvaliacoes = new List<Avaliacao>()
       {
          new Avaliacao(1, 10, "ótimo", 123, "Shelby"),
          new Avaliacao(2, 9, "bom", 123, "Wayne"),
          new Avaliacao(3, 10, "ótimo", 123, "Stark")
       };

        [HttpGet("{idAvaliacao}")]
        public IActionResult GetAvaliacao(int idAvaliacao)
        {
            var avaliacaoBuscada = listaAvaliacoes.Find(a => a.IdAvaliacao == idAvaliacao);
            if (listaAvaliacoes == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma avaliação encontrada"));
            }
            return Ok(listaAvaliacoes);
        }

        [HttpDelete("{idAvaliacao}")]
        public IActionResult DeleteAvaliacao(int idAvaliacao)
        {
            var avaliacaoBuscada = listaAvaliacoes.Find(a => a.IdAvaliacao == idAvaliacao);
            if (listaAvaliacoes == null)
            {
                return BadRequest(new Resposta(400, "Nenhuma avaliação"));
            }
            listaAvaliacoes.Remove(avaliacaoBuscada);
            return Ok(listaAvaliacoes);
        }

    }
}