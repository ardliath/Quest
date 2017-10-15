using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
  public class ExpectedExceptionAttribute : Attribute
  {
      public Type ExpectedExceptionType { get; set; }

    public ExpectedExceptionAttribute(Type exceptionType)
    {
        this.ExpectedExceptionType = exceptionType;
    }
  }
}
