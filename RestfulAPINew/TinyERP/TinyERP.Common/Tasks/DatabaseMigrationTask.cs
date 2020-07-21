using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TinyERP.Common.Databases;
using TinyERP.Common.Helpers;

namespace TinyERP.Common.Tasks
{
    public class DatabaseMigrationTask : IDatabaseMigrationTask
    {
        public void Execute(object arg = null)
        {
            IList<Type> types= AssemblyHelper.GetTypes<IDbMigratorConfiguration>();
            foreach (Type type in types)
            {
                DbMigrationsConfiguration configuration = (DbMigrationsConfiguration)Activator.CreateInstance(type);
                //configuration.TargetDatabase = new DbConnectionInfo(@"Data Source=.\SQLEXPRESS; Initial Catalog= CourseDbContext; User=sa; Password=123456", "System.Data.SqlClient");
                DbMigrator migrator = new DbMigrator(configuration);
                migrator.Update();
            }
        }
    }
}
