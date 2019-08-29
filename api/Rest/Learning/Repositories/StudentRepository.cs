using System.Collections.Generic;
using System.Linq;
using Learning.Context;
using Learning.Entity;

namespace Learning.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public IList<Student> GetAll()
        {
            LearningDbContext context = new LearningDbContext();
            return context.Students.ToList();
        }

        public Student GetStudentByUserName(string userName)
        {
            LearningDbContext context = new LearningDbContext();
            return context.Students.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
