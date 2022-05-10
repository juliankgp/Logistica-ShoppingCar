using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Dto.Dto
{
    public class ProductoDto
    {
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Precio { get; set; }
        public string? Img { get; set; }
    }
}
