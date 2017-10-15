using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Liath.Quest.Tests.ThingsToTest
{
    public interface IDataAccess
    {
        string Save(int value);
        void DoSomething(int value);
    }
}
