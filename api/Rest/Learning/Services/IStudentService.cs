﻿using Learning.Dto;
using Learning.Entity;
using System.Collections.Generic;

namespace Learning.Services
{
	public interface IStudentService
	{
        IList<Student> GetStudents();
        Student AddStudent(CreateStudentRequest request);
    }
}