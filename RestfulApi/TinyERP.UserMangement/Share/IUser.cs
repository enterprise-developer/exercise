namespace TinyERP.UserMangement.Share
{
    public interface IUser
    {
        int Id { get;}
        string FirstName { get;}
        string LastName { get;}
        string UserName { get;}
        UserStatus Status { get;}
    }
}
