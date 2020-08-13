namespace TinyERP.Course.Api
{
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
        public void Update(int id, UpdateCourseCommand command)
        {
            ICommandHandler<UpdateCourseCommand> commandHandler = IoC.Resolve<ICommandHandler<UpdateCourseCommand>>();
            command.SetAggregateId(id);
            commandHandler.Handle(command);
        }

        //[Route("{id}")]
        //[HttpGet()]
        //[ResponseWrapper()]
        //public async Task<CourseDetail> GetCourseDetail(int id)
        //{
        //    ICourseService service = IoC.Resolve<ICourseService>();
        //    return await service.GetCourseDetail(id);
        //}

        [Route("{id}")]
        [HttpGet()]
        [ResponseWrapper()]
        public Query.Dtos.CourseDetailResponse GetCourseDetail(int id)
        {
            Query.Services.ICourseQueryService service = IoC.Resolve<Query.Services.ICourseQueryService>();
            return service.GetCourseDetail(id);
        }

        [Route("{courseId}/sections")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseSectionResponse CreateSection(int courseId, CreateCourseSectionRequest request)
        {
            request.CourseId = courseId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateSection(request);
        }

        [Route("{courseId}/sections/{sectionId}/lectures")]
        [HttpPost()]
        [ResponseWrapper()]
        public CreateCourseLectureResponse CreateLecture(int courseId, int sectionId, CreateLectureRequest request)
        {
            request.CourseId = courseId;
            request.SectionId = sectionId;
            ICourseService service = IoC.Resolve<ICourseService>();
            return service.CreateLecture(request);
        }

        [Route("{courseId}/sections/{sectionId}/moveUp")]
        [HttpPost()]
        [ResponseWrapper()]
        public void MoveSectionUp(int courseId, int sectionId)
        {
            MoveCourseSectionUpCommand command = new MoveCourseSectionUpCommand(courseId, sectionId);
            ICommandHandler<MoveCourseSectionUpCommand> commandHandler = IoC.Resolve<ICommandHandler<MoveCourseSectionUpCommand>>();
            commandHandler.Handle(command);
        }


    }
}
