using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poj.Context;
using Poj.Models;
using Projecto_vendas.Models;
using Projecto_vendas.Models.DTO;

namespace Projecto_vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult MostrarProdutos()
        {
            if(_context.Produtos==null) return NoContent();
            
                var produtos = (from a in _context.Produtos join b in _context.Categorias on a.CategoriaId equals b.Id  select new {
             ID = a.Id,Artigo = a.Nome,  Quantidade = a.Quantidade,Categorip = b.Nome,
         });
          return Ok(produtos);
        }
        


        [HttpPost]
        public IActionResult CreateProduto (ProdutoResquest resquest)
        {
            Produto produtos = new Produto();
            produtos.Nome = resquest.Nome;
            produtos.Quantidade = resquest.Quantidade;
            produtos.Preco = resquest.Preco;
            produtos.CategoriaId = resquest.CategoriaId;
              _context.Add(produtos);
              _context.SaveChanges();
           return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarProdutoID (Guid id){
          
          var produtos = _context.Produtos.Find(id);
          if(produtos ==null) return NotFound();

          return Ok(produtos);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProdutos (Guid id,Produto produto)
        {
            var ProdutoBanco = _context.Produtos.Find(id);
          if(ProdutoBanco ==null) return NotFound();

          ProdutoBanco.Nome  = produto.Nome;
          ProdutoBanco.Quantidade = produto.Quantidade;
          ProdutoBanco.CategoriaId = produto.CategoriaId;

          _context.Update(ProdutoBanco);
          _context.SaveChanges();  
                 return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(Guid id)
        {
            var ProdutoBanco = _context.Produtos.Find(id);
            if (ProdutoBanco == null) return NotFound();

            _context.Produtos.Remove(ProdutoBanco);
            _context.SaveChanges();
            return NoContent();
        }

         [HttpGet("PesquisarProdutoPorNomes")]
        public IActionResult ObterNomes (string nome)
        {
           var ProdutoBanco = _context.Produtos.Where(x=>x.Nome.Contains(nome));
            return Ok(ProdutoBanco);
        }

    }
}