using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management;

namespace StudentManagement
{
    class Employee : IItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string? jobPosition { get; set; }

        public float salery { get; set; }

        public void Display()
        {
            Console.WriteLine($"Employee: {ID} - {Name} - {Age} - {jobPosition} - {salery}");
        }
    }
}
