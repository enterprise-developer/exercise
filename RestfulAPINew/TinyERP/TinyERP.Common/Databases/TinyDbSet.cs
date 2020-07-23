using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace TinyERP.Common.Databases
{
    public class TinyDbSet<TEntity> where TEntity : class
    {
        private DbSet<TEntity> dbSet;
        private ContextMode mode;
        public TinyDbSet(DbSet<TEntity> dbSet, ContextMode mode)
        {
            this.dbSet = dbSet;
            this.mode = mode;
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public IQueryable<TEntity> AsQueryable(string include = "")
        {
            DbQuery<TEntity> dbQuery = this.mode == ContextMode.Read ? dbSet.AsNoTracking() : dbSet;

            if (!string.IsNullOrWhiteSpace(include))
            {
                IList<string> includeNames = include.Split(',');
                foreach (string includeName in includeNames)
                {
                    dbQuery = dbQuery.Include(includeName.Trim());
                }
            }
            return dbQuery;
        }
    }
}
