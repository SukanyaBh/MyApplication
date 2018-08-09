using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHelper
{
   public class StringsService:IConcatHelper
    {
        public object Add(object a, object b) {
            var result = string.Concat(a as string, b as string);
            return result;
        }
    }
}
