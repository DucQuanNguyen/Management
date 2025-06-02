using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement;

namespace Management
{
    class EmpManage
    {
        private List<Employee> ListEmployee = null;

        public EmpManage()
        {
            ListEmployee = new List<Employee>();
        }

        /**
         * Hàm tạo ID tăng dần cho nhân viên
         */
        private int GenerateID()
        {
            int max = 1;
            if (ListEmployee != null && ListEmployee.Count > 0)
            {
                max = ListEmployee[0].ID;
                foreach (Employee st in ListEmployee)
                {
                    if (max < st.ID)
                    {
                        max = st.ID;
                    }
                }
                max++;
            }
            return max;
        }

        public int SoLuongEmployee()
        {
            int Count = 0;
            if (ListEmployee != null)
            {
                Count = ListEmployee.Count;
            }
            return Count;
        }

        public void EnterEmployee()
        {
            // Khởi tạo một nhân viên mới
            Employee st = new Employee();
            st.ID = GenerateID();
            do
            {
                Console.Write("Enter employee name: ");
                st.Name = Convert.ToString(Console.ReadLine());
                if (st.Name.Equals(null))
                {
                    Console.WriteLine("Please enter employee name!");
                }
            } while (st.Name.Equals(null));
            //check giới tính
            int gen;
            do
            {
                Console.Write("Chose employee gender: ");
                Console.Write("1. Male");
                Console.Write("2. Female");
                Console.Write("3. Other");
                gen = Convert.ToInt32(Console.ReadLine());
                if (gen != 1 || gen != 2 || gen != 3)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (gen != 1 || gen != 2 || gen != 3);
            //nhập giới tính
            switch (gen)
            {
                case 1:
                    st.Gender = "Male";
                    break;
                case 2:
                    st.Gender = "Female";
                    break;
                default:
                    st.Gender = "Other";
                    break;
            }
            int tAge;
            //nhập tuổi
            do
            {
                Console.Write("Enter employee age: ");
                tAge = Convert.ToInt32(Console.ReadLine());
                if (tAge is < 0 or > 80)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tAge is < 0 or > 80);
            //nhập vị trí công việc
            do
            {
                Console.Write("Enter jobPosition: ");
                st.jobPosition = Convert.ToString(Console.ReadLine());
                if (st.jobPosition.Equals(null))
                {
                    Console.WriteLine("Please enter employee jobPosition!");
                }
            } while (st.jobPosition.Equals(null));

            double tSal;
            //nhập mức lương
            do
            {
                Console.Write("Enter salery: ");
                tSal = Convert.ToDouble(Console.ReadLine());
                if (tSal < 100)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tSal < 100);
            st.salery = tSal;

            ListEmployee.Add(st);
        }

        public void UpdateEmployee(int ID)
        {
            // Tìm kiếm nhân viên trong danh sách ListEmployee
            Employee st = FindByID(ID);
            // Nếu nhân viên tồn tại thì cập nhập thông tin nhân viên
            if (st != null)
            {
                Console.Write("Enter employee name: ");
                string name = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tên
                if (name != null && name.Length > 0)
                {
                    st.Name = name;
                }
                //check giới tính để update
                int gen;
                do
                {
                    Console.Write("Chose employee gender: ");
                    Console.Write("1. Male");
                    Console.Write("2. Female");
                    Console.Write("3. Other");
                    gen = Convert.ToInt32(Console.ReadLine());
                    if (gen != 1 || gen != 2 || gen != 3)
                    {
                        Console.WriteLine("Input invalid!");
                    }
                } while (gen != 1 || gen != 2 || gen != 3);
                //update giới tính
                switch (gen)
                {
                    case 1:
                        st.Gender = "Male";
                        break;
                    case 2:
                        st.Gender = "Female";
                        break;
                    default:
                        st.Gender = "Other";
                        break;
                }
                //update tuổi
                Console.Write("Enter employee age: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (ageStr != null && ageStr.Length > 0)
                {
                    st.Age = Convert.ToInt32(ageStr);
                }

                //update vị trí công viêc
                Console.Write("Enter jobPosition: ");
                String tJobPosition = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật
                if (tJobPosition != null && tJobPosition.Length > 0)
                {
                    st.jobPosition = tJobPosition;
                }
                Console.Write("Enter salery: ");
                String tSal = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật
                if (tSal != null && tSal.Length > 0)
                {
                    st.salery = Convert.ToDouble(tSal);
                }
                
            }
            else
            {
                Console.WriteLine("Employee had ID = {0} not exits", ID);
            }
        }

        /**
         * Hàm sắp xếp danh sach Employee theo ID tăng dần
         */
        public void SortByID()
        {
            ListEmployee.Sort(delegate (Employee st1, Employee st2) {
                return st1.ID.CompareTo(st2.ID);
            });
        }
        /**
         * Hàm sắp xếp danh sach Employee theo vị trí công việc tăng dần theo bảng chữ cái
         */
        public void SortByJobposition()
        {
            ListEmployee.Sort(delegate (Employee st1, Employee st2) {
                return st1.jobPosition.CompareTo(st2.jobPosition);
            });
        }

        /**
         * Hàm sắp xếp danh sach Employee theo tên tăng dần
         */
        public void SortByName()
        {
            ListEmployee.Sort(delegate (Employee st1, Employee st2) {
                return st1.Name.CompareTo(st2.Name);
            });
        }

        /**
         * Hàm tìm kiếm nhân viên theo ID
         * Trả về một nhân viên
         */
        public Employee FindByID(int ID)
        {
            Employee searchResult = null;
            if (ListEmployee != null && ListEmployee.Count > 0)
            {
                foreach (Employee st in ListEmployee)
                {
                    if (st.ID == ID)
                    {
                        searchResult = st;
                    }
                }
            }
            return searchResult;
        }

        /**
         * Hàm tìm kiếm nhân viên theo tên
         * Trả về một danh sách nhân viên
         */
        public List<Employee> FindByName(String keyword)
        {
            List<Employee> searchResult = new List<Employee>();
            if (ListEmployee != null && ListEmployee.Count > 0)
            {
                foreach (Employee st in ListEmployee)
                {
                    if (st.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(st);
                    }
                }
            }
            return searchResult;
        }

        /**
         * Hàm xóa nhân viên theo ID
         */
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            // tìm kiếm nhân viên theo ID
            Employee st = FindByID(ID);
            if (st != null)
            {
                IsDeleted = ListEmployee.Remove(st);
            }
            return IsDeleted;
        }
        public void ShowEmployee(List<Employee> listst)
        {
            foreach (var item in listst)
            {
                item.Display();
            }
        }

        /*
         * Hàm trả về danh sách nhân viên hiện tại
         */
        public List<Employee> getListEmployee()
        {
            return ListEmployee;
        }
    }
}
