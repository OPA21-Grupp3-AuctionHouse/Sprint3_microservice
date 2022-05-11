using System;
using Microsoft.EntityFrameworkCore;
using Sprint3_microservice.Data;
using Sprint3_microservice.Interfaces;
using Sprint3_microservice.Models;


namespace Sprint3_microservice.Services
{
    public class DeliveryService : IDelivery
    {
        private ApiDbContext dbContext;

        public DeliveryService()
        {
            dbContext = new ApiDbContext();
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            var deliveries = await dbContext.Deliveries.ToListAsync();

            return deliveries;
        }

        public async Task AddDelivery(Delivery delivery)
        {
            await dbContext.Deliveries.AddAsync(delivery);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            var delivery = await dbContext.Deliveries.FindAsync(id);

            return delivery;
        }
    }
}
