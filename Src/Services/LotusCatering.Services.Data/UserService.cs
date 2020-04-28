namespace LotusCatering.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepositoty;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepositoty)
        {
            this.userRepositoty = userRepositoty;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = this.userRepositoty.All().FirstOrDefault(u => u.Id == id);
            user.IsDeleted = true;
            user.NormalizedEmail = "DELETED";
            user.DeletedOn = DateTime.UtcNow;
            user.PhoneNumber = null;
            user.UserName = "DELETED";
            user.NormalizedUserName = "DELETED";
            user.Email = "DELETED";
            user.NormalizedEmail = "DELETED";
            user.PasswordHash = "NONE";

            var reponse = await this.userRepositoty.SaveChangesAsync();
            return reponse != 0;
        }

        public bool IsDeleted(string id)
            => this.userRepositoty.AllWithDeleted().FirstOrDefault(u => u.Id == id).IsDeleted == true;
    }
}
