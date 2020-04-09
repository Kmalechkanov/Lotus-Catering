namespace LotusCatering.Web.ViewModels.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Http;

    public class ItemAddInputModel
    {
        [Required(ErrorMessage = "Трябва да въведете име!")]
        [MaxLength(30, ErrorMessage = "Името трябва да е по-малко от 30 символа!")]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Трябва да въведете цена!")]
        [Range(0.01, 10000, ErrorMessage = "Цената трябва да е между 0.01 и 10000!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Трябва да изберете подкатегория!")]
        public string TabId { get; set; }

        [Required(ErrorMessage = "Трябва да веведете описание!")]
        public string Description { get; set; }

        public IEnumerable<TabIdNameViewModel> Tabs { get; set; }
    }
}
