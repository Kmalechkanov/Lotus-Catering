namespace LotusCatering.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    using LotusCatering.Common;
    using Microsoft.AspNetCore.Http;

    public class CategoryAddInputModel
    {
        [Display(Name = GlobalConstants.DisplayName)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredName)]
        [MaxLength(GlobalConstants.MaxLengthName)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.DisplayDescription)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredDescription)]
        [MaxLength(GlobalConstants.MaxLengthDescription)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
