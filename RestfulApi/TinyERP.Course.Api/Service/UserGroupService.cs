namespace REST.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using REST.Context;
    using REST.Entity;
    public class UserGroupService
    {
        internal IList<UserGroup> GetUserGroups()
        {
            RESTDbContext context = new RESTDbContext();
            return context.UserGroups.ToList();
        }
    }
}