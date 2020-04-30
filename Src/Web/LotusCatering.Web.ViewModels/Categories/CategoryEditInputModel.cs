namespace LotusCatering.Web.ViewModels.Categories
{
    using LotusCatering.Common;
    using System.ComponentModel.DataAnnotations;

    public class CategoryEditInputModel
    {
        public string Id { get; set; }

        [Display(Name = GlobalConstants.DisplayName)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredName)]
        [MaxLength(GlobalConstants.MaxLengthName)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.DisplayDescription)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredDescription)]
        [MaxLength(GlobalConstants.MaxLengthLargerDescription)]
        public string Description { get; set; }

        [Display(Name = GlobalConstants.DisplayImage)]
        public string ImageUrl { get; set; }
    }
}
