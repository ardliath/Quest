using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
  public class Assert
  {
    public static void Fail()
    {
      throw new AssertionException();
    }
  }
}
