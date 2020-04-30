namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CartTests
    {
        private readonly CartService cartService;

        private IRepository<Cart> cartRepository;
        private IDeletableEntityRepository<ApplicationUser> userRepository;
        private IDeletableEntityRepository<Category> categoryRepository;
        private IDeletableEntityRepository<Tab> tabRepository;
        private IDeletableEntityRepository<Item> itemRepository;
        private IApplicationDbContext dbRepository;

        private Cart testCart1;
        private Cart testCart2;

        private CartItem testCartItem1;
        private CartItem testCartItem2;

        private ApplicationUser testUser1;
        private ApplicationUser testUser2;

        private Item testItem1;
        private Item testItem2;
        private Item testItem3;

        private Tab testTab1;
        private Tab testTab2;

        private Category testCategory1;
        private Category testCategory2;

        public CartTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.SeedUsers();
            this.SeedCategories();
            this.SeedTabs();
            this.SeedItems();
            this.InitializeCartItems();
            this.InitializeFields();
            this.cartService = new CartService(this.dbRepository, this.cartRepository);
        }

        [Fact]
        public async void CartAddItemAsyncShouldAddSuccessfully()
        {
            await this.SeedDatabase();

            var result = await this.cartService.AddItemAsync(
                this.testCart1.Id,
                this.testItem1.Id,
                20);

            Assert.True(result);
        }

        [Fact]
        public async void CartAddItemQuantityAsyncShouldAddSuccessfully()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.AddItemQuantityAsync(
                this.testCart1.Id,
                this.testItem1.Id,
                20);

            Assert.True(result);
        }

        [Fact]
        public async void CartAddItemQuantityAsyncShouldNotAddSuccessfully()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.AddItemQuantityAsync(
                this.testCart1.Id,
                this.testItem1.Id,
                700);

            Assert.False(result);
        }

        [Fact]
        public async void CartEditItemAsyncShouldEditSuccessfully()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.EditItemAsync(
                this.testCart1.Id,
                this.testItem1.Id,
                50);

            Assert.True(result);
        }

        [Fact]
        public async void CartEditItemAsyncShouldNotEditSuccessfully()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.EditItemAsync(
                this.testCart1.Id,
                this.testItem1.Id,
                500);

            Assert.False(result);
        }

        [Fact]
        public async void CartGetCartItemsShouldNotGetThemRight()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.GetCartItemsByUserId(this.testUser1.Id).ToArray();

            Assert.Equal(this.testItem1.Id, result[1].Id);
            Assert.Equal(this.testItem1.Price, result[1].Price);


            Assert.Equal(2, result.Length);
        }

        [Fact]
        public async void CartGetQuantityShouldReturnRight()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.GetQuantity(this.testCart1.Id, this.testItem1.Id);

            Assert.Equal(10, result);
        }

        [Fact]
        public async void CartGetTotalQuantityShouldReturnRight()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.GetTotalQuantity(this.testCart1.Id);

            Assert.Equal(30, result);
        }

        [Fact]
        public async void CartGetTotalPriceShouldReturnRight()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.GetTotalPrice(this.testCart1.Id);

            Assert.Equal(50, result);
        }

        [Fact]
        public async void CartIsItemInShouldReturnTrue()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.IsItemInCart(this.testCart1.Id, this.testItem1.Id);

            Assert.True(result);
        }

        [Fact]
        public async void CartIsItemInShouldReturnFalse()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = this.cartService.IsItemInCart(this.testCart1.Id, "Invalid");

            Assert.False(result);
        }

        [Fact]
        public async void CartRemoveAllAsyncShouldRemoveAllItems()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.RemoveAllItemsAsync(this.testCart1.Id);
            var secondResult = this.cartService.GetCartItemsByUserId(this.testUser1.Id).Count();

            Assert.True(result);

            Assert.Equal(0, secondResult);
        }

        [Fact]
        public async void CartRemoveItemAsyncShouldRemoveItem()
        {
            await this.SeedDatabase();
            await this.SeedDatabaseCartItems();

            var result = await this.cartService.RemoveItemAsync(this.testCart1.Id, this.testItem2.Id);
            var secondResult = this.cartService.GetCartItemsByUserId(this.testUser1.Id).Count();

            Assert.True(result);

            Assert.Equal(1, secondResult);
        }

        private void InitializeCartItems()
        {
            this.testCartItem1 = new CartItem
            {
                CartId = "1",
                ItemId = "1",
                Quantity = 10,
            };

            this.testCartItem2 = new CartItem
            {
                CartId = "1",
                ItemId = "2",
                Quantity = 20,
            };
        }

        private async void SeedUsers()
        {
            this.testUser1 = new ApplicationUser
            {
                Id = "1",
                Email = "first@gmail.com",
                PasswordHash = "password",
            };

            this.testUser2 = new ApplicationUser
            {
                Id = "2",
                Email = "second@gmail.com",
                PasswordHash = "password",
            };

            await this.userRepository.AddAsync(this.testUser1);
            await this.userRepository.AddAsync(this.testUser2);

            await this.userRepository.SaveChangesAsync();
        }

        private async void SeedCategories()
        {
            this.testCategory1 = new Category
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
            };

            this.testCategory2 = new Category
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
            };

            await this.categoryRepository.AddAsync(this.testCategory1);
            await this.categoryRepository.AddAsync(this.testCategory2);

            await this.categoryRepository.SaveChangesAsync();
        }

        private async void SeedTabs()
        {
            this.testTab1 = new Tab
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
                CategoryId = "1",
            };

            this.testTab2 = new Tab
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
                CategoryId = "1",
            };

            await this.tabRepository.AddAsync(this.testTab1);
            await this.tabRepository.AddAsync(this.testTab2);

            await this.tabRepository.SaveChangesAsync();
        }

        private async void SeedItems()
        {
            this.testItem1 = new Item
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
                Price = 1,
                TabId = "1",
            };

            this.testItem2 = new Item
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
                Price = 2,
                TabId = "1",
            };

            this.testItem3 = new Item
            {
                Id = "3",
                Name = "Name3",
                Description = "Description3",
                ImageUrl = "Image3",
                TabId = "2",
                Price = 3,
                IsDeleted = true,
            };

            await this.itemRepository.AddAsync(this.testItem1);
            await this.itemRepository.AddAsync(this.testItem2);
            await this.itemRepository.AddAsync(this.testItem3);

            await this.itemRepository.SaveChangesAsync();
        }

        private async Task SeedDatabaseCartItems()
        {
            await this.dbRepository.CartItems.AddAsync(this.testCartItem1);
            await this.dbRepository.CartItems.AddAsync(this.testCartItem2);

            await this.dbRepository.SaveChangesAsync();
        }


        private async Task SeedDatabase()
        {
            await this.cartRepository.AddAsync(this.testCart1);
            await this.cartRepository.AddAsync(this.testCart2);

            await this.cartRepository.SaveChangesAsync();
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.cartRepository = new EfRepository<Cart>(dbContext);
            this.userRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);
            this.categoryRepository = new EfDeletableEntityRepository<Category>(dbContext);
            this.tabRepository = new EfDeletableEntityRepository<Tab>(dbContext);
            this.itemRepository = new EfDeletableEntityRepository<Item>(dbContext);

            this.dbRepository = dbContext;
        }

        private void InitializeFields()
        {
            this.testCart1 = new Cart
            {
                Id = "1",
                UserId = this.testUser1.Id,
            };

            this.testCart2 = new Cart
            {
                Id = "2",
                UserId = this.testUser2.Id,
            };
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
