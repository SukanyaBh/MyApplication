using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MappingHelper
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public bool Married { get; set; }
        public string Salary { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Married { get; set; }
        public int Salary { get; set; }
    }
}
