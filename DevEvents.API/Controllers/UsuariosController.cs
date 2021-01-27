using DevEvents.API.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace DevEvents.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            return Ok();
        }
    }
}
