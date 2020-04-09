namespace AnisMasterpieces.Web.ViewModels.Items
{
    using System.Collections.Generic;

    public class ItemSelectViewModel
    {
        public string Id { get; set; }

        public ICollection<ItemIdNameViewModel> Items { get; set; }
    }
}
