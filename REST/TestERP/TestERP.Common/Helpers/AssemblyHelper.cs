using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TestERP.Common.Task;

namespace TestERP.Common.Helpers
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
            IList<Type> result = new List<Type>();
            IList<string> dlls = GetApplicationDlls();
            foreach (string dll in dlls)
            {
                IList<Type> types = Assembly.Load(dll).GetTypes()
                    .Where(item => typeof(IInterface).IsAssignableFrom(item) && !item.IsAbstract && item.IsClass).ToList();
                result = result.Concat(types).ToList();
            }
            return result;
        }

        private static IList<string> GetApplicationDlls()
        {
            IList<string> result = new List<string>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            result = Directory.GetFiles(path, "*.dll").Where(item => IsCustomClass(item)).Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            return result;
        }

        private static bool IsCustomClass(string item)
        {
            Regex regex = new Regex(@"^(TextERP)");
            Match match = regex.Match(Path.GetFileName(item));
            return match.Success;
        }
    }
}
