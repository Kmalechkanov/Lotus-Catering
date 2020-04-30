namespace LotusCatering.Web.ViewModels.Contacts
{
    using LotusCatering.Common;
    using System.ComponentModel.DataAnnotations;

    public class ContactsViewModel
    {
        [Display(Name = GlobalConstants.DisplayTitle)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredTitle)]
        [MinLength(GlobalConstants.MinLengthTitle, ErrorMessage = GlobalConstants.ErrorMessageMinLengthTitle)]
        [MaxLength(GlobalConstants.MaxLengthTitle, ErrorMessage = GlobalConstants.ErrorMessageMaxLengthTitle)]
        public string Title { get; set; }

        [Display(Name = GlobalConstants.DisplayName)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredName)]
        [MinLength(GlobalConstants.MinLengthName, ErrorMessage = GlobalConstants.ErrorMessageMinLengthName)]
        [MaxLength(GlobalConstants.MaxLengthName, ErrorMessage = GlobalConstants.ErrorMessageMinLengthName)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.DisplayEmail)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredEmail)]
        [EmailAddress(ErrorMessage = GlobalConstants.ErrorMessageInvalidEmail)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.DisplayPhone)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredPhone)]
        [Phone(ErrorMessage = GlobalConstants.ErrorMessageInvalidPhone)]
        public string PhoneNumber { get; set; }

        [Display(Name = GlobalConstants.DisplayText)]
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredText)]
        [MinLength(GlobalConstants.MinLengthText, ErrorMessage = GlobalConstants.ErrorMessageMinLengthTitle)]
        [MaxLength(GlobalConstants.MaxLengthText, ErrorMessage = GlobalConstants.ErrorMessageMaxLengthTitle)]
        public string Text { get; set; }
    }
}
