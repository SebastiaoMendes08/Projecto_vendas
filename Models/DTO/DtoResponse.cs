using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_vendas.Models.DTO
{
    public class DtoResponse
    {
   
    }

    public class CategoriaResponse
    {
               public Guid Id { get; set; } = new Guid();
               public string? Nome {get;set;}
    }
}