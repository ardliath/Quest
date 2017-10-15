using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest.Tests
{
  public class TestClass
  {
    [Test]
    [ExpectedException(typeof(AssertionException))]
    public void Fail_should_throw_AssertException()
    {
      Assert.Fail();
    }
  }
}
