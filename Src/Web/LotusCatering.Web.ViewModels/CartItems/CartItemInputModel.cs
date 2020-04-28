namespace LotusCatering.Web.ViewModels.CartItems
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CartItemInputModel
    {
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string ItemId { get; set; }

        [Range(10, 200)]
        public int Quantity { get; set; }
    }
}
