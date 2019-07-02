namespace TinyERP.UserMangement.Aggregate
{
    using TinyERP.UserMangement.Share;
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserStatus Status { get; set; }
    }
}