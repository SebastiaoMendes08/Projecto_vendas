using Microsoft.AspNetCore.Mvc;
using Poj.Context;
using Poj.Models;
namespace Poj.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
       private readonly DataContext _context ; 

        public CategoriaController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Mostrar()
        {
            if(_context.Categorias==null) return NoContent();
            
           return Ok(_context.Categorias);
        }

        [HttpPost]
        public IActionResult create(Categoria Categoria)
        {
            _context.Add(Categoria);
            _context.SaveChanges();
            return Ok(Categoria);
        }
    }
}