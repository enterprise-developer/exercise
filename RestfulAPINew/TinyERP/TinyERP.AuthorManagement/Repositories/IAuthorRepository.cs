using TinyERP.AuthorManagement.Entities;
using TinyERP.Common.Repositories;

namespace TinyERP.AuthorManagement.Repositories
{
    public interface IAuthorRepository: IBaseRepository<AuthorAggregateRoot>
    {
        bool CheckExistedByEmail(string email, int excludeId);
    }
}
