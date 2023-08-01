using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using static ASP.NET.Netflix.Filmes;

namespace ASP.NET.Netflix.Controllers
{
    [ApiController]
    [Route("api/filmes")]
    public class FilmeController : ControllerBase
    {
        public static List<Avaliacao> avaliacoes1 = new List<Avaliacao>()
        {
            new Avaliacao(1, 10, "ótimo", 123, "Shelby"),
            new Avaliacao(2, 9.5, "ótimo", 123, "Wayne"),
            new Avaliacao(3, 9, "bom", 123, "Stark")

        };
        public static List<Avaliacao> avaliacoes2 = new List<Avaliacao>()
        {
            new Avaliacao(4, 10, "ótimo", 124, "Shelby"),
            new Avaliacao(5, 10, "ótimo", 124, "Wayne"),
            new Avaliacao(6, 9, "bom", 124, "Stark")
        };
        public static List<Avaliacao> avaliacoes3 = new List<Avaliacao>()
        {
            new Avaliacao(7, 10, "ótimo", 125, "Shelby"),
            new Avaliacao(8, 10, "ótimo", 125, "Wayne"),
            new Avaliacao(9, 9, "bom", 125, "Stark")
        };

        private List<Filmes> listafilmes = new List<Filmes>
        {
           new Filmes(1, "Gente Grande", "Sinopse", 2010, Genero.Comédia, avaliacoes1),
           new Filmes(2, "Top Gun - Maverick", "Sinopse", 2022, Genero.Ação, avaliacoes2),
           new Filmes(3, "Avatar", "Sinopse", 2006, Filmes.Genero.Ficção, avaliacoes3)

        };

        [HttpGet]
        public IActionResult GetListaFilme()
        {
            if (listafilmes == null)
            {
                return BadRequest(new Resposta(400, "Nenhum registro encontrado!"));
            }
            return Ok(listafilmes);
        }

        [HttpPost]
        public IActionResult Post(Filmes novofilme)
        {
            if (listafilmes == null)
            {
                return BadRequest(new Resposta(200, "Nenhum registro encontrado"));
            }
            listafilmes.Add(novofilme);
            return Ok(listafilmes);
        }

        [HttpGet]
        [Route("{idFilme}")]
        public IActionResult GetFilmeId(int idFilme)
        {
            var filmeBuscado = listafilmes.Find(f => f.IdFilme == idFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Resposta(400, "Nenhum filme encontrado"));
            }

            return Ok(filmeBuscado);
        }

        [HttpPut]
        public IActionResult PutEditarFilme(Filmes filmeEditado)
        {
            var filmeBuscado = listafilmes.Find(f => f.IdFilme == filmeEditado.IdFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Resposta(400, "Nenhum filme encontrado"));
            }

            filmeBuscado.TituloFilme = filmeEditado.TituloFilme;
            filmeBuscado.Sinopse = filmeEditado.Sinopse;
            filmeBuscado.AnoLancamento = filmeEditado.AnoLancamento;
            filmeBuscado.GeneroFilme = filmeEditado.GeneroFilme;

            return Ok(listafilmes);
        }

        [HttpDelete("{idFilme}")]
        public IActionResult DeleteFilme(int idFilme)
        {
            var filmeBuscado = listafilmes.Find(f => f.IdFilme == idFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Resposta(400, "Nehum filme encontrado"));
            }

            listafilmes.Remove(filmeBuscado);

            return Ok(listafilmes);
        }

        [HttpPatch("{idFilme}")]
        public IActionResult PatchDesativarFilme(int idFilme)
        {
            var filmeBuscado = listafilmes.Find(f => f.IdFilme == idFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Resposta(400, "Nenhum Filme encontrado"));
            }

            filmeBuscado.Ativo = false;

            return Ok(listafilmes);
        }
    }
}