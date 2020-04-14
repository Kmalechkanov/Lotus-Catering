namespace LotusCatering.Web.ViewModels.Tabs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;

    public class TabAddInputModel
    {
        [Required(ErrorMessage = "Трябва да въведете име!")]
        [MaxLength(30, ErrorMessage = "Името трябва да е по-малко от 30 символа!")]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Трябва да изберете категория!")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Трябва да веведете описание!")]
        public string Description { get; set; }

        public IEnumerable<CategoryIdNameViewModel> Categories { get; set; }
    }
}
