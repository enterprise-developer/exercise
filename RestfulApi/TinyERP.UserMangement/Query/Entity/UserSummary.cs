namespace TinyERP.UserMangement.Query.Entity
{
    using TinyERP.Common.Attribute;
    using TinyERP.Common.Data.MongoDb;
    using TinyERP.UserMangement.Share;
    [TableName(Name = "UserSummaryCollection")]
    public class UserSummary: BaseMongoEntity
    {

        public UserSummary(IUser userInfo)
        {
            this.UserId = userInfo.Id;
            this.FirstName = userInfo.FirstName;
            this.LastName = userInfo.LastName;
            this.Status = userInfo.Status;
            this.UserName = userInfo.UserName;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserStatus Status { get; set; }
        public string UserName { get; set; }
    }
}
