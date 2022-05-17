using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sprint3_microservice.Interfaces;
using Sprint3_microservice.Models;

namespace Sprint3_microservice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : Controller
    {
        public IAuction _AuctionService;

        public AuctionController(IAuction auctionService)
        {
            _AuctionService = auctionService;
        }

        [HttpPost("createAuction")]
        public async Task Post([FromBody] Auction auction)
        {
            await _AuctionService.AddAuction(auction);
        }

        [HttpGet]
        public async Task<IEnumerable<Auction>> Get()
        {
            var auctions = await _AuctionService.GetAllAuctions();

            return auctions;
        }
    }
}
