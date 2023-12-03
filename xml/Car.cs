using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml
{
    internal class Car
    {
        public string Name { get; }
        public double Price { get; }
        public string Number { get; }
        public Car(string name, double price, string number)
        {
            Name = name;
            Price = price;
            Number = number;
        }
    }
}
