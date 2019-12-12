namespace TinyERP.UserManagement.Share.Dto
{
    using System;
    using TinyERP.Common.CQRS;
    public class UpdateUserRequest: ICommand
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
