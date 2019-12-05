namespace TinyERP.UserManagement.Share.Dto
{
    using TinyERP.Common.CQRS;
    public class CreateUserRequest: ICommand
    {
        public CreateUserRequest(string firstName, string lastName, string userName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; set; }
    }
}
