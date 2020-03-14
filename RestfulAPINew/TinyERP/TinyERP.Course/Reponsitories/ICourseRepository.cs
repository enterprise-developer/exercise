namespace TinyERP.Course.Reponsitories
{
    public interface ICourseRepository
    {
        Entities.Course Create(Entities.Course course);
        Entities.Course GetByName(string name);
        Entities.Course GetById(int id);
        bool IsExistName(string name, int excludedId);
        void Update(Entities.Course course);
    }
}
