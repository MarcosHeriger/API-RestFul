using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionarFilmes([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(GetFilme), new { id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult ListaDeFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilme(int id)
        {
            Filme filme = filmes.FirstOrDefault(Filme => Filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
