using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("LoadCSharpDll <dll path name");
                return;
            }
            try
            {
                string obj = args[0];
                Console.WriteLine(obj);
                Assembly assembly = Assembly.LoadFrom(obj);
                Console.WriteLine("Load dll succeed.");
                Type[] types = assembly.GetTypes();
                Console.WriteLine("GetTypes succeed.");
                Type[] array = types;
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Exception[] loaderExceptions = ex.LoaderExceptions;
                foreach (Exception ex2 in loaderExceptions)
                {
                    stringBuilder.AppendLine(ex2.Message);
                    FileNotFoundException ex3 = ex2 as FileNotFoundException;
                    if (ex3 != null && !string.IsNullOrEmpty(ex3.FusionLog))
                    {
                        stringBuilder.AppendLine("Fusion Log:");
                        stringBuilder.AppendLine(ex3.FusionLog);
                    }
                    stringBuilder.AppendLine();
                }
                Console.WriteLine(stringBuilder.ToString());
                Console.WriteLine(ex);
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
            }
        }
    }

}
