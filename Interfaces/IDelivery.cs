using System;
using Sprint3_microservice.Models;


namespace Sprint3_microservice.Interfaces
{
    public interface IDelivery 
    {
            
        Task<List<Delivery>> GetAllDeliveries();

    }
}

