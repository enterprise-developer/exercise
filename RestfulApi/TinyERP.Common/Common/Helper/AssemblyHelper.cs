namespace TinyERP.Common.Common.Helper
{
    using TinyERP.Common.Common.Task;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;

    public class AssemblyHelper
    {

        public static void Execute<ITask>(ITaskArgument arg=null, bool runInOrder=true) where ITask : IBaseTask
        {
            IList<Type> types = GetTypes<ITask>();
            if (types.Count() == 0) { return; }
            if (runInOrder==true) {
                IList<ITask> instances = new List<ITask>();
                foreach (var type in types)
                {
                    instances.Add(AssemblyHelper.CreateInstance<ITask>(type));
                }
                instances = instances.OrderByDescending(item => item.Priority).ToList();
                foreach (ITask instance in instances)
                {
                    instance.Execute(arg);
                }
                return;
            }
            foreach (var type in types)
            {
                ITask task = AssemblyHelper.CreateInstance<ITask>(type);
                task.Execute(arg);
            }
        }

        public static IList<Type> GetTypes<IType>()
        {
            IList<string> applicationDlls = AssemblyHelper.GetApplicationDlls();
            IList<Type> types = new List<Type>();
            foreach (var assembly in applicationDlls)
            {
                IList<Type> fileTypes = Assembly.Load(assembly).GetTypes().Where(item => !item.IsAbstract && item.IsClass && typeof(IType).IsAssignableFrom(item)).ToList();
                types = types.Concat(fileTypes).ToList();
            }

            return types;
        }

        public static Type GetType<IType>()
        {
            return GetTypes<IType>().FirstOrDefault();
        }

        internal static IList<Type> GetInterfaces(object arg)
        {
            return arg.GetType().GetInterfaces().Where(item => item.FullName.StartsWith("TinyERP.")).ToList();
        }

        public static IType CreateInstance<IType>(Type type)
        {
            object result = Activator.CreateInstance(type, new object[] { });
            return (IType)result;
        }

        private static IList<string> GetApplicationDlls(string filePattern="*.dll")
        {
            var binPath = AssemblyHelper.GetBinDirectoryPath();
            IList<string> dlls = Directory.GetFiles(binPath, filePattern)
                .Where(item => Path.GetFileName(item).StartsWith("TinyERP."))
                .Select(fileItem => Path.GetFileNameWithoutExtension(fileItem))
                .ToList();
            return dlls;
        }

        private static string GetBinDirectoryPath()
        {
            var binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            return binPath;
        }
    }
}