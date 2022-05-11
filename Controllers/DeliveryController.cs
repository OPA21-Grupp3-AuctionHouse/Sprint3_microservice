using Microsoft.AspNetCore.Mvc;
using Sprint3_microservice.Interfaces;
using Sprint3_microservice.Models;

namespace Sprint3_microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {
        public IDelivery _deliveryService;

        public DeliveryController(IDelivery deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Delivery>> Get()
        {
            var deliveries = await _deliveryService.GetAllDeliveries();

            return deliveries;
        }

    }
}
