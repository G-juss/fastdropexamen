using FoodTrack.Domain;
using System;
using System.Collections.Generic;

namespace FoodTrack.Repositories
{
    public static class InMemoryData
    {
        public static List<FoodTruck> FoodTrucks = new();
        public static List<Order> Orders = new();
    }
}
