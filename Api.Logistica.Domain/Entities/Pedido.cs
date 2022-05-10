using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft;


namespace Api.Logistica.Domain.Entities
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Impuestos { get; set; }
        public string SubtotalPedido { get; set; }
        public string TotalPedido { get; set; }
        public string CantidadArticulos { get; set; }

        [JsonIgnore]
        public List<PedidoProducto> Productos { get; set; }
    }
}
