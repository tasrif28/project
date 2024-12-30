using Project.DITests;
using Project.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepoFactory repoFactory = new RepoFactory();
            TestClass test = new TestClass(repoFactory);
            test.Run();
            Console.WriteLine();
            TestClass2 test2 = new TestClass2();
            test2.Run(repoFactory);
            Console.ReadLine();
        }
    }
}
