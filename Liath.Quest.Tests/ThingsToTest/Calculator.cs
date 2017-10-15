using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest.Tests.ThingsToTest
{
    public class Calculator
    {
        private IDataAccess _dataAccess;

        public Calculator(IDataAccess dataAccess)
        {
            if (dataAccess == null) throw new ArgumentNullException("dataAccess");
            _dataAccess = dataAccess;
        }

        public void Sum(params int[] values)
        {
            _dataAccess.Save(values.Sum());
        }
    }
}
