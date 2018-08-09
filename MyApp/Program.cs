using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework;

namespace MyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Choose");
            Console.WriteLine("1. String\n2. Boolean\n3. Number");
            var opt = Convert.ToInt32(Console.ReadLine());
            while (true) {
                if (opt >3)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Choose");
                    Console.WriteLine("1. String\n2. Boolean\n3. Number");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Enter Input");
                    var a = Console.ReadLine();
                    var b = Console.ReadLine();
                    string[] availableLibraries = new string[] { "StringHelper.dll", "BooleanHelper.dll", "NumberHelper.dll" };
                    Assembly currentAssembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, availableLibraries[opt - 1]));

                    Type contactClassType = currentAssembly.GetTypes().FirstOrDefault(_ => _.GetInterface(typeof(IConcatHelper).Name) != null);

                    IConcatHelper instance = Activator.CreateInstance(contactClassType) as IConcatHelper;
                    Console.WriteLine(instance.Add(a, b));
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}
