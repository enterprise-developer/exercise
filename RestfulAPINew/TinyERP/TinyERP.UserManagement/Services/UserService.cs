using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.UserManagement.Entities;
using TinyERP.UserManagement.Repositories;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Services
{
    internal class UserService : IUserService
    {
        public int Create(CreateAuthorDto request)
        {
            this.Validate(request);
            IUserRepository repo = IoC.Resolve<IUserRepository>();
            User user = new User()
            {
                Name = request.Name,
                UserName = request.UserName,
                //Birthday = request.Birthday
            };
            user = repo.Create(user);
            return user.Id;
        }

        private void Validate(CreateAuthorDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
        public AuthorInfo GetAuthorInfo(int id)
        {
            IUserRepository repo = IoC.Resolve<IUserRepository>();
            User user = repo.GetById(id);
            if (user == null)
            {
                throw new ValidationException("user.userDetail.authorNotExisted");
            }
            AuthorInfo author = new AuthorInfo();
            author.Id = user.Id;
            author.Name = user.Name;
            author.UserName = user.UserName;
            return author;
        }

    }
}
