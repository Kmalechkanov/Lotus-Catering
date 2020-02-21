namespace AnisMasterpieces.Data
{
    using AnisMasterpieces.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }
    }
}
