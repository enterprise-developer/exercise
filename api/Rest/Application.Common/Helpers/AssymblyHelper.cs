using Application.Common.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Application.Common.Helpers
{
    public static class AssymblyHelper
    {
        public static void Execute<IInterface>() where IInterface : ITask
        {
            IList<Type> types = AssymblyHelper.GetTypes<IInterface>();
            foreach (Type type in types)
            {
                ITask instance = (ITask)Activator.CreateInstance(type);
                instance.Execute();
            }
        }
        private static IList<Type> GetTypes<IInterface>()
        {
            IList<Type> result = new List<Type>();
            IList<string> dlls = AssymblyHelper.GetApplicationDlls();
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
            IList<string> dlls = new List<string>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            dlls = Directory.GetFiles(path, "*.dll").Where(item => IsCustomeClass(item)).Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            return dlls;
        }
        private static bool IsCustomeClass(string itemName)
        {
            Regex regex = new Regex(Application.Common.Enum.Application.RegexConts);
            Match match = regex.Match(Path.GetFileName(itemName));
            return match.Success;
        }
    }
}
