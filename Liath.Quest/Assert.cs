using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
    /// <summary>
    /// Handles Assertions
    /// </summary>
    public class Assert
    {
        /// <summary>
        /// Marks the test as failed
        /// </summary>
        public static void Fail()
        {
            throw new AssertionException();
        }

        /// <summary>
        /// Marks the test as passing
        /// </summary>
        public static void Pass()
        {
            // in otherwords - don't throw an exception
        }
    }
}