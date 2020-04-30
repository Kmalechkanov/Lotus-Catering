namespace LotusCatering.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task<string> AddAsync(DateTime paymentDate, DateTime deliveryDate, string cartId, string userId, string additionalInformation);

        IEnumerable<T> GetAll<T>(string userId);

        T GetById<T>(string id);

        IEnumerable<T> GetAllItems<T>(string id);
    }
}
