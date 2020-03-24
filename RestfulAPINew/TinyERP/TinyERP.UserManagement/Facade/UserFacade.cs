﻿using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.UserManagement.Entities;
using TinyERP.UserManagement.Repositories;
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
            User user = repository.GetByUserName(createAuthor.UserName);
            if (user != null)
            {
                return user.Id;
            }
            user = new User() { 
                UserName = createAuthor.UserName,
                Name = createAuthor.Name,
                Birthday = createAuthor.Birthday
            };
            user = repository.Create(user);
            return user.Id;
        }

        private void Validate(CreateAuthorDto createAuthor)
        {
            IList<Error> errors = ValidationHelper.Validate(createAuthor);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
