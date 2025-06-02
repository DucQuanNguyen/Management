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

        public string modelYear { get; set; }

        public float listPrice { get; set; }
        public string brandName { get; set; }

        public void Display()
        {
            Console.WriteLine($"Product: {ID} - {Name} - {modelYear} - {listPrice} - {brandName}");
        }
    }
}
