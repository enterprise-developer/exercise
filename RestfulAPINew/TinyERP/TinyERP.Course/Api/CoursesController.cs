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
        public CreateCourseSectionResponse CreateSection(Guid courseId, CreateCourseSectionRequest request)
        {
            request.CourseId = courseId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateSection(request);
        }

        [Route("{courseId}/sections/{sectionId}/lectures")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseLectureResponse CreateLecture(Guid courseId, Guid sectionId, CreateLectureRequest request)
        {
            request.CourseId = courseId;
            request.SectionId = sectionId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateLecture(request);
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
