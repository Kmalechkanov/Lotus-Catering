namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Galleries;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class GalleryTests
    {
        private GalleryService galleryService;

        private EfDeletableEntityRepository<Gallery> galleryRepository;

        private Gallery testGallery1;
        private Gallery testGallery2;
        private Gallery testGallery3;

        public GalleryTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.InitializeFields();
            this.galleryService = new GalleryService(this.galleryRepository);
        }

        [Fact]
        public async Task GalleryAddAsyncShouldAdd()
        {
            await this.galleryService.AddAsync(
                "Name3");
            var count = this.galleryRepository.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task GalleryDeleteAsyncShouldDelete()
        {
            await this.SeedDatabase();

            var countBefore = this.galleryRepository.All().Count();
            var response = await this.galleryService.DeleteAsync(this.testGallery1.Id);
            var countAfter = this.galleryRepository.All().Count();

            Assert.Equal(countBefore, countAfter + 1);

            Assert.True(response);
        }

        [Fact]
        public async Task GalleryDeleteAsyncShouldDoNothingOnInvalidId()
        {
            await this.SeedDatabase();

            var countBefore = this.galleryRepository.All().Count();
            var response = await this.galleryService.DeleteAsync("43");
            var countAfter = this.galleryRepository.All().Count();

            Assert.Equal(countBefore, countAfter);

            Assert.True(!response);
        }

        [Fact]
        public async Task GalleryGetAllShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.galleryService.GetAll<GalleryIdNameViewModel>().ToArray();

            Assert.Equal(2, response.Length);
        }

        [Fact]
        public async Task GalleryGetByIdShouldReturnProperly()
        {
            await this.SeedDatabase();

            var response = this.galleryService.GetById<GalleryIdNameViewModel>(this.testGallery1.Id);

            Assert.Equal(this.testGallery1.Id, response.Id);
            Assert.Equal(this.testGallery1.Name, response.Name);
        }

        [Fact]
        public async Task GalleryIsInvalidIdShouldReturnTrue()
        {
            await this.SeedDatabase();

            var response = this.galleryService.IsValidId(this.testGallery1.Id);

            Assert.True(response);
        }

        [Fact]
        public async Task GalleryIsInvalidIdShouldReturnFalseWhenInvalid()
        {
            await this.SeedDatabase();

            var response = this.galleryService.IsValidId("43");

            Assert.False(response);
        }

        [Fact]
        public async Task GalleryUpdateAsyncShouldUpdateData()
        {
            await this.SeedDatabase();

            const string name = "newName";

            var response = await this.galleryService.UpdateAsync(this.testGallery1.Id, name);
            var updated = this.galleryService.GetById<GalleryIdNameViewModel>(this.testGallery1.Id);

            Assert.True(response);

            Assert.Equal(this.testGallery1.Id, updated.Id);
            Assert.Equal(name, updated.Name);
        }

        [Fact]
        public async Task GalleryUpdateAsyncShouldNotUpdateOnWrongId()
        {
            await this.SeedDatabase();

            const string name = "newName";

            var response = await this.galleryService.UpdateAsync("43", name);

            Assert.False(response);
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.galleryRepository = new EfDeletableEntityRepository<Gallery>(dbContext);
        }

        private void InitializeFields()
        {
            this.testGallery1 = new Gallery
            {
                Id = "1",
                Name = "Name1",
            };

            this.testGallery2 = new Gallery
            {
                Id = "2",
                Name = "Name2",
            };

            this.testGallery3 = new Gallery
            {
                Id = "3",
                Name = "Name3",
                IsDeleted = true,
            };
        }

        private async Task SeedDatabase()
        {
            await this.galleryRepository.AddAsync(this.testGallery1);
            await this.galleryRepository.AddAsync(this.testGallery2);
            await this.galleryRepository.AddAsync(this.testGallery3);
            await this.galleryRepository.SaveChangesAsync();
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
