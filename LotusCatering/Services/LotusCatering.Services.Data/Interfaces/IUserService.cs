namespace LotusCatering.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> DeleteAsync(string id);

        bool IsDeleted(string id);
    }
}
