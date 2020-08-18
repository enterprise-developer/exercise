using System;
using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Responses;
using TinyERP.UserManagement.Services;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Api
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public Guid CreateAuthor(CreateAuthorDto request)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.Create(request);
        }

        [Route("{id}/authorInfo")]
        [HttpGet()]
        [ResponseWrapper()]
        public AuthorInfo GetAuthorInfo(Guid id)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.GetAuthorInfo(id);
        }
    }
}
