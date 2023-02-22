using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projecto_vendas.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projecto_vendas.Models
{
    public class Produto
    {
        public Guid Id { get; set; } = new Guid();

        public string? Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco {get;set;}

       [ForeignKey("Categoria")]
       public Guid? CategoriaId {get;set;}

    }
}