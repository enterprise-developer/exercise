using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TinyERP.AuthorManagement.Commands;
using TinyERP.AuthorManagement.Context;
using TinyERP.AuthorManagement.Repositories;
using TinyERP.Common.Attributes;
using TinyERP.Common.DI;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;

namespace TinyERP.AuthorManagement.Entities
{
    [DbContext(Use = typeof(AuthorDbContext))]
    [Table("Authors")]
    public class AuthorAggregateRoot : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public AuthorAggregateRoot()
        {
        }

        public AuthorAggregateRoot(CreateAuthorCommand command)
        {
            this.Validate(command);
            this.FirstName = command.FirstName;
            this.LastName = command.LastName;
            this.Email = command.Email;
        }

        public void Validate(CreateAuthorCommand authorRequest)
        {
            IList<Error> errors = ValidationHelper.Validate(authorRequest);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }

        public void UpdateEmail(UpdateAuthorEmailCommand updateAuthorEmail)
        {
            this.Validate(updateAuthorEmail);
            this.Email = updateAuthorEmail.Email;
        }

        private void Validate(UpdateAuthorEmailCommand updateAuthorEmail)
        {
            IAuthorRepository repository = IoC.Resolve<IAuthorRepository>();
            bool isExisted = repository.CheckExistedByEmail(updateAuthorEmail.Email, updateAuthorEmail.AggregateId);
            if (isExisted)
            {
                throw new ValidationException("author.updateEmail.emailWasExisted");
            }
        }

        public void Active()
        {
            this.ValidateActiveAuthor();
            this.IsActive = true;
        }
        private void ValidateActiveAuthor()
        {
            if (this.IsActive == true)
            {
                throw new ValidationException("author.activeAuthor.authorWasActived");
            }
        }

        public void UpdateBasicInfor(UpdateAuthorCommand command)
        {
            this.Validate(command);
            this.FirstName = command.FirstName;
            this.LastName = command.LastName;
            this.Email = command.Email;
        }

        private void Validate(UpdateAuthorCommand command)
        {
            IList<Error> errors = ValidationHelper.Validate(command);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
