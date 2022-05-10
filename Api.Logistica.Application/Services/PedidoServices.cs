using Api.Logistica.Application.Services.Interface;
using Api.Logistica.Data.Context;
using Api.Logistica.Domain.Entities;
using Api.Logistica.Dto.Dto;
using Api.Logistica.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Logistica.Application.Services
{
    public class PedidoServices : IPedidoService
    {
        private readonly LogisticaContext _context;
        private readonly ILogger<PedidoServices> _logger;
        public PedidoServices(LogisticaContext context, ILogger<PedidoServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseModel> Guardar(PedidoDto orden)
        {
            try
            {

                Pedido pedido = new Pedido()
                {
                    Direccion = orden.Direccion,
                    CantidadArticulos = orden.Productos.Count.ToString(),
                    Telefono = orden.Telefono,
                    Impuestos = orden.Impuestos,
                    SubtotalPedido = orden.Subtotal,
                    TotalPedido = orden.Total,
                    Usuario = orden.Nombre,

                };

                _context.Pedido.Add(pedido);
                _context.SaveChanges();

                var max = _context.Pedido.OrderByDescending(p => p.Id).FirstOrDefault();
                var maxProd = _context.Producto.OrderByDescending(p => p.Id).FirstOrDefault();

                foreach (var item in orden.Productos)
                {
                    var valorProducto = await _context.Producto.FirstOrDefaultAsync(m => m.Id == item.idProducto);

                    PedidoProducto pedidoProducto = new PedidoProducto()
                    {
                        IdPedido = max.Id,
                        IdProducto = item.idProducto,
                        Cantidad = item.Cantidad.ToString(),
                        ValorUnidad = valorProducto.Valor.ToString(),
                        ValorTotal = (Convert.ToInt32(item.Cantidad) * valorProducto.Valor).ToString(),
                        Pedido = max,
                        Producto = valorProducto
                    };

                    _context.PedidoProducto.Add(pedidoProducto);
                }

                _context.SaveChanges();

                ResponseModel response = new ResponseModel()
                {
                    Descripcion = "Pedido Creado Correctamente",
                    Exitoso = true
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }

        public async Task<PedidoDto> GetPedido(int idPedido)
        {
            try
            {
                var pedido = await _context.Pedido.FindAsync(idPedido);
                var productos = _context.PedidoProducto.Where(x => x.Id == idPedido).ToList();
                List<ProductoDto> listaProductos = new List<ProductoDto>();
                foreach (var item in productos)
                {
                    var producto = await _context.Producto.FindAsync(item.IdProducto);

                    ProductoDto productosDto = new ProductoDto()
                    {
                        Cantidad = Convert.ToInt32(item.Cantidad),
                        idProducto = item.IdProducto,
                        Nombre = producto.Nombre
                    };

                    listaProductos.Add(productosDto);
                }

                PedidoDto response = new PedidoDto()
                {
                    Nombre = pedido.Usuario,
                    Direccion = pedido.Direccion,
                    Telefono = pedido.Telefono,
                    Total = pedido.TotalPedido,
                    Productos = listaProductos,
                    Subtotal = pedido.SubtotalPedido,
                    Impuestos = pedido.Impuestos
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }

        public async Task<List<PedidoDto>> GetPedidos()
        {
            try
            {
                List<PedidoDto> listaPedido = new List<PedidoDto>();
                List<ProductoDto> listaProd = new List<ProductoDto>();

                var pedido = await _context.Pedido.ToListAsync();

                foreach (var item in pedido)
                {
                    PedidoDto pedidoDto = new PedidoDto();
                    var productosPedido = _context.PedidoProducto.Where(x => x.IdPedido == item.Id).ToList();

                    foreach (var producto in productosPedido)
                    {
                        var productos = await _context.Producto.FindAsync(producto.IdProducto);

                        ProductoDto productosDto = new ProductoDto()
                        {
                            Cantidad = Convert.ToInt32(producto.Cantidad),
                            idProducto = producto.IdProducto,
                            Nombre = productos.Nombre,
                            Precio = productos.Valor.ToString(),
                            Descripcion = productos.Descripcion,
                            Img = productos.Image
                        };
                        listaProd.Add(productosDto);
                    }

                    pedidoDto.Nombre = item.Usuario;
                    pedidoDto.Telefono = item.Telefono;
                    pedidoDto.Direccion = item.Direccion;
                    pedidoDto.Productos = listaProd;
                    pedidoDto.Impuestos = item.Impuestos;
                    pedidoDto.Subtotal = item.SubtotalPedido;
                    pedidoDto.Total += item.TotalPedido;

                    listaProd = new List<ProductoDto>();

                    listaPedido.Add(pedidoDto);
                }


                return listaPedido;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }

        public async Task<ResponseModel> CrearProducto(CrearProductoDto producto)
        {
            try
            {
                Producto nuevoProducto = new Producto()
                {
                    Descripcion = producto.Descripcion,
                    Nombre = producto.Nombre,
                    Valor = Convert.ToInt32(producto.Precio)
                };


                _context.Producto.Add(nuevoProducto);
                await _context.SaveChangesAsync();

                ResponseModel response = new ResponseModel()
                {
                    Descripcion = "Producto Creado",
                    Exitoso = true
                };
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }

        public async Task<List<CrearProductoDto>> GetProductos()
        {
            try
            {
                List<CrearProductoDto> productosResponse = new List<CrearProductoDto>();
                var productos = await _context.Producto.ToListAsync();

                foreach (var prod in productos)
                {
                    CrearProductoDto currProd = new CrearProductoDto()
                    {
                        Cantidad = prod.Cantidad,
                        Nombre = prod.Nombre,
                        Descripcion = prod.Descripcion,
                        Id = prod.Id,
                        Precio = prod.Valor,
                        Img = prod.Image

                    };

                    productosResponse.Add(currProd);

                }

                return productosResponse;

            }
            catch (Exception ex)
            {

                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }

        public async Task<CrearProductoDto> GetProductoById(int id)
        {
            try
            {
                var prod= await _context.Producto.FindAsync(id);
                CrearProductoDto productoResponse = new CrearProductoDto()
                {
                    Cantidad = prod.Cantidad,
                    Nombre = prod.Nombre,
                    Descripcion = prod.Descripcion,
                    Id = prod.Id,
                    Precio = prod.Valor,
                    Img = prod.Image
                };

                return productoResponse;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error {ex.Message}");
                throw;
            }
        }
    }
}

