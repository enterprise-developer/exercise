using TinyERP.AuthorManagement.Dtos;
using TinyERP.AuthorManagement.Entities;
using TinyERP.AuthorManagement.Repositories;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Mappers;
using TinyERP.Common.UnitOfWork;

namespace TinyERP.AuthorManagement.Services
{
    public class AuthorService : IAuthorService
    {
        public CreateAuthorResponse CreateAuthor(CreateAuthorRequest authorRequest)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = new AuthorAggregateRoot();
                authorAggregate.CreateAuthor(authorRequest);
                repository.Create(authorAggregate);
                uow.Commit();
                CreateAuthorResponse response = ObjectMapper.Map<AuthorAggregateRoot, CreateAuthorResponse>(authorAggregate);
                return response;
            }
        }

        public UpdateAuthorEmailResponse UpdateEmail(UpdateAuthorEmailRequest authorEmailRequest)
        {
            using (IUnitOfWork uow = new UnitOfWork<AuthorAggregateRoot>())
            {
                IAuthorRepository repository = IoC.Resolve<IAuthorRepository>(uow.Context);
                AuthorAggregateRoot authorAggregate = repository.GetById(authorEmailRequest.AuthorId);
                ValidationHelper.ThrowIfNull(authorAggregate,"author.updateEmail.authorIsNotExisted");
                authorAggregate.UpdateEmail(authorEmailRequest);
                repository.Update(authorAggregate);
                uow.Commit();
                UpdateAuthorEmailResponse response = new UpdateAuthorEmailResponse()
                {
                    Email = authorAggregate.Email,
                    IsSuccess = true
                };
                return response;
            }
        }
    }
}
