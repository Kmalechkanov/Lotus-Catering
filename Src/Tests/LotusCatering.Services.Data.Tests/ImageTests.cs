namespace LotusCatering.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using LotusCatering.Data;
    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Data.Repositories;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Images;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ImageTests
    {
        private ImageService imageService;

        private IDeletableEntityRepository<Image> imageRepository;
        private IDeletableEntityRepository<Gallery> galleryRepository;

        private Image testImage1;
        private Image testImage2;
        private Image testImage3;

        private Gallery testGallery1;
        private Gallery testGallery2;

        public ImageTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.SeedGalleries();
            this.InitializeFields();
            this.imageService = new ImageService(this.imageRepository, this.galleryRepository);
        }

        [Fact]
        public async Task ImageAddAsyncShouldAdd()
        {
            await this.imageService.AddAsync(
                "Name3",
                "Image3",
                this.testGallery1.Id,
                "Description3");
            var count = this.imageRepository.All().Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task ImageDeleteAsyncShouldDelete()
        {
            await this.SeedDatabase();

            var countBefore = this.imageRepository.All().Count();
            var response = await this.imageService.DeleteAsync(this.testImage1.Id);
            var countAfter = this.imageRepository.All().Count();

            Assert.Equal(countBefore, countAfter + 1);

            Assert.True(response);
        }

        [Fact]
        public async Task ImageDeleteAsyncShouldDoNothingOnInvalidId()
        {
            await this.SeedDatabase();

            var countBefore = this.imageRepository.All().Count();
            var response = await this.imageService.DeleteAsync("invalid");
            var countAfter = this.imageRepository.All().Count();

            Assert.Equal(countBefore, countAfter);

            Assert.False(response);
        }

        [Fact]
        public async Task ImageGetAllShouldReturnAll()
        {
            await this.SeedDatabase();

            var response = this.imageService.GetAll<ImageBasicViewModel>(this.testGallery1.Id).ToArray();

            Assert.Equal(2, response.Length);
        }


        [Fact]
        public async Task ImageGetByWrongIdShouldReturnNothing()
        {
            await this.SeedDatabase();

            var response = this.imageService.GetAll<ImageBasicViewModel>("invalid").ToArray();

            const int expected = 0;
            var actual = response.Length;

            Assert.Equal(expected, actual);
        }

        private async void SeedGalleries()
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

            await this.galleryRepository.AddAsync(this.testGallery1);
            await this.galleryRepository.AddAsync(this.testGallery2);
            await this.galleryRepository.SaveChangesAsync();
        }

        private async Task SeedDatabase()
        {
            await this.imageRepository.AddAsync(this.testImage1);
            await this.imageRepository.AddAsync(this.testImage2);
            await this.imageRepository.AddAsync(this.testImage3);
            await this.imageRepository.SaveChangesAsync();
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.imageRepository = new EfDeletableEntityRepository<Image>(dbContext);
            this.galleryRepository = new EfDeletableEntityRepository<Gallery>(dbContext);
        }

        private void InitializeFields()
        {
            this.testImage1 = new Image
            {
                Id = "1",
                Name = "Name1",
                Description = "Description1",
                ImageUrl = "Image1",
                GalleryId = "1",
            };

            this.testImage2 = new Image
            {
                Id = "2",
                Name = "Name2",
                Description = "Description2",
                ImageUrl = "Image2",
                GalleryId = "1",
            };

            this.testImage3 = new Image
            {
                Id = "3",
                Name = "Name3",
                Description = "Description3",
                ImageUrl = "Image3",
                GalleryId = "2",
                IsDeleted = true,
            };
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("LotusCatering.Web.ViewModels"));
    }
}
