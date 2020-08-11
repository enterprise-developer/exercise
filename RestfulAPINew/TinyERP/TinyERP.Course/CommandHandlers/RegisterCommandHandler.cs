using TinyERP.Common.CQRS;
using TinyERP.Common.DI;
using TinyERP.Common.Tasks;
using TinyERP.Course.Commands;

namespace TinyERP.Course.CommandHandlers
{
    public class RegisterCommandHandler : IApplicationStartTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterSingleton<ICommandHandler<CreateCourseCommand>, CourseCommandHandler>("Course.CreateCommand");
            IoC.RegisterSingleton<ICommandHandler<UpdateCourseCommand>, CourseCommandHandler>("Course.UpdateCommand");
            IoC.RegisterSingleton<ICommandHandler<MoveCourseSectionUpCommand>, CourseCommandHandler>("Course.MoveUpSectionCommand");
        }
    }
}
