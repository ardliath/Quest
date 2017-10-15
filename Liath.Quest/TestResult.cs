using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liath.Quest
{
    /// <summary>
    /// Details of the test execution
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// A bool indicating whether the test passed
        /// </summary>
        public bool Pass { get; set; }

        /// <summary>
        /// The test which is being executed
        /// </summary>
        private System.Reflection.MethodInfo _test;

        /// <summary>
        /// The exception thrown during test execution
        /// </summary>
        private Exception _exception;

        public TestResult(bool pass, System.Reflection.MethodInfo test, Exception exception = null)
        {
            this.Pass = pass;
            _test = test;
            _exception = exception;
        }

        /// <summary>
        /// An override of ToString which gives the test name and Pass/Fail details
        /// </summary>
        public override string ToString()
        {
            return string.Concat(_test.Name, " - ", this.Pass ? "Pass": "Fail");
        }
    }
}
