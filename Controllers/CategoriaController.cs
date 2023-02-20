using Microsoft.AspNetCore.Mvc;
using Poj.Context;
using Poj.Models;
using Projecto_vendas.Models.DTO;
using Projecto_vendas.Models;

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
        public IActionResult CreateCategoria (string dados)
        { 
           
            Categoria categoria = new Categoria();
            categoria.Nome = dados;
          
            _context.Add(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarCategoriaID (Guid id){
          
          var Categoria = _context.Categorias.Find(id);
          if(Categoria ==null) return NotFound();

          return Ok(Categoria);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoria (Guid id,CategoriaRequest categoria)
        {
            var CategoriaBanco = _context.Categorias.Find(id);
          if(CategoriaBanco ==null) return NotFound();

          CategoriaBanco.Nome  = categoria.Nome;
          _context.Update(CategoriaBanco);
          _context.SaveChanges();  
                 return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(Guid id)
        {
            var CategoriaBanco = _context.Categorias.Find(id);
            if (CategoriaBanco == null) return NotFound();

            _context.Categorias.Remove(CategoriaBanco);
            _context.SaveChanges();
            return NoContent();
        }

         [HttpGet("PesquisarCategoriasPorNomes")]
        public IActionResult ObterNomes (string nome)
        {
           var CategoriaBanco = _context.Categorias.Where(x=> x.Nome.Contains(nome));
            return Ok(CategoriaBanco);
        }
    }
}