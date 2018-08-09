using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectHelper
{
    class ObjectService : IObjectService
    {
        public void Add(object a, object b)
        {
            Console.WriteLine();
        }
    }
    interface IObjectService : IMyContracts
    {

    }
}
