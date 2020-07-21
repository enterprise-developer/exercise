using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TinyERP.Common.Attributes;
using TinyERP.Common.DI;
using TinyERP.Common.Entities;
using TinyERP.Common.Helpers;
using TinyERP.Common.Vadations;
using TinyERP.Common.Validations;
using TinyERP.Course.Context;
using TinyERP.Course.Dtos;
using TinyERP.Course.Reponsitories;

namespace TinyERP.Course.Entities
{
    [DbContext(Use = typeof(CourseContext))]
    [Table("Courses")]
    public class CourseAggregateRoot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public CourseAggregateRoot()
        {

        }
        public CourseAggregateRoot(CreateCourseRequest request)
        {
            this.Validate(request);
            this.Name = request.Name;
            this.Description = request.Description;
        }
        
        private void Validate(CreateCourseRequest request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            CourseAggregateRoot course = repo.GetByName(request.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addOrUpdateCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}
