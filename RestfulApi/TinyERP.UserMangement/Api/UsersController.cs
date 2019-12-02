namespace TinyERP.UserMangement.Api
{
    using System.Collections.Generic;
    using System.Web.Http;
    using TinyERP.Common.Common.Attribute;
    using TinyERP.Common.Common.IoC;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Service;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet()]
        [Route("")]
        //[ResponseWrapper()]
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

        [HttpPost]
        [Route("createIfNotExist")]
        [ResponseWrapper()]
        public int CreateIfNotExist(CreateUserRequest request)
        {
            IUserService service = IoC.Resolve<IUserService>();
            User user = service.GetUserByUserName(request.UserName);
            if (user != null)
            {
                return user.Id;
            }
            user = service.CreateUser(request);
            return user.Id;
        }

    }
}
