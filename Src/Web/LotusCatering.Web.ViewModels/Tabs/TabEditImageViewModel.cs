namespace LotusCatering.Web.ViewModels.Tabs
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class TabEditImageViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
