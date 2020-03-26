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
        public int CreateAuthor(CreateAuthorDto request)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.Create(request);
        }
    }
}
