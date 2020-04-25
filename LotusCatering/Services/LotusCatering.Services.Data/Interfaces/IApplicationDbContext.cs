namespace LotusCatering.Services.Data.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext
    {
        DbSet<Tab> Tabs { get; set; }

        DbSet<OrderItem> OrderItems { get; set; }

        DbSet<CartItem> CartItems { get; set; }

        DbSet<Cart> Carts { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Gallery> Galleries { get; set; }

        DbSet<GalleryImage> GalleryImages { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
