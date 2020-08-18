using System;
using System.Threading.Tasks;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public interface IUserFacade
    {
        Task<Guid> CreateIfNotExist(CreateAuthorDto createAuthor);
        Task<AuthorInfo> GetAuthor(Guid id);
    }
}
