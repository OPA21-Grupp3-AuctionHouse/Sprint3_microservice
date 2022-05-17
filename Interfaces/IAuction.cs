using Sprint3_microservice.Models;

namespace Sprint3_microservice.Interfaces
{
    public interface IAuction
    {
        Task AddAuction(Auction auction);

        Task<Auction> GetAuctionById(string AuctionId);

        Task<List<Auction>> GetAllAuctions();
    }
}
