﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest.TestRunnerUI
{
    /// <summary>
    /// Simple Console UI for the TestRunner
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var testRunner = new TestRunner();
            var rootFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            var testPath = Path.Combine(rootFolder, @"Liath.Quest.Tests\bin\Debug\Liath.Quest.Tests.dll");
            var results = testRunner.RunAllTests(testPath);
            foreach(var result in results.Results)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }
    }
}
