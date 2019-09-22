using ExamERP.Common.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ExamERP.Common.Helpers
{
    public static class AssemblyHelper
    {
        public static void Execute<IInterface>() where IInterface : ITask
        {
            IList<Type> types = GetTypes<IInterface>();
            foreach (Type type in types)
            {
                ITask instance = (ITask)Activator.CreateInstance(type);
                instance.Execute();
            }
        }

        private static IList<Type> GetTypes<IInterface>()
        {
            IList<Type> types = new List<Type>();
            IList<string> dlls = GetApplicationDlls();
            foreach (string dll in dlls)
            {
                IList<Type> typeDll = Assembly.Load(dll).GetTypes()
                    .Where(item => typeof(IInterface).IsAssignableFrom(item) && !item.IsAbstract && item.IsClass)
                    .ToList();
                types = types.Concat(typeDll).ToList();
            }
            return types;
        }

        private static IList<string> GetApplicationDlls()
        {
            IList<string> dlls = new List<string>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            dlls = Directory.GetFiles(path, "*.dll").Where(item => item.StartsWith("ExamERP."))
                .Select(file => Path.GetFileNameWithoutExtension(file)).ToList();

            return dlls;
        }
    }
}
