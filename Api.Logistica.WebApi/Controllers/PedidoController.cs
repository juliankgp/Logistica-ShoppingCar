using Api.Logistica.Application.Services.Interface;
using Api.Logistica.Domain.Entities;
using Api.Logistica.Dto.Dto;
using Api.Logistica.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logistica.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedido;
        public PedidoController(IPedidoService pedido)
        {
            _pedido = pedido;
        }

        [HttpPost("GuardarPedido")]
        public async Task<IActionResult> Pedido(PedidoDto pedido)
        {
            var response = await _pedido.Guardar(pedido);
            return Ok(response);
        }

        [HttpGet("GetPedido")]

        public async Task<IActionResult> GetPedido(int idPedido)
        {
            var response = await _pedido.GetPedido(idPedido);
            return Ok(response);
        }

        [HttpGet("GetPedidos")]

        public async Task<IActionResult> GetPedidos()
        {
            var response = await _pedido.GetPedidos();
            return Ok(response);
        }

        [HttpPost("CrearProducto")]

        public async Task<IActionResult> CrearProducto(CrearProductoDto producto)
        {
            var response = await _pedido.CrearProducto(producto);
            return Ok(response);
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _pedido.GetProductos();
            return Ok(response);
        }

        [HttpGet("GetProductoById")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            var response = await _pedido.GetProductoById(id);
            return Ok(response);
        }
    }
}
