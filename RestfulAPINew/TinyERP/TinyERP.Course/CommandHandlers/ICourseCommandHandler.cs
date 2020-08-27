using TinyERP.Common.CQRS;
using TinyERP.Course.Commands;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.CommandHandlers
{
    public interface ICourseCommandHandler: ICommandHandler<CreateCourseCommand, CreateCourseResponse>,
        ICommandHandler<UpdateCourseCommand>,
        ICommandHandler<MoveCourseSectionUpCommand>,
        ICommandHandler<CreateCourseSectionCommand, CreateCourseSectionResponse>
    {
    }
}
