using Api.Logistica.Data.Context;
using Api.Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Logistica.Data
{
    public class DbInitializer
    {
        public static void Initialize(LogisticaContext context)
        {
            if (context.Database.EnsureCreated())
            {
                var Productos = new Producto[]
                {
                    new Producto{Descripcion="Juguete Helicoptero para niños mayores de 7 años, funciona a contro remoto.", Nombre="Helicoptero", Valor=500000, Cantidad=3, Image="assets/images/helicopter.svg" },
                    new Producto{Descripcion="Tablero de tiro al blanco para niños, incluye 3 dardos.", Nombre="Tiro al blanco", Valor=80000, Cantidad=5, Image="assets/images/target.svg" },
                    new Producto{Descripcion="Juguete bicicleta de montaña TREK Marlin 5 para niños mayoeres de 6 años.", Nombre="Bicicleta", Valor=150000, Cantidad=7, Image="assets/images/bicycle.svg" },
                    new Producto{Descripcion="Juguete Laptop HP para aprender a escribir.", Nombre="Laptop HP", Valor=260000, Cantidad=8, Image="assets/images/laptop.svg" },
                    new Producto{Descripcion="Juguete Scooter Vespa, edicion especial LUKA.", Nombre="Scooter Vespa", Valor=460000, Cantidad=1, Image="assets/images/scooter.svg" },
                    new Producto{Descripcion="Juguete panel solar, para aprender del funcionamiento de un panel real.", Nombre="Panel Solar Mini", Valor=1250600, Cantidad=2, Image="assets/images/solar-energy.svg" },
                };
                foreach (Producto s in Productos)
                {
                    context.Producto.Add(s);
                }
                context.SaveChanges();
            }
        }
    }
}
