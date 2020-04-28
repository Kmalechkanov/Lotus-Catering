namespace LotusCatering.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ItemEditImageViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
