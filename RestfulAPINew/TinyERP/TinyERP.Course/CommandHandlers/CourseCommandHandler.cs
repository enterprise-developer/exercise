using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.UnitOfWork;
using TinyERP.Course.Commands;
using TinyERP.Course.Entities;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.CommandHandlers
{
    internal class CourseCommandHandler : ICommandHandler<CreateCourseCommand>, ICommandHandler<UpdateCourseCommand>
    {
        public void Handle(CreateCourseCommand command)
        {
            CourseAggregateRoot createdCourse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                createdCourse = new CourseAggregateRoot(command);
                ICourseRepository repo = IoC.Resolve<ICourseRepository>(uow.Context);
                createdCourse = repo.Create(createdCourse);
                uow.Commit();
            }
        }

        public void Handle(UpdateCourseCommand command)
        {
            CourseAggregateRoot updatedCourse;
            using (IUnitOfWork uow = new UnitOfWork<CourseAggregateRoot>())
            {
                ICourseRepository repository = IoC.Resolve<ICourseRepository>(uow.Context);
                updatedCourse = repository.GetById(command.AggregateId);
                updatedCourse.Update(command);
                repository.Update(updatedCourse);
                uow.Commit();
            }
        }
    }
}
