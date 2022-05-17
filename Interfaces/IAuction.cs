using Sprint3_microservice.Models;

namespace Sprint3_microservice.Interfaces
{
    public interface IAuction
    {
        Task AddAuction(Auction auction);

        Task<List<Auction>> GetAllAuctions();
    }
}
