using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.API.Controllers
{
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;
        public EventosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // api/eventos
        [HttpGet]
        public IActionResult ObterEventos()
        {
            var eventos = _dbContext.Eventos.ToList();

            return Ok(eventos);
        }

        // api/eventos/1
        [HttpGet("{id}")]
        public IActionResult ObterEvento(int id)
        {
            var evento = _dbContext
                .Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Usuario)
                .SingleOrDefault(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // api/eventos
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Evento evento)
        {
            return NoContent();
        }

        // api/eventos/1
        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            return NoContent();
        }

        // api/eventos/1/usuarios/3/inscrever
        [HttpPost("{id}/usuarios/{idUsuario}/inscrever")]
        public IActionResult Inscrever(int id, int idUsuario, [FromBody] Inscricao inscricao)
        {
            return NoContent();
        }

        [HttpPost("popular")]
        public IActionResult Popular()
        {
            var usuario = new Usuario
            {
                NomeCompleto = "Franco Dev",
                Email = "franco@gmail.com"
            };

            var categorias = new List<Categoria>
            {
                new Categoria { Descricao = "C#" },
                new Categoria { Descricao = "Flutter" },
                new Categoria { Descricao = "Xamarin" }
            };

            _dbContext.Usuarios.Add(usuario);
            _dbContext.Categorias.AddRange(categorias);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
