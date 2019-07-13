namespace TinyERP.Course.Service
{
    using System.Collections.Generic;
    using TinyERP.Common.Common.IoC;
    using TinyERP.Common.Data.UoW;
    using TinyERP.Common.Service;
    using TinyERP.Course.Data.Repositories;
    using TinyERP.Course.Dto;
    using TinyERP.UserManagement.Share.Dto;
    using TinyERP.UserManagement.Share.Facade;

    public class CourseService : BaseService, ICourseService
    {
        public IList<Entity.Course> GetCourses()
        {
            ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>();
            return courseRepository.GetCourses();

        }

        public void CreateCourse(CreateCourseRequest request)
        {
            using (IUnitOfWork unitOfWork = this.CreateUnitOfWork<Entity.Course>())
            {
                IUserManagementFacade facade = IoC.Resolve<IUserManagementFacade>();
                CreateUserRequest createUserRequest = new CreateUserRequest(request.Author.FirstName, request.Author.LastName, request.Author.UserName);
                int authorId = facade.CreateUserIfNotExisted(createUserRequest);
                ICourseRepository courseRepository = IoC.Resolve<ICourseRepository>(unitOfWork);
                Entity.Course courseEntity = new Entity.Course()
                {
                    Name = request.Name,
                    Description = request.Description,
                    AuthorId = 2
                };
                courseRepository.Add(courseEntity);
                unitOfWork.Commit();
            }
        }

    }
}
