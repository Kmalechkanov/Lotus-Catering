namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITabService
    {
        IEnumerable<string> GetAll();
    }
}
