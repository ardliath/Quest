using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liath.Quest
{
    public class TestResults
    {
        public IEnumerable<TestResult> Results { get; private set; }

        public bool AllPass
        {
            get
            {
                return this.Results.All(r => r.Pass);
            }
        }

        public TestResults(IEnumerable<TestResult> results)
        {
            this.Results = results;
        }
    }
}
