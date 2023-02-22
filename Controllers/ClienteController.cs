using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poj.Context;
using Projecto_vendas.Models;
using Projecto_vendas.Models.DTO;

namespace Projecto_vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context ; 

      public ClienteController(DataContext context )
      {
        _context = context;
      }


        [HttpGet]
        public IActionResult Mostrar()
        {
            if(_context.Clientes==null) return NoContent();
            
           return Ok(_context.Clientes);
        }

        [HttpPost]
        public IActionResult CreateCliente(string dados)
        { 
           
          Cliente clientes  = new Cliente();
            clientes.Nome = dados;
          
            _context.Add(clientes);
            _context.SaveChanges();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult MostrarClienteID (Guid id){
          
          var cliente = _context.Clientes.Find(id);
          if(cliente ==null) return NotFound();

          return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClientes (Guid id,ClienteRequest Nome)
        {
            var clienteBanco = _context.Clientes.Find(id);
          if(clienteBanco ==null) return NotFound();

          clienteBanco.Nome  = Nome.Nome;
          _context.Update(clienteBanco);
          _context.SaveChanges();  
                 return Ok(Nome);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(Guid id)
        {
            var ClienteBanco = _context.Clientes.Find(id);
            if (ClienteBanco == null) return NotFound();

            _context.Clientes.Remove(ClienteBanco);
            _context.SaveChanges();
            return NoContent();
        }

         [HttpGet("PesquisarCategoriasPorNomes")]
        public IActionResult ObterNomes (string nome)
        {
           var ClienteBanco = _context.Clientes.Where(x=> x.Nome.Contains(nome));
            return Ok(ClienteBanco);
        }
    }
}