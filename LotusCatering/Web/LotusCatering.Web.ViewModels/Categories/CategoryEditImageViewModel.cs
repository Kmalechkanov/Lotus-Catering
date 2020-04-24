namespace LotusCatering.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CategoryEditImageViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
