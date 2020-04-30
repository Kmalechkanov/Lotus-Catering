namespace LotusCatering.Web.ViewModels.CartItems
{
    using LotusCatering.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CartItemInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessageRequiredField)]
        public string ItemId { get; set; }

        [Display(Name = GlobalConstants.DisplayQuantity)]
        [Range(GlobalConstants.RangeMinQuantity, GlobalConstants.RangeMaxQuantity)]
        public int Quantity { get; set; }
    }
}
