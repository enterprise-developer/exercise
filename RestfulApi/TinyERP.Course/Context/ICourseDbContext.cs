namespace TinyERP.Course.Context
{
    using System.Data.Entity;
    public interface ICourseDbContext
    {
        IDbSet<Entity.Course> Courses { get; }
        int SaveChanges();
    }
}
