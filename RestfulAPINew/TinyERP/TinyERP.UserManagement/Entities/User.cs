using TinyERP.Common.Attributes;
using TinyERP.Common.Entities;
using TinyERP.UserManagement.Context;

namespace TinyERP.UserManagement.Entities
{
    [DbContext(Use = typeof(UserDbContext))]
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string Name { get; set; }
    }
}
