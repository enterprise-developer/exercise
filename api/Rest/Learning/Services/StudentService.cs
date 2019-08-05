using System.Collections.Generic;
using Learning.Entity;
using Learning.Repositories;
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
    }
}
