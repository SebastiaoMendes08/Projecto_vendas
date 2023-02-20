using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projecto_vendas.Models;

namespace Poj.Models
{
    public class Categoria
    {

        public Guid Id { get; set; } = new Guid();
        public string? Nome {get;set;}

    }
}