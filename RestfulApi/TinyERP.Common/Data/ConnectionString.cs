using TinyERP.Common.Config;

namespace TinyERP.Common.Data
{
    public class ConnectionString
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ConnectionString(DatabaseConnectionElement databaseConnectionElemenent)
        {
            this.Server = databaseConnectionElemenent.Server;
            this.Database = databaseConnectionElemenent.Database;
            this.UserName = databaseConnectionElemenent.UserName;
            this.Password = databaseConnectionElemenent.Password;
        }

        public override string ToString()
        {
            return string.Format("Server={0}; Initial Catalog={1}; User Id={2}; password={3}", this.Server, this.Database, this.UserName, this.Password);
        }
    }
}
