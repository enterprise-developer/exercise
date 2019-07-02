namespace REST.Controllers
{
    using REST.Entity;
    using REST.Service;
    using System.Collections.Generic;
    using System.Web.Http;
    using TinyERP.Common.Common.Attribute;
    using TinyERP.Common.Common.IoC;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet()]
        [Route("")]
        [ResponseWrapper()]
        public IList<User> GetUsers()
        {
            IUserService userService = IoC.Resolve<IUserService>();

            return userService.GetUsers();
        }
        [HttpGet()]
        [Route("{userId}")]
        [ResponseWrapper()]
        public User GetUser(int userId)
        {
            IUserService userService = IoC.Resolve<IUserService>();
            return userService.GetUser(userId);
        }

        [HttpPost()]
        [Route("")]
        [ResponseWrapper()]
        public User CreateUser(CreateUserRequest request)
        {
            IUserService userService = IoC.Resolve<IUserService>();
            return userService.CreateUser(request);
        }
    }
}
