using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var engine = new Engine(cfg => cfg.AllowClr());
            engine.Execute(@"
    System.Console.Write('ba');
");

            Console.ReadKey();
        }
    }
}
