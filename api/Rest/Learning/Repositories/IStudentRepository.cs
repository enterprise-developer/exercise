using Learning.Entity;
using System.Collections.Generic;

namespace Learning.Repositories
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        Student GetStudentByUserName(string userName);
        Student AddStudent(Student student);
    }
}
