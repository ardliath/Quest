using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liath.Quest
{
    /// <summary>
    /// Results for a Test run
    /// </summary>
    public class TestResults
    {
        /// <summary>
        /// The results of the run
        /// </summary>
        public IEnumerable<TestResult> Results { get; private set; }

        /// <summary>
        /// A bool indicating whether all the tests pass
        /// </summary>
        public bool AllPass
        {
            get
            {
                return this.Results.All(r => r.Pass);
            }
        }

        /// <summary>
        /// Creates a new TestsResults class
        /// </summary>
        /// <param name="results">The results to return</param>
        public TestResults(IEnumerable<TestResult> results)
        {
            this.Results = results;
        }
    }
}
