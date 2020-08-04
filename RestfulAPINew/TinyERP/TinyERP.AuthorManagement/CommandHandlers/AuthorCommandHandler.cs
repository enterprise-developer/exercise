using TinyERP.AuthorManagement.Commands;
using TinyERP.AuthorManagement.Entities;
using TinyERP.AuthorManagement.Repositories;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.UnitOfWork;

namespace TinyERP.AuthorManagement.CommandHandlers
{
    public class AuthorCommandHandler : ICommandHandler<UpdateAuthorEmailCommand>
    {
        public void Handle(UpdateAuthorEmailCommand command)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = repository.GetById(command.AuthorId);
                ValidationHelper.ThrowIfNull(authorAggregate, "author.updateEmail.authorIsNotExisted");
                authorAggregate.UpdateEmail(command);
                repository.Update(authorAggregate);
                uow.Commit();
            }
        }
    }
}
