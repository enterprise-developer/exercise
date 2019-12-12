namespace TinyERP.UserMangement.Api
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using TinyERP.Common.Common.Attribute;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.CQRS;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Aggregate;
    using TinyERP.UserMangement.Service;

    [RoutePrefix("api/users")]
    public class UsersController : CommandControllerHandler
    {
        [HttpGet()]
        [Route("")]
        [ResponseWrapper()]
        public IList<UserAggregateRoot> GetUsers()
        {
            IUserService userService = IoC.Resolve<IUserService>();

            return userService.GetUsers();
        }
        [HttpGet()]
        [Route("{userId}")]
        [ResponseWrapper()]
        public UserAggregateRoot GetUser(int userId)
        {
            IUserService userService = IoC.Resolve<IUserService>();
            return userService.GetUser(userId);
        }

        [HttpPost()]
        [Route("")]
        [ResponseWrapper()]
        public void CreateUser(CreateUserRequest request)
        {
            this.Execute(request);
            //IUserService userService = IoC.Resolve<IUserService>();
            //return userService.CreateUser(request);
        }
        [HttpPut()]
        [Route("{userId}")]
        [ResponseWrapper()]
        public void UpdateUserRequest(int userId, UpdateUserRequest request)
        {
            request.UserId = userId;
            this.Execute(request);
        }

        [HttpPost]
        [Route("createIfNotExist")]
        [ResponseWrapper()]
        public int CreateIfNotExist(CreateUserRequest request)
        {
            IUserService service = IoC.Resolve<IUserService>();
            UserAggregateRoot user = service.GetUserByUserName(request.UserName);
            if (user != null)
            {
                return user.Id;
            }
            user = service.CreateUser(request);
            return user.Id;
        }
    }
}
