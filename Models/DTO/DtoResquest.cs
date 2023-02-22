using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projecto_vendas.Models.DTO
{
    public class ProdutoResquest
    {
        public string? Nome { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco {get;set;}

       [ForeignKey("Categoria")]
       public Guid? CategoriaId {get;set;}
    }

    public class CategoriaRequest
    {
               public string? Nome {get;set;}
    }

    public class  ClienteRequest{
        public string? Nome {get;set;}
    }

    
}