using System;
using Management;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StuManage manageStudent = new StuManage();
            EmpManage manageEmployee = new EmpManage();
            ProManage manageProduct = new ProManage();
            
            string s = "";
            bool t=true;
            while (t)
            {
                Console.WriteLine("Chose program to run: ");
                Console.WriteLine("1. Manage student");
                Console.WriteLine("2. Manage employee");
                Console.WriteLine("3. Manage product");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        s = "student";
                        t = false;
                        break;
                    case 2:
                        s = "employee";
                        t = false;
                        break;
                    case 3:
                        s = "product";
                        t = false;
                        break;
                    default:
                        Console.WriteLine("Program invalid, please chose again!");
                        break;
                }
            }
            
            while (true)
            {
                Console.WriteLine($"\n{s} management program");
                Console.WriteLine($"\n1. Add {s}");
                Console.WriteLine($"2. Update {s} infomation by ID");
                Console.WriteLine($"3. Delete {s} by ID");
                Console.WriteLine($"4. Search {s} by Name");
                if (s.Equals("student"))
                {
                    Console.WriteLine("5. Sort student by GPA");
                }else if (s.Equals("employee"))
                {
                    Console.WriteLine("5. Sort employee by job position");
                }else
                {
                    Console.WriteLine("5. Sort product by price");
                }
                Console.WriteLine($"6. Sort {s} by Name");
                Console.WriteLine($"7. Sort {s} by ID");
                Console.WriteLine($"8. Show {s}'s list");
                Console.WriteLine("0. Quit\n");
                Console.Write("Enter selection: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine($"\n1. Add {s}");
                        if (s.Equals("student"))
                        {                            
                            manageStudent.EnterStudent();                            
                        }
                        else if (s.Equals("employee"))
                        {
                            manageEmployee.EnterEmployee();
                        }
                        else
                        {
                            manageProduct.EnterProduct();
                        }
                        Console.WriteLine($"\nAdd {s} succes!");
                        break;
                    case 2:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            int id;
                            Console.WriteLine($"\n2. Update {s} infomation");
                            Console.Write("\nEnter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            if (s.Equals("student"))
                            {
                                manageStudent.UpdateStudent(id);
                            }
                            else if (s.Equals("employee"))
                            {
                                manageEmployee.UpdateEmployee(id);
                            }
                            else
                            {
                                manageProduct.UpdateProduct(id);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 3:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            int id;
                            Console.WriteLine($"\n3. Delete {s}");
                            Console.Write("\nEnter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            if (s.Equals("student"))
                            {
                                if (manageStudent.DeleteById(id))
                                {
                                    Console.WriteLine($"\nStudent had id = {id} is deleted");
                                }
                            }
                            else if (s.Equals("employee"))
                            {
                                if (manageEmployee.DeleteById(id))
                                {
                                    Console.WriteLine($"\nEmployee had id = {id} is deleted");
                                }
                            }
                            else
                            {
                                if (manageProduct.DeleteById(id))
                                {
                                    Console.WriteLine($"\nProduct had id = {id} is deleted");
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine($"\n{s}'s list is empty!");
                        }
                        break;
                    case 4:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            Console.WriteLine($"\n4. Search {s} by name");
                            Console.Write($"\nEnter {s}'s name: ");
                            string name = Convert.ToString(Console.ReadLine());
                            if (s.Equals("student"))
                            {
                                List<Student> searchResult = manageStudent.FindByName(name);
                                manageStudent.ShowStudent(searchResult);
                            }
                            else if (s.Equals("employee"))
                            {
                                List<Employee> searchResult = manageEmployee.FindByName(name);
                                manageEmployee.ShowEmployee(searchResult);
                            }
                            else
                            {
                                List<Product> searchResult = manageProduct.FindByName(name);
                                manageProduct.ShowProduct(searchResult);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine($"\n{s}'s list is empty!");
                        }
                        break;
                    case 5:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            if (s.Equals("student"))
                            {
                                Console.WriteLine("\n5. Sort student by GPA");
                                manageStudent.SortByDiemTB();
                                manageStudent.ShowStudent(manageStudent.getListStudent());
                            }
                            else if (s.Equals("employee"))
                            {
                                Console.WriteLine("\n5. Sort employee by job position");
                                manageEmployee.SortByJobposition();
                                manageEmployee.ShowEmployee(manageEmployee.getListEmployee());
                            }
                            else
                            {
                                Console.WriteLine("\n5. Sort product by price");
                                manageProduct.SortByPrice();
                                manageProduct.ShowProduct(manageProduct.getListProduct());
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine($"\n{s}'s list is empty!");
                        }
                        break;
                    case 6:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            Console.WriteLine($"\n6. Sort {s} by name");
                            if (s.Equals("student"))
                            {
                                manageStudent.SortByName();
                                manageStudent.ShowStudent(manageStudent.getListStudent());
                            }
                            else if (s.Equals("employee"))
                            {
                                manageEmployee.SortByName();
                                manageEmployee.ShowEmployee(manageEmployee.getListEmployee());
                            }
                            else
                            {
                                manageProduct.SortByName();
                                manageProduct.ShowProduct(manageProduct.getListProduct());
                            }                           
                        }
                        else
                        {
                            Console.WriteLine($"\n{s}'s list is empty!");
                        }
                        break;
                    case 7:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            Console.WriteLine($"\n7. Sort {s} by ID.");
                            if (s.Equals("student"))
                            {
                                manageStudent.SortByID();
                                manageStudent.ShowStudent(manageStudent.getListStudent());
                            }
                            else if (s.Equals("employee"))
                            {
                                manageEmployee.SortByID();
                                manageEmployee.ShowEmployee(manageEmployee.getListEmployee());
                            }
                            else
                            {
                                manageProduct.SortByID();
                                manageProduct.ShowProduct(manageProduct.getListProduct());
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 8:
                        if (manageStudent.SoLuongStudent() > 0 || manageEmployee.SoLuongEmployee() > 0 || manageProduct.SoLuongProduct() > 0)
                        {
                            Console.WriteLine($"\n8. Show {s}'s list");
                            if (s.Equals("student"))
                            {
                                manageStudent.ShowStudent(manageStudent.getListStudent());
                            }
                            else if (s.Equals("employee"))
                            {
                                manageEmployee.ShowEmployee(manageEmployee.getListEmployee());
                            }
                            else
                            {
                                manageProduct.ShowProduct(manageProduct.getListProduct());
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nQuit program!");
                        return;
                    default:
                        Console.WriteLine("\nFuntion not support yet!");
                        Console.WriteLine("\nPlease chose function from menu");
                        break;
                }
            }
        }
    }
}