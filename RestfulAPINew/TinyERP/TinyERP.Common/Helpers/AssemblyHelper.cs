using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TinyERP.Common.Tasks;

namespace TinyERP.Common.Helpers
{
    public class AssemblyHelper
    {
        public static void Execute<IInterface>(object arg = null) where IInterface : ITask
        {
            IList<Type> types = AssemblyHelper.GetTypes<IInterface>();
            foreach (Type type in types)
            {
                IInterface task = (IInterface)Activator.CreateInstance(type);
                task.Execute(arg);
            }

        }

        private static IList<Type> GetTypes<IInterface>()
        {
            IList<Type> types = new List<Type>();
            IList<string> dlls = AssemblyHelper.GetApplicationDlls();
            foreach (string dll in dlls)
            {
                IList<Type> fileTypes = Assembly.Load(dll).GetTypes().Where(item => item.IsClass && !item.IsAbstract && typeof(IInterface).IsAssignableFrom(item)).ToList();
                types = types.Concat(fileTypes).ToList();
            }
            return types;
        }

        private static IList<string> GetApplicationDlls()
        {
            IList<string> dlls = new List<string>();
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            dlls = Directory.GetFiles(binPath).Where(item => IsCustomClass(Path.GetFileName(item))).Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            return dlls;
        }

        private static bool IsCustomClass(string path)
        {
            return path.StartsWith("TinyERP.") && path.EndsWith(".dll");
        }
    }
}
