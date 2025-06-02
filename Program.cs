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
            while (true)
            {
                Console.WriteLine("\nStudent management program");
                Console.WriteLine("\n1. Add student");
                Console.WriteLine("2. Update student infomation by ID");
                Console.WriteLine("3. Delete student by ID");
                Console.WriteLine("4. Search student by Name");
                Console.WriteLine("5. Sort student by GPA");
                Console.WriteLine("6. Sort student by Name");
                Console.WriteLine("7. Sort student by ID");
                Console.WriteLine("8. Show student's list");
                Console.WriteLine("0. Quit\n");
                Console.Write("Enter selection: ");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("\n1. add student");
                        manageStudent.EnterStudent();
                        Console.WriteLine("\nAdd student succes!");
                        break;
                    case 2:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            int id;
                            Console.WriteLine("\n2. Update student infomation");
                            Console.Write("\nEnter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            manageStudent.UpdateStudent(id);
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 3:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            int id;
                            Console.WriteLine("\n3. Delete student");
                            Console.Write("\nEnter ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            if (manageStudent.DeleteById(id))
                            {
                                Console.WriteLine("\nstudent had id = {0} is deleted", id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 4:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            Console.WriteLine("\n4. Search student by name");
                            Console.Write("\nEnter student's name: ");
                            string name = Convert.ToString(Console.ReadLine());
                            List<Student> searchResult = manageStudent.FindByName(name);
                            manageStudent.ShowStudent(searchResult);
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 5:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            Console.WriteLine("\n5. Sort student by GPA");
                            manageStudent.SortByDiemTB();
                            manageStudent.ShowStudent(manageStudent.getListStudent());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 6:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            Console.WriteLine("\n6. Sort student by name");
                            manageStudent.SortByName();
                            manageStudent.ShowStudent(manageStudent.getListStudent());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 7:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            Console.WriteLine("\n6. Sort student by ID.");
                            manageStudent.SortByID();
                            manageStudent.ShowStudent(manageStudent.getListStudent());
                        }
                        else
                        {
                            Console.WriteLine("\nStudent's list is empty!");
                        }
                        break;
                    case 8:
                        if (manageStudent.SoLuongStudent() > 0)
                        {
                            Console.WriteLine("\n7. Show student's list");
                            manageStudent.ShowStudent(manageStudent.getListStudent());
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