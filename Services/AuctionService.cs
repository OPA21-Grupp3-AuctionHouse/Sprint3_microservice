using Microsoft.EntityFrameworkCore;
using Sprint3_microservice.Data;
using Sprint3_microservice.Interfaces;
using Sprint3_microservice.Models;

namespace Sprint3_microservice.Services
{
    public class AuctionService : IAuction
    {
        private ApiDbContext dbContext;

        public AuctionService()
        {
            dbContext = new ApiDbContext();
        }

        public async Task AddAuction(Auction auction)
        {
            DateTime dateTime = DateTime.Now;
            auction.date = dateTime;
            await dbContext.Auctions.AddAsync(auction);
            await dbContext.SaveChangesAsync();
        }
        
        public async Task<Auction> GetAuctionById(string AuctionId)
        {
            Auction auction = dbContext.Auctions.SingleOrDefault(auction => auction.AuctionId == AuctionId);
            return auction;
        }

        public async Task<List<Auction>> GetAllAuctions()
        {
            var auctions = await dbContext.Auctions.ToListAsync();

            return auctions;
        }
    }
}
