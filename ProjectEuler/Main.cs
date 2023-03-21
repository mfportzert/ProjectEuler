using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using static ProjectEuler.DateUtils;
using ProjectEuler.Extensions;

namespace ProjectEuler
{
    internal class Program
    {
        public static string s_AssetsPath = "ProjectEuler.Assets.";

        static void Main(string[] args)
        {
            var resourceName = s_AssetsPath + "p022_names.txt";
            var namesStr = IOUtils.LoadFileContent(resourceName);

            namesStr = namesStr.Replace("\"", "");
            var names = namesStr.Split(',');
            var sortedNames = names.OrderBy(x => x).ToArray();

            double total = 0;
            var count = sortedNames.Length;
            for (int i = 0; i < count; i++)
            {
                var nameSum = 0;
                var name = sortedNames[i];
                foreach (char c in name)
                    nameSum += (c - 'A') + 1;

                total += nameSum * (i + 1);
            }

            Console.WriteLine(total);
        }
    }
}