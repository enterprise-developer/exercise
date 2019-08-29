using Learning.Dto;
using Learning.Entity;
using Learning.Repositories;
using System.Collections.Generic;
using TinyERP.Common.Exceptions;
using TinyERP.Common.Helpers;
using TinyERP.Common.IoC;

namespace Learning.Services
{
    internal class StudentService : IStudentService
    {

        public IList<Student> GetStudents()
        {
            IStudentRepository studentRepo = IoC.Container.Resolve<IStudentRepository>();
            return studentRepo.GetAll();
        }

        public Student AddStudent(CreateStudentRequest request)
        {
            Validation(request);
            Student student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };
            IStudentRepository repo = IoC.Container.Resolve<IStudentRepository>();
            return repo.AddStudent(student);
        }

        private void Validation(CreateStudentRequest request)
        {
            List<string> errorMessages = ValidationHelper.GetMessageKey(request);
            IStudentRepository repo = IoC.Container.Resolve<IStudentRepository>();
            Student student = repo.GetStudentByUserName(request.UserName);
            if (student != null)
            {
                errorMessages.Add("learning.addNewStudent.userNameHasExisted");
            }
            if (errorMessages.Count > 0)
            {
                throw new ValidationException(errorMessages);
            }
        }
    }
}
