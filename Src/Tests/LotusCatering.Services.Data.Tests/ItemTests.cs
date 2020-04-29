namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Items;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ItemTests
    {
        private readonly ItemService itemService;

        private EfDeletableEntityRepository<Item> itemRepository;
        private EfDeletableEntityRepository<Tab> tabRepository;
        private EfDeletableEntityRepository<Category> categoryRepository;

        private Item testItem1;
        private Item testItem2;
        private Item testItem3;

        private Tab testTab1;
        private Tab testTab2;

        private Category testCategory1;
        private Category testCategory2;

        public ItemTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.SeedCategories();
            this.SeedTabs();
            this.InitializeFields();
            this.itemService = new ItemService(this.itemRepository, this.tabRepository);
        }

        [Fact]
        public async Task ItemAddAsyncShouldAdd()
        {
            await this.itemService.AddAsync(
                "Name3",
                "Image3",
                1.2,
                this.testTab1.Id,
                "Description3");
            var count = this.itemRepository.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task ItemDeleteAsyncShouldDelete()
        {
            await this.SeedDatabase();

            var countBefore = this.itemRepository.All().Count();
            var response = await this.itemService.DeleteAsync(this.testItem1.Id);
            var countAfter = this.itemRepository.All().Count();

            Assert.Equal(countBefore, countAfter + 1);

            Assert.True(response);
        }

        [Fact]
        public async Task ItemIsValidIdShouldReturnTrue()
        {
            await this.SeedDatabase();

            var response = this.itemService.IsValidId(this.testItem1.Id);

            Assert.True(response);
        }

        [Fact]
        public async Task ItemIsValidIdShouldReturnFalseOnInvalidId()
        {
            await this.SeedDatabase();

            var response = this.itemService.IsValidId("invalid");

            Assert.False(response);
        }

        [Fact]
        public async Task ItemDeleteAsyncShouldDoNothingOnInvalidId()
        {
            await this.SeedDatabase();

            var countBefore = this.itemRepository.All().Count();
            var response = await this.itemService.DeleteAsync("invalid");
            var countAfter = this.itemRepository.All().Count();

            Assert.Equal(countBefore, countAfter);

            Assert.False(response);
        }

        [Fact]
        public async Task ItemGetAllShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.itemService.GetAll<ItemIdNameViewModel>().ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task ItemGetAllByTabIdShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.itemService.GetAllByTabId<ItemIdNameViewModel>(this.testTab1.Id).ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task ItemGetByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.itemService.GetById<ItemIdNameViewModel>(this.testItem1.Id);

            Assert.Equal(this.testItem1.Id, response.Id);
            Assert.Equal(this.testItem1.Name, response.Name);
        }

        [Fact]
        public async Task ItemGetNameByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.itemService.GetName(this.testItem1.Id);

            Assert.Equal(this.testItem1.Name, response);
        }

        [Fact]
        public async Task ItemUpdateAsyncShouldUpdateData()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";
            const double price = 2.2;
            var tabId = this.testTab2.Id;

            var response = await this.itemService.UpdateAsync(this.testItem1.Id, name, price, tabId, description);
            var updated = this.itemService.GetById<Item>(this.testItem1.Id);

            Assert.True(response);

            Assert.Equal(this.testItem1.Id, updated.Id);
            Assert.Equal(name, updated.Name);
            Assert.Equal(price, updated.Price);
            Assert.Equal(description, updated.Description);
            Assert.Equal(tabId, updated.TabId);
        }

        [Fact]
        public async Task ItemUpdateAsyncShouldNotUpdateWhenInvalidTabId()
        {
            await this.SeedDatabase();

            const string name = "newName";
            const string description = "newDescription";
            const double price = 2.2;
            const string tabId = "invalid";

            var response = await this.itemService.UpdateAsync(this.testItem1.Id, name, price, tabId, description);
            var updated = this.itemService.GetById<Item>(this.testItem1.Id);

            Assert.False(response);

            Assert.Equal(this.testItem1.Id, updated.Id);
            Assert.NotEqual(name, updated.Name);
            Assert.NotEqual(price, updated.Price);
            Assert.NotEqual(description, updated.Description);
            Assert.NotEqual(tabId, updated.TabId);
        }

        [Fact]
        public async Task ItemUpdateAsyncShouldNotUpdateOnWrongId()
        {
            await this.SeedDatabase();

            const string id = "invalid";
            const string name = "newName";
            const string description = "newDescription";
            const double price = 2.2;

            var response = await this.itemService.UpdateAsync(id, name, price, this.testTab2.Id, description);

            Assert.False(response);
        }

        [Fact]
        public async Task ItemUpdateImageAsyncShouldUpdateImage()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.itemService.UpdateImageAsync(this.testItem1.Id, imageUrl);
            var updated = this.itemService.GetById<Item>(this.testItem1.Id);

            Assert.True(response);

            Assert.Equal(imageUrl, updated.ImageUrl);
            Assert.Equal(this.testItem1.Id, updated.Id);
        }

        [Fact]
        public async Task ItemUpdateImageAsyncShouldNotUpdateImageOnWrongId()
        {
            await this.SeedDatabase();

            const string imageUrl = "newImageUrl";

            var response = await this.itemService.UpdateImageAsync("invalid", imageUrl);

            Assert.False(response);
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

        private async Task SeedDatabase()
        {
            await this.itemRepository.AddAsync(this.testItem1);
            await this.itemRepository.AddAsync(this.testItem2);
            await this.itemRepository.AddAsync(this.testItem3);
            await this.itemRepository.SaveChangesAsync();
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.itemRepository = new EfDeletableEntityRepository<Item>(dbContext);
            this.tabRepository = new EfDeletableEntityRepository<Tab>(dbContext);
            this.categoryRepository = new EfDeletableEntityRepository<Category>(dbContext);
        }

        private void InitializeFields()
        {
            this.testItem1 = new Item
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
                Price = 2.32,
                TabId = "1",
            };

            this.testItem2 = new Item
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
                Price = 2.12,
                TabId = "1",
            };

            this.testItem3 = new Item
            {
                Id = "3",
                Name = "Name3",
                Description = "Description3",
                ImageUrl = "Image3",
                TabId = "2",
                Price = 1.32,
                IsDeleted = true,
            };
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
