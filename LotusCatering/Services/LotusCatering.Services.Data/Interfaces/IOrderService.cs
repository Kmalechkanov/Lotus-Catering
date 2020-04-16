namespace LotusCatering.Services.Data.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task<string> AddAsync(DateTime paymentDate, DateTime deliveryDate, string cartId, string userId, string additionalInformation);
    }
}
