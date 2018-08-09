using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberHelper
{
    class NumbersService:IConcatHelper
    {
        public object Add(object a, object b) {
            var result = Convert.ToInt32(a) + Convert.ToInt32(b);
            return result;
        }
    }
}
