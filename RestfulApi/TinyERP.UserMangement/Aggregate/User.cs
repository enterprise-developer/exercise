namespace TinyERP.UserMangement.Aggregate
{
    using System;
    using TinyERP.Common.Attribute;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserMangement.Context;
    using TinyERP.UserMangement.Share;
    [DbContext(Use = typeof(IUserDbContext))]
    public class UserAggregateRoot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
        // EF
        public UserAggregateRoot(){}

        public UserAggregateRoot(CreateUserRequest command)
        {
            this.FirstName = command.FirstName;
            this.LastName = command.LastName;
            this.UserName = command.UserName;
        }

        internal void Update(UpdateUserRequest command)
        {
            this.FirstName = command.FirstName;
            this.LastName = command.LastName;
            this.UserName = command.UserName;
        }
    }
}