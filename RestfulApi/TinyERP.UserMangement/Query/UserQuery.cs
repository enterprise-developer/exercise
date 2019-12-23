namespace TinyERP.UserMangement.Query
{
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.UoW;
    using TinyERP.UserMangement.Query.Entity;
    internal class UserQuery : BaseRepository<UserSummary>, IUserQuery
    {
        public UserQuery() : base() { }
        public UserQuery(IUnitOfWork unitOfWork) : base(unitOfWork.Context) { }
    }
}
