# Logistica-ShoppingCar
Api Logistica, se encarga de gestionar todo lo referente con los pedidos del proyecto.


## Versión
API Backend en .net core version netcoreapp3.1


## Porque?


El API *Logistica-ShoppingCar* es un backend para un proyecto de carrito de compras, el cual tiene como finalidad mostrar los conocimientos adquiridos en las tecnologías necesarias para el rol.

Esta API se encarga de gestionar todolos pedidos y facturacion del carrito de mercado , recibe peticiones del [**Orq-ShoppingCar**](https://github.com/juliankgp/Orq-ShoppingCar), y crea o devuelve los pedidos solicitados y la facturacion necesaria.


## ¿Cómo funciona?
Lo primero que se debe hacer es descargar el repositorio en una máquina local, al hacer esto se descarga un proyecto de tipo API Web.NetCore para poder ejecutarlo puede usar Visual studio, o si quiere ejecutarlo en algún otro editor de código como VSC puede leer el siguiente artículo [**Visual Studio Code: cómo preparar un entorno de trabajo para .NET**](https://www.campusmvp.es/recursos/post/visual-studio-code-como-preparar-un-entorno-de-trabajo-para-net-core.aspx). Debe tener en cuenta que antes de iniciar Angular se deben iniciar SQL server managment studio y las tres APIS que conforman la prueba (en primer lugar [**Logistica-ShoppingCar**](https://github.com/juliankgp/Logistica-ShoppingCar), es muy importante que sé la primera que se ejecute, ya que esta API creara la base de datos donde se harán todas las consultas, luego de esta podemos continuar con [**Productos-ShoppingCar**](https://github.com/juliankgp/Productos-ShoppingCar) y por último [**Orq-ShoppingCar**](https://github.com/juliankgp/Orq-ShoppingCar)). Una vez completados este paso ya podrá arrancar la API que lo redirige directamente al swagger donde se muestra toda la documentación de esta. 



## Librerías


- *Microsoft.EntityFrameworkCore.SqlServer*: esta librería se usa para la conexion con la base de datos.
- *Microsoft.VisualStudio.Azure.Containers.Tools.Targets*: esta librería se instala por defecto cuando se configura el campo de Docker al crear la API.
- *Serilog:* Esta librería se usa para el manejo de loggers dentro del API
- *Swashbuckle.AspNetCore:* Esta librería se utiliza para poder configurar el swagger.


## Instalación
Para arranacar este proyecto que debe ser el primero en ejecutarse del back, debemos tener en cuenta que tenemos que tener accesi a Microsoft SQL server Managment - a partir de aca debemos crear una base de datos con un servidor local, la conexion de nuestras apis esta dada por la siguiente cadena de conexion **"Server=localhost;Database=Logistica;Trusted_Connection=True;MultipleActiveResultSets=true"** esto apunta a la base de datos local, de otra manera, el api de logistica no podra conectarse con la db 

Una vez esta conectada la db el siguiente paso es ejectuar el api en el ID de su preferencia, una vez que se ejecuta esta api **Api.Orq.Pagos** y el **IIS Express**, EF se encarga de crear la base de datos, debe iniciar las demas APIS y estara lista toda la informacion necesaria para poder empezar a probar la aplicacion.



## Pruebas unitarias 
### XUnit
Este proyecto se le realizaron pruebas unitarias con Xunit, es el proyecto que mas completo tiene las pruebas, puesto que los demas no poseen o solo tienen muy pocas.


## Repositorios relacionados

La aplicación consta de cuatro repositorios incluido este  para funcionar:

[**Front-ShoppingCar**](https://github.com/juliankgp/Front-ShoppingCar) : Este repositorio es el front de la aplicación, se encarga de mostrar la interfaz gráfica de nuestra aplicación.

[**Productos-ShoppingCar**](https://github.com/juliankgp/Productos-ShoppingCar): Este repositorio se encarga de gestionar todos los productos del catálogo, envía y devuelve todas las peticiones del front referente con los productos. 

[**Orq-ShoppingCar**](https://github.com/juliankgp/Orq-ShoppingCar) : Este repositorio es el orquestador del proyecto se encarga de recibir las peticiones validar los campos y distribuirlas a las apis correspondientes.

## Métodos



 [*API Logística*](https://github.com/juliankgp/Logistica-ShoppingCar)

| Nombre | Path | Método |
| ------ | ------ | ------ |
| GetPedidos |[*api/api/Pedido/GetPedidos*](https://github.com/juliankgp/Logistica-ShoppingCar) | GET|
| GetPedido | [*api/Pedido/GetPedido*](https://github.com/juliankgp/Logistica-ShoppingCar) |GET|
| GuardarPedido | [*api/Pedido/GuardarPedido*](https://github.com/juliankgp/Logistica-ShoppingCar) | POST	|
