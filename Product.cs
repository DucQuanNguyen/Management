using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management;

namespace StudentManagement
{
    class Product : IItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string model { get; set; }

        public string brandName { get; set; }

        public double price { get; set; }
        public void Display()
        {
            Console.WriteLine($"Product: {ID} - {Name} - {model} - {price} - {brandName}");
        }
    }
}
