namespace REST.Common.Helper
{
    using REST.Common.Task;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class AssemblyHelper
    {
        public static void Execute<ITask>() where ITask : IBaseTask
        {
            IList<System.Type> types = Assembly.GetExecutingAssembly().GetTypes().Where(item =>!item.IsAbstract && item.IsClass && typeof(ITask).IsAssignableFrom(item)).ToList();
            if (types.Count() == 0) { return; }
            foreach (Type item in types)
            {
                ITask task = AssemblyHelper.CreateInstance<ITask>(item);
                task.Execute();
            }
        }

        private static ITask CreateInstance<ITask>(Type type) where ITask : IBaseTask
        {
            object result = Activator.CreateInstance(type, new object[] { });
            return (ITask)result;
        }
    }
}