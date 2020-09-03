using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Commands;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.CommandHandlers
{
    public class RegisterCommandHandler : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<ICommandHandler<CreateCourseCommand, CreateCourseResponse>, CourseCommandHandler>("Course.CreateCommand");
            IoC.RegisterSingleton<ICommandHandler<UpdateCourseCommand>, CourseCommandHandler>("Course.UpdateCommand");
            IoC.RegisterSingleton<ICommandHandler<MoveCourseSectionUpCommand>, CourseCommandHandler>("Course.MoveUpSectionCommand");
            IoC.RegisterSingleton<ICommandHandler<CreateCourseSectionCommand, CreateCourseSectionResponse>, CourseCommandHandler>("Course.CreateCourseSectionCommand");
            IoC.RegisterSingleton<ICommandHandler<CreateLectureCommand, CreateCourseLectureResponse>, CourseCommandHandler>("Course.CreateCourseSectionLectureCommand");
        }
    }
}
