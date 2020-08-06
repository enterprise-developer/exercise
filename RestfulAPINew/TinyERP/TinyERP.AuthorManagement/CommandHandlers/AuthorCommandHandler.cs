using TinyERP.AuthorManagement.Commands;
using TinyERP.AuthorManagement.Entities;
using TinyERP.AuthorManagement.Repositories;
using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.UnitOfWork;

namespace TinyERP.AuthorManagement.CommandHandlers
{
    public class AuthorCommandHandler : ICommandHandler<UpdateAuthorEmailCommand>, ICommandHandler<CreateAuthorCommand>, ICommandHandler<ActiveAuthorCommand>, ICommandHandler<UpdateAuthorCommand>
    {
        public void Handle(CreateAuthorCommand command)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = new AuthorAggregateRoot(command);
                repository.Create(authorAggregate);
                uow.Commit();
            }
        }

        public void Handle(UpdateAuthorEmailCommand command)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = repository.GetById(command.AggregateId);
                ValidationHelper.ThrowIfNull(authorAggregate, "author.updateEmail.authorIsNotExisted");
                authorAggregate.UpdateEmail(command);
                repository.Update(authorAggregate);
                uow.Commit();
            }
        }

        public void Handle(ActiveAuthorCommand command)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = repository.GetById(command.AggregateId);
                ValidationHelper.ThrowIfNull(authorAggregate, "author.activeAuthor.authorIsNotExisted");
                authorAggregate.Active();
                repository.Update(authorAggregate);
                uow.Commit();
            }
        }

        public void Handle(UpdateAuthorCommand command)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = repository.GetById(command.AggregateId);
                ValidationHelper.ThrowIfNull(authorAggregate, "author.updateAuthor.authorIsNotExisted");
                authorAggregate.UpdateBasicInfor(command);
                repository.Update(authorAggregate);
                uow.Commit();
            }
        }
    }
}
