using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Api.Logistica.Application.Services.Interface;
using Api.Logistica.Models.Models;
using Api.Logistica.Dto.Dto;
using Api.Logistica.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Logisitca.Test.Presentation.Controllers
{
    public class PedidoControllerTest
    {
        [Fact]
        public void PedidoController_Pedido_OK()
        {
            #region Arrange
            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(h => h.Guardar(It.IsAny<PedidoDto>()))
                .ReturnsAsync(new ResponseModel());

            var pedidoController = new PedidoController(pedidoServiceMock.Object);
            #endregion

            #region Act
            var response = pedidoController.Pedido(new PedidoDto());
            #endregion

            #region Assert
            Assert.IsType<OkObjectResult>(response.Result);
            #endregion
        }

        [Fact]
        public void PedidoController_GetPedido_OK()
        {
            #region Arrange
            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(h => h.GetPedido(It.IsAny<int>()))
                .ReturnsAsync(new PedidoDto());

            var pedidoController = new PedidoController(pedidoServiceMock.Object);
            #endregion

            #region Act
            var response = pedidoController.GetPedido(1);
            #endregion

            #region Assert
            Assert.IsType<OkObjectResult>(response.Result);
            #endregion
        }

        [Fact]
        public void PedidoController_GetPedidos_OK()
        {
            #region Arrange
            var pedidoServiceMock = new Mock<IPedidoService>();
            pedidoServiceMock.Setup(h => h.GetPedidos())
                .ReturnsAsync(new List<PedidoDto>());

            var pedidoController = new PedidoController(pedidoServiceMock.Object);
            #endregion

            #region Act
            var response = pedidoController.GetPedidos();
            #endregion

            #region Assert
            Assert.IsType<OkObjectResult>(response.Result);
            #endregion
        }
    }
}
