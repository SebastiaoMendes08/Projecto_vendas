using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecto_vendas.Models;
using Poj.Context;

namespace Projecto_vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
      private readonly DataContext _context;

      public VendaController(DataContext context)
      {
        _context = context;
      }
       //api/vendacontroller/
       [HttpPost]
        public IActionResult CreateVenda (Venda resquest)
        {
           var ProdBanco = _context.Produtos.Find(resquest.ProdutoId);
           if(ProdBanco==null) return NotFound();
          if(ProdBanco.Quantidade < resquest.Quantidade) return BadRequest("Quantidade inferior.");
           
        //  string [] vendas;
           
        //  vendas = resquest();
          
        //  foreach (var item in resquest)
       //   {
              
       //   }
          
            Venda vendas = new Venda();
            vendas.ProdutoId = resquest.ProdutoId;
            vendas.Quantidade = ProdBanco.Quantidade - resquest.Quantidade;
            vendas.ClienteId = resquest.ClienteId;
              _context.Add(vendas);
              _context.SaveChanges();
           return Ok(vendas);
        }
    }
}