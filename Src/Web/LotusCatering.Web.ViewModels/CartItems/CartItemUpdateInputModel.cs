namespace LotusCatering.Web.ViewModels.CartItems
{
    public class CartItemUpdateInputModel
    {
        public string ItemId { get; set; }

        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }
    }
}
