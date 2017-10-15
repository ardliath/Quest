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
      public object RunAllTests(string testPath)
      {
          var assembly = Assembly.LoadFrom(testPath);
          foreach(var clazz in assembly.GetTypes())
          {
              foreach(var test in clazz.GetMethods())
              {
                  if(test.GetCustomAttribute<TestAttribute>() != null)
                  {
                      this.RunTest(test);
                  }
              }
          }

          return new object();
      }

      private void RunTest(MethodInfo test)
      {
          
      }
  }
}
