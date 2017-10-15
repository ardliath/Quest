using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
  public class ExpectedExceptionAttribute : Attribute
  {
    private Type _exceptionType;

    public ExpectedExceptionAttribute(Type exceptionType)
    {
      _exceptionType = exceptionType;
    }
  }
}
