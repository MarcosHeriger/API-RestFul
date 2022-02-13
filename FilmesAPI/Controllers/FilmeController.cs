using FilmesAPI.Data;
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
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context; ;
        }

        [HttpPost]
        public IActionResult AdicionarFilmes([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilme), new { id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult ListaDeFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
