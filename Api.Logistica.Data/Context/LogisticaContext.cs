using Api.Logistica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Data.Context
{
    public class LogisticaContext : DbContext
    {
        public LogisticaContext(DbContextOptions<LogisticaContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<PedidoProducto> PedidoProducto { get; set; }

        
    }
}
