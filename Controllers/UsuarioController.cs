using ApiConfiamed.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConfiamed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly RegistroMascotasContext _context;
        public UsuarioController(RegistroMascotasContext registroMascotasContext)
        {
            _context = registroMascotasContext;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarUsuario() 
        {
            List<Usuario> usuario= new List<Usuario>();
            usuario = _context.Usuarios.ToList();
            return Ok(usuario);
        
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear([FromBody] Usuario usuario)
        {   
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok();

        }
    }
}
