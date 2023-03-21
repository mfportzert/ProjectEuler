using System;
using System.IO;
using System.Reflection;

namespace ProjectEuler
{
    public static class IOUtils
    {
        public static string LoadFileContent(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream!))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}

