using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Dto.Dto
{
    public class PedidoDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Impuestos { get; set; }
        public string Subtotal { get; set; }
        public string Total { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }
}
