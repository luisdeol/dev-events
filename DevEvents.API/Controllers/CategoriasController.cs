using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevEvents.API.Controllers
{
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;
        public CategoriasController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            var categorias = _dbContext.Categorias.ToList();

            return Ok(categorias);
        }
    }
}
