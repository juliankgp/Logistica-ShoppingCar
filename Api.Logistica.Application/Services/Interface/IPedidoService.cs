using Api.Logistica.Domain.Entities;
using Api.Logistica.Dto.Dto;
using Api.Logistica.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Logistica.Application.Services.Interface
{
    public interface IPedidoService
    {
        Task<ResponseModel> Guardar(PedidoDto orden);
        Task<PedidoDto> GetPedido(int idPedido);
        Task<List<PedidoDto>> GetPedidos(); 
        Task<ResponseModel> CrearProducto(CrearProductoDto producto);
        Task<List<CrearProductoDto>> GetProductos();
        Task<CrearProductoDto> GetProductoById(int id);
    }
}
