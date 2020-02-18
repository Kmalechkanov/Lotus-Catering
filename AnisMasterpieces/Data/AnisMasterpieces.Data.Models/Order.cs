namespace AnisMasterpieces.Data.Models
{
    using System;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PaymentDate = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}