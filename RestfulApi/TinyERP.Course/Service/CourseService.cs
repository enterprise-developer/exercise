namespace TinyERP.Course.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Data;
    using TinyERP.Course.Context;
    using TinyERP.Course.Data.Repositories;
    using TinyERP.Course.Dto;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserManagement.Share.Facade;

    public class CourseService : ICourseService
    {
        public IList<Entity.Course> GetCourses()
        {
            ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>();
            return courseRepository.GetCourses();

        }

        public void CreateCourse(CreateCourseRequest request)
        {
            IUserManagementFacade facade = IoC.Resolve<IUserManagementFacade>();
            CreateUserRequest createUserRequest = new CreateUserRequest(request.Author.FirstName, request.Author.LastName, request.Author.UserName);
            int authorId = facade.CreateUserIfNotExisted(createUserRequest);
            ICourseDbContext context = DbContextFactory.Create<ICourseDbContext>();
            Entity.Course courseEntity = new Entity.Course()
            {
                Name = request.Name,
                Description = request.Description,
                AuthorId = authorId
            };
            context.Courses.Add(courseEntity);
            context.SaveChanges();
        }
    }
}
