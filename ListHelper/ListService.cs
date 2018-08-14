using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListHelper
{
    public class MyList<T>
    {
        int index = 0;
        T[] list = new T[10];
        public void Add(T obj)
        {
            list[index] = obj;
            index++;
        }
        public void Remove(T obj)
        {
            for(int i=0;i<list.Length;i++) {
                if (list[i].Equals(obj)) {
                    list[i] = default(T);
                }
            }
        }
        public T this[int index] {
            get {
                return list[index];
            }
            set {
                list[index] = value;
            }
        }
    }
}
