namespace TinyERP.Course.Context
{
    using System.Data.Entity;
    using TinyERP.Common.Common.Data;

    public interface ICourseDbContext: IDbContext
    {
        IDbSet<Entity.Course> Courses { get; }
        int SaveChanges();
    }
}
