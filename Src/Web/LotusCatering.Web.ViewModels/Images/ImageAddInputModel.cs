namespace LotusCatering.Web.ViewModels.Images
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Web.ViewModels.Galleries;
    using Microsoft.AspNetCore.Http;

    public class ImageAddInputModel
    {
        [Required(ErrorMessage = "Трябва да въведете име!")]
        [MaxLength(30, ErrorMessage = "Името трябва да е по-малко от 30 символа!")]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Трябва да изберете галерия!")]
        public string GalleryId { get; set; }

        [MaxLength(30, ErrorMessage = "Описанието трябва да е по-малко от 150 символа!")]
        public string Description { get; set; }

        public IEnumerable<GalleryIdNameViewModel> Galleries { get; set; }
    }
}
