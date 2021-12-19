using BEPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
            {
                var listUsuarios = await _context.Usuarios.ToListAsync();
                return Ok(listUsuarios);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuarios usuario)
        {
            try
            {
                _context.Add(usuario);  
                await   _context.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return NotFound();
                }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "actualizacion exitosa" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if(usuario == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Removido Exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
