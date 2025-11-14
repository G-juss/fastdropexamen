using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrack.Domain
{
    public class FoodTruck
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = "";
        public string UbicacionActual { get; set; } = "";
    }

    public class Item
    {
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FoodTruckId { get; set; }
        public List<Item> Items { get; set; } = new();
        public OrderState Estado { get; set; } = OrderState.Creada;
        public decimal Total => Items.Sum(i => i.Precio * i.Cantidad);
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
