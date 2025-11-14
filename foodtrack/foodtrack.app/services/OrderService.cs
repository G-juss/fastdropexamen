using FoodTrack.Domain;
using FoodTrack.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrack.Services
{
    public class OrderService
    {
        public Guid RegistrarOrden(Guid foodTruckId, List<Item> items)
        {
            var order = new Order
            {
                FoodTruckId = foodTruckId,
                Items = items
            };

            InMemoryData.Orders.Add(order);
            return order.Id;
        }

        public Order? ObtenerOrden(Guid id)
        {
            return InMemoryData.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> ListarPorFoodTruck(Guid foodTruckId)
        {
            return InMemoryData.Orders
                .Where(o => o.FoodTruckId == foodTruckId)
                .ToList();
        }

        public void CambiarEstado(Guid id, OrderState estado)
        {
            var orden = ObtenerOrden(id);
            if (orden != null)
            {
                orden.Estado = estado;
            }
        }
    }
}
