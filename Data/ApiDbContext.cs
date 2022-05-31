using System;
using Microsoft.EntityFrameworkCore;
using Sprint3_microservice.Models;

namespace Sprint3_microservice.Data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Auction> Auctions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"Server=localhost;User Id=delivery-admin;Password=grupp3app;Database=Deliveries;Trusted_Connection=True;");

        }
    }
}
