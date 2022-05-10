using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Api.Logistica.Domain.Entities
{
    public class PedidoProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Cantidad { get; set; }
        public string ValorUnidad{ get; set; }
        public string ValorTotal { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        //relaciones
        [JsonIgnore]
        public Pedido Pedido { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }
    }
}
