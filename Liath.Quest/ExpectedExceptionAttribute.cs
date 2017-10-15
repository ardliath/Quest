using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
    /// <summary>
    /// The attribute which marks a test as passing when an exception is thrown
    /// </summary>
    public class ExpectedExceptionAttribute : Attribute
    {
        /// <summary>
        /// The type of exception which we expection to be thrown
        /// </summary>
        public Type ExpectedExceptionType { get; set; }

        public ExpectedExceptionAttribute(Type exceptionType)
        {
            this.ExpectedExceptionType = exceptionType;
        }
    }
}
