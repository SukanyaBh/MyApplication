using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanHelper
{
    class BooleanService:IConcatHelper
    {
        public object Add(object a, object b) {
            var result = Convert.ToBoolean(a)||Convert.ToBoolean(b);
            return result;
        }
    }
}
