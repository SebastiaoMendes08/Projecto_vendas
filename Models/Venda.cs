using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Projecto_vendas.Models;

namespace Projecto_vendas.Models
{
    public class Venda
    {
        public Guid Id { get; set; } = new Guid();

        public int NumVenda { get; set; } = new int();

        public int Quantidade { get; set; }

        
        [ForeignKey("Produto")]
        public Guid? ProdutoId {get;set;}

        [ForeignKey("Cliente")]
        public Guid? ClienteId {get;set;}

    }
}