using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Dto.Dto
{
    public class CrearProductoDto
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Img { get; set; }
    }
}
