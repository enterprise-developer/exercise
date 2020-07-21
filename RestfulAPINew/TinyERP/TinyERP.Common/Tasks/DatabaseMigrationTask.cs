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
                DbMigrator migrator = new DbMigrator(configuration);
                migrator.Update();
            }
        }
    }
}
