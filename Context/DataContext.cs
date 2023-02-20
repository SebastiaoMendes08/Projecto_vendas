using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poj.Models;
using Projecto_vendas.Models;

namespace Poj.Context
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Categoria> Categorias {get;set;}
         public DbSet<Produto> Produtos {get;set;}
    }
}