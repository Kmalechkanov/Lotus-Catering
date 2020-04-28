namespace LotusCatering.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext dbContext;

        public OrderService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> AddAsync(DateTime paymentDate, DateTime deliveryDate, string cartId, string userId, string additionalInformation)
        {
            var order = new Order
            {
                PaymentDate = paymentDate,
                DeliveryDate = deliveryDate,
                UserId = userId,
                AdditionalInformation = additionalInformation.Trim(),
            };

            var orderItems = this.dbContext
                .CartItems
                .Where(ci => ci.CartId == cartId && ci.Item.IsDeleted == false)
                .Select(ci => new OrderItem
                {
                    OrderId = order.Id,
                    ItemId = ci.ItemId,
                    Quantity = ci.Quantity,
                }).ToArray();

            double totalPrice = this.dbContext.CartItems
                .Where(ci => ci.CartId == cartId && ci.Item.IsDeleted == false)
                .Sum(ci => (ci.Item.Price * ci.Quantity));

            order.TotalPrice = totalPrice;

            await this.dbContext.OrderItems.AddRangeAsync(orderItems);
            await this.dbContext.Orders.AddAsync(order);

            await this.dbContext.SaveChangesAsync();

            return order.Id;
        }

        public IEnumerable<T> GetAll<T>(string userId)
            => this.dbContext.Orders.Where(o => o.UserId == userId).To<T>();

        public T GetById<T>(string id)
            => this.dbContext.Orders.Where(o => o.Id == id).To<T>().FirstOrDefault();
    }
}
