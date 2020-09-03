using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using TinyERP.Common.Mappers;
using TinyERP.Course.Query.Dtos;
using TinyERP.Course.Query.Entities;

namespace TinyERP.Course.Query.Services
{
    public class CourseQueryService : ICourseQueryService
    {
        public CourseDetailResponse GetCourseDetail(Guid id)
        {
            MongoDatabase database = new MongoClient("mongodb://localhost:27017").GetServer().GetDatabase("tinyerp");
            MongoCollection collection = database.GetCollection<CourseDetail>("coursedetails");
            CourseDetail result = collection.AsQueryable<CourseDetail>().FirstOrDefault(item => item.AggregateId == id);
            CourseDetailResponse response = ObjectMapper.Cast<CourseDetail, CourseDetailResponse>(result);
            return response;
        }
    }
}
