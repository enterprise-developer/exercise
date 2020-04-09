using System.Threading.Tasks;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public interface IUserFacade
    {
        Task<int> CreateIfNotExist(CreateAuthorDto createAuthor);
        Task<AuthorInfo> GetAuthor(int id);
    }
}
