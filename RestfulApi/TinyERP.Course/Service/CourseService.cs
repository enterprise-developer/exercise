namespace TinyERP.Course.Service
{
    using System.Collections.Generic;
    using TinyERP.Common.Common.Data;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Data;
    using TinyERP.Course.Data.Repositories;
    using TinyERP.Course.Dto;
    using TinyERP.Course.Entity;
    using TinyERP.Course.Repositories;
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
            IDbContext dbContext = DbContextFactory.CreateContext<Entity.Course>();

            IUserManagementFacade facade = IoC.Resolve<IUserManagementFacade>();
            CreateUserRequest createUserRequest = new CreateUserRequest(request.Author.FirstName, request.Author.LastName, request.Author.UserName);
            int authorId = facade.CreateUserIfNotExisted(createUserRequest);
            ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>(dbContext);
            Entity.Course courseEntity = new Entity.Course()
            {
                Name = request.Name,
                Description = request.Description,
                AuthorId = authorId
            };
            courseRepository.Add(courseEntity);
            dbContext.SaveChanges();
        }
    }
}
