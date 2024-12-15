using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miwebapi.Data;
using Miwebapi.Models;

namespace Miwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // CREATE: api/usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { cedula = usuario.Cedula }, usuario);
        }

        // READ: api/usuarios/{cedula}
        [HttpGet("{cedula}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string cedula)
        {
            var usuario = await _context.Usuarios.FindAsync(cedula);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // LIST: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // UPDATE: api/usuarios/{cedula}
        [HttpPut("{cedula}")]
        public async Task<IActionResult> UpdateUsuario(string cedula, Usuario usuario)
        {
            if (cedula != usuario.Cedula)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(cedula))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/usuarios/{cedula}
        [HttpDelete("{cedula}")]
        public async Task<IActionResult> DeleteUsuario(string cedula)
        {
            var usuario = await _context.Usuarios.FindAsync(cedula);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(string cedula)
        {
            return _context.Usuarios.Any(e => e.Cedula == cedula);
        }
    }
}
