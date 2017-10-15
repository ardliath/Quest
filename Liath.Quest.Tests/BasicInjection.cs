using Liath.Quest.Tests.ThingsToTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest.Tests
{
    public class BasicInjection
    {
        [Test]
        public void Stub()
        {
            var mock = Create.Mock<IDataAccess>();
            var calculator = new Calculator(mock);

            calculator.Sum(1, 2, 3);
        }
    }
}
