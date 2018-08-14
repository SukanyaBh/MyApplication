using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework;
using MappingHelper;
using System.Collections;
using ListHelper;

namespace MyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            /* Console.WriteLine("Choose");
             Console.WriteLine("1. String\n2. Boolean\n3. Number");
             var opt = Convert.ToInt32(Console.ReadLine());
             while (true)
             {
                 if (opt > 3)
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

                     Type concatClassType = currentAssembly.GetTypes().FirstOrDefault(_ => _.GetInterface(typeof(IConcatHelper).Name) != null);

                     IConcatHelper instance = Activator.CreateInstance(concatClassType) as IConcatHelper;
                     Console.WriteLine(instance.Add(a, b));
                     Console.ReadLine();
                     Environment.Exit(0);
                 }
             }
             Employee emp = new Employee() { Id = 1, FirstName = "Emp", LastName = 10, Married = true, Salary = "10000" };

             Person p = Map<Person>(emp);
             Console.WriteLine(p.FirstName + " " + p.LastName + " " + p.Married + " " + p.Salary);
             Console.ReadLine();

             string s = "str1";
             AddToList(s);
             int i = 1;
             AddToList("f");*/

            MyList<string> stringList = new MyList<string>();
            MyList<int> intList = new MyList<int>();

            stringList.Add("str");
            intList.Add(43);

            string s=stringList[1];
        }
        public static T Map<T>(object source) {
            T instance = Activator.CreateInstance<T>();
            PropertyInfo[] sourceProps = source.GetType().GetProperties();
            PropertyInfo[] destProps = instance.GetType().GetProperties();
            foreach (PropertyInfo sp in sourceProps) {
                foreach (PropertyInfo dp in destProps) {
                    if (sp.Name == dp.Name && sp.PropertyType == dp.PropertyType)
                    {
                        dp.SetValue(instance, sp.GetValue(source));
                    }
                    else if(sp.Name==dp.Name && sp.PropertyType!=dp.PropertyType)
                    {
                        if (dp.PropertyType == typeof(string))
                        {
                            dp.SetValue(instance, sp.GetValue(source).ToString());
                        }
                        else
                        {
                            try
                            {
                                var t = dp.PropertyType as Type;
                                //decimal.Parse()
                                var method = t.GetMethod("Parse", new Type[] { typeof(string) });
                                object o=method.Invoke(instance, new object[] { sp.GetValue(source) });
                                //object o=method.ReflectedType.InvokeMember("Parse", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Static, null, source, new object[] { sp.GetValue(source) });
                                //var a = method[0].Invoke(source, new object[] { dp});
                                //Int32.Parse(sp.Name);
                                dp.SetValue(instance, Convert.ChangeType(sp.GetValue(source), dp.PropertyType));
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            return instance;
        }
        public static T AddToList<T>(T obj) {
            Type type = typeof(T);
            List<T> list = new List<T>();
            list.Add(obj);
            return default(T);
        }
    }
}
