namespace LotusCatering.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class CategoryAddInputModel
    {
        [Required(ErrorMessage = "Трябва да въведете име!")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Трябва да веведете описание!")]
        [MaxLength(150)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
