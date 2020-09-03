namespace TinyERP.Course.Api
{
    using System;
    using System.Web.Http;
    using TinyERP.Common.CQRS;
    using TinyERP.Common.DI;
    using TinyERP.Common.Responses;
    using TinyERP.Course.Commands;
    using TinyERP.Course.Dtos;
    using TinyERP.Course.Services;

    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseResponse CreateCourse(CreateCourseCommand command)
        {
            ICommandHandler<CreateCourseCommand, CreateCourseResponse> commandHandler = IoC.Resolve<ICommandHandler<CreateCourseCommand, CreateCourseResponse>>();
            return commandHandler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut()]
        [ResponseWrapper()]
        public void Update(Guid id, UpdateCourseCommand command)
        {
            ICommandHandler<UpdateCourseCommand> commandHandler = IoC.Resolve<ICommandHandler<UpdateCourseCommand>>();
            command.SetAggregateId(id);
            commandHandler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet()]
        [ResponseWrapper()]
        public Query.Dtos.CourseDetailResponse GetCourseDetail(Guid id)
        {
            Query.Services.ICourseQueryService service = IoC.Resolve<Query.Services.ICourseQueryService>();
            return service.GetCourseDetail(id);
        }

        [Route("{courseId}/sections")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseSectionResponse CreateSection(Guid courseId, CreateCourseSectionCommand command)
        {
            ICommandHandler<CreateCourseSectionCommand, CreateCourseSectionResponse> commandHandler = IoC.Resolve<ICommandHandler<CreateCourseSectionCommand, CreateCourseSectionResponse>>();
            command.SetAggregateId(courseId);
            return commandHandler.Handle(command);
        }

        [Route("{courseId}/sections/{sectionId}/lectures")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseLectureResponse CreateLecture(Guid courseId, Guid sectionId, CreateLectureCommand command)
        {
            ICommandHandler<CreateLectureCommand, CreateCourseLectureResponse> commandHandler = IoC.Resolve<ICommandHandler<CreateLectureCommand, CreateCourseLectureResponse>>();
            command.SetAggregateId(courseId);
            command.SectionId = sectionId;
            return commandHandler.Handle(command);
        }

        [Route("{courseId}/sections/{sectionId}/moveUp")]
        [HttpPost()]
        [ResponseWrapper()]
        public void MoveSectionUp(Guid courseId, Guid sectionId)
        {
            MoveCourseSectionUpCommand command = new MoveCourseSectionUpCommand(courseId, sectionId);
            ICommandHandler<MoveCourseSectionUpCommand> commandHandler = IoC.Resolve<ICommandHandler<MoveCourseSectionUpCommand>>();
            commandHandler.Handle(command);
        }


    }
}
