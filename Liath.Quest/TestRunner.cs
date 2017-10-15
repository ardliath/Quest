using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
    /// <summary>
    /// Runs the various unit tests
    /// </summary>
    public class TestRunner
    {
        /// <summary>
        /// Run all the unit tests in an assembly
        /// </summary>
        /// <param name="testPath">The path of the assembly to run</param>
        /// <returns>The TestREsults</returns>
        public TestResults RunAllTests(string testPath)
        {
            var results = new List<TestResult>();
            var assembly = Assembly.LoadFrom(testPath); // load the assembly
            foreach (var clazz in assembly.GetTypes()) // get all classes
            {
                foreach (var test in clazz.GetMethods()) // and all methods within those
                {
                    if (test.GetCustomAttribute<TestAttribute>() != null) // if they have a TestAttribute
                    {
                        var testClass = Activator.CreateInstance(clazz); // create an instance of the class
                        var result = this.RunTest(testClass, test); // and run it
                        results.Add(result);
                    }
                }
            }

            return new TestResults(results);
        }

        /// <summary>
        /// Runs a particular test
        /// </summary>
        /// <param name="testClass">The implemented object of the test class</param>
        /// <param name="test">The MethodInfo of the test to run</param>
        /// <returns>The result of the test</returns>
        private TestResult RunTest(object testClass, MethodInfo test)
        {
            try
            {
                test.Invoke(testClass, new object[] { }); // invoke the test
            }
            catch (Exception ex) // and catch any exception
            {
                // Is an exception expected?
                var expectedExceptionAttribute = test.GetCustomAttribute<ExpectedExceptionAttribute>();
                if (expectedExceptionAttribute != null)
                {
                    // we need to get the inner exception because the main one is an TargetInvocationException
                    var exType = ex.InnerException.GetType();
                    if (expectedExceptionAttribute.ExpectedExceptionType.Equals(exType))
                    {
                        return new TestResult(true, test, ex);
                    }
                }

                return new TestResult(false, test, ex); // an exception was thrown but none were expected
            }

            return new TestResult(true, test); // if there was no exception then the test passed
        }
    }
}
