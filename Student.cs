﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management;

namespace StudentManagement
{
    class Student : IItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
        public double DiemToan { get; set; }

        public double DiemVan { get; set; }

        public double DiemAnh { get; set; }

        public double DiemTB { get; set; }

        public string HocLuc { get; set; }

        public void Display()
        {
            Console.WriteLine($"Student: {ID} - {Name} - {Age} - {DiemToan} - {DiemVan} - {DiemAnh} - {HocLuc}");
        }
    }
}
