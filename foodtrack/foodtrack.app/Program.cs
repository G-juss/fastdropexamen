using FoodTrack.Domain;
using FoodTrack.Repositories;
using FoodTrack.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var foodTruck = new FoodTruck
        {
            Id = Guid.NewGuid(),
            Nombre = "Baleadas la bendición",
            UbicacionActual = "Barrio Copén"
        };

        InMemoryData.FoodTrucks.Add(foodTruck);

        var servicio = new OrderService();

        var items = new List<Item>
        {
            new Item { Nombre = "Baleada", Precio = 1.50m, Cantidad = 3 },
            new Item { Nombre = "Fresco", Precio = 1.00m, Cantidad = 1 }
        };

        var idOrden = servicio.RegistrarOrden(foodTruck.Id, items);
        Console.WriteLine("Orden creada con ID: " + idOrden);

        var orden = servicio.ObtenerOrden(idOrden);
        Console.WriteLine("Total de la orden: " + orden!.Total);

        servicio.CambiarEstado(idOrden, OrderState.EnPreparacion);
        Console.WriteLine("Nuevo estado: " + servicio.ObtenerOrden(idOrden)!.Estado);
    }
}
