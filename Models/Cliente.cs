using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecto_vendas.Models
{
    public class Cliente
    {
       public Guid Id { get; set; } = new Guid();

       public string?  Nome { get; set; }
    }
}