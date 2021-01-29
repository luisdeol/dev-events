using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace DevEvents.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;
        public UsuariosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
