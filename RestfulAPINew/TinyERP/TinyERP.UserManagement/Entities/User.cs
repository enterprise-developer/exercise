using TinyERP.Common.Entities;

namespace TinyERP.UserManagement.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }

        public string Name { get; set; }
    }
}
