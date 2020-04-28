namespace LotusCatering.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class ContactsViewModel
    {
        [Required(ErrorMessage = "Трябва да въведете тема!")]
        [MinLength(2, ErrorMessage = "Темата трябва да бъде минимум 2 символа!")]
        [MaxLength(50, ErrorMessage = "Темата трябва да бъде максимум 50 символа!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Трябва да въведете име!")]
        [MinLength(2, ErrorMessage = "Името трябва да бъде минимум 2 символа!")]
        [MaxLength(50, ErrorMessage = "Името трябва да бъде максимум 50 символа!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Трябва да въведете поща!")]
        [EmailAddress(ErrorMessage = "Невалидна поща!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Трябва да въведете телефонен номер!")]
        [Phone(ErrorMessage = "Невалиден номер!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Трябва да въведете текст!")]
        [MinLength(10, ErrorMessage = "Текста трябва да бъде минимум 10 символа!")]
        [MaxLength(500, ErrorMessage = "Текста трябва да бъде максимум 500 символа!")]
        public string Text { get; set; }
    }
}
