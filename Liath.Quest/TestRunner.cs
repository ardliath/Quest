using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
  public class TestRunner
  {
      public TestResults RunAllTests(string testPath)
      {
          var results = new List<TestResult>();
          var assembly = Assembly.LoadFrom(testPath);
          foreach(var clazz in assembly.GetTypes())
          {
              foreach(var test in clazz.GetMethods())
              {
                  if(test.GetCustomAttribute<TestAttribute>() != null)
                  {
                      var testClass = Activator.CreateInstance(clazz);
                      var result = this.RunTest(testClass, test);
                      results.Add(result);
                  }
              }
          }

          return new TestResults(results);
      }

      private TestResult RunTest(object testClass, MethodInfo test)
      {
          try
          {
              test.Invoke(testClass, new object[]{});
          }
          catch(Exception ex)
          {
              return new TestResult(false, test, ex);
          }

          return new TestResult(true, test);
      }
  }
}
