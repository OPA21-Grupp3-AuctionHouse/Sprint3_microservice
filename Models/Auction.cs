namespace Sprint3_microservice.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public string AuctionId { get; set; }

        public string UserId { get; set; }

        public string deliveryMethod { get; set; }

        public DateTime date { get; set; }

        public string address { get; set; }
    }
}
