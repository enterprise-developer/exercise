using TinyERP.UserManagement.Share.Dtos;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.UserManagement.Facade
{
    internal class UserFacade : IUserFacade
    {
        public int CreateIfNotExist(CreateAuthorDto createAuthor)
        {
            this.Validate(createAuthor);
            IUserRepository repository = IoC.Resolve<IUserRepository>();
            User user = new User() { 
                UserName = createAuthor.UserName,
                Name = createAuthor.Name,
                Birthday = createAuthor.Birthday
            };
            user = repository.Create(user);
            return user.Id;
        }

        
    }
}
