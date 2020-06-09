using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.UnitOfWork;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.UserManagement.Context;
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
            using (IUnitOfWork uow = new UnitOfWork<UserDbContext>())
            {
                IUserRepository repo = IoC.Resolve<IUserRepository>(uow.Context);
                User user = repo.GetByUserName(request.UserName);
                if (user != null)
                {
                    return user.Id;
                }
                user = new User()
                {
                    Name = request.Name,
                    UserName = request.UserName,
                    //Birthday = request.Birthday
                };
                user = repo.Create(user);
                uow.Commit();
                return user.Id;
            }
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
