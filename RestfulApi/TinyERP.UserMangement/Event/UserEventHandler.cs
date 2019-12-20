namespace TinyERP.UserMangement.Event
{
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System.Linq;
    using TinyERP.Common.Common.Helper;
    using TinyERP.UserMangement.Event.User;
    using TinyERP.UserMangement.Query.Entity;

    internal class UserEventHandler : IUserEventHandler
        
    {
        public void Handle(OnUserCreated ev)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetServer().GetDatabase("LearningMongoDb");
            string tableName = AttributeHelper.GetTableName(typeof(UserSummary));
            var collection = database.GetCollection<UserSummary>(tableName);
            collection.Insert(new UserSummary(ev.UserInfo));
        }

        public void Handle(OnUserUpdated ev)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var database = dbClient.GetServer().GetDatabase("LearningMongoDb");
            string tableName = AttributeHelper.GetTableName(typeof(UserSummary));
            var collection = database.GetCollection<UserSummary>(tableName);
            UserSummary user = collection.AsQueryable().Where(item => item.UserId==ev.UserInfo.Id).FirstOrDefault();
            user.FirstName = ev.UserInfo.FirstName;
            user.LastName = ev.UserInfo.LastName;
            user.Status = ev.UserInfo.Status;
            user.UserName = ev.UserInfo.UserName;
            collection.Save(user);
        }
    }
}
