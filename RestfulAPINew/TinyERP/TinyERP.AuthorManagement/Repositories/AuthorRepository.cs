using System.Linq;
using TinyERP.AuthorManagement.Dtos;
using TinyERP.AuthorManagement.Entities;
using TinyERP.Common;
using TinyERP.Common.Contexts;
using TinyERP.Common.Repositories;

namespace TinyERP.AuthorManagement.Repositories
{
    public class AuthorRepository : BaseRepository<AuthorAggregateRoot>, IAuthorRepository
    {
        public AuthorRepository() : base()
        {

        }

        public AuthorRepository(IBaseContext context, ContextMode contextMode = ContextMode.Read) : base(context, contextMode)
        {

        }

        public bool CheckExistedByEmail(string email, int excludeId)
        {
            return this.dbSet.AsQueryable().Any(item => item.Email == email && item.Id != excludeId);
        }
    }
}
