using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeDemo
{
    public class Employee : Person
    {
        public decimal SalaryPerHour { get; private set; }

        public Employee(string name, int age, decimal baseSalary) : base(name, age)
        {
            this.SalaryPerHour = baseSalary;
        }
    }
}
