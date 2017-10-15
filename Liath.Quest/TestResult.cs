using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liath.Quest
{
    public class TestResult
    {
        public bool Pass { get; set; }
        private System.Reflection.MethodInfo _test;
        private Exception _exception;

        public TestResult(bool pass, System.Reflection.MethodInfo test, Exception exception = null)
        {
            this.Pass = pass;
            _test = test;
            _exception = exception;
        }

        public override string ToString()
        {
            return string.Concat(_test.Name, " - ", this.Pass ? "Pass": "Fail");
        }
    }
}
