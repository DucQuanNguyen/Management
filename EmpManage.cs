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
            Console.Write("Enter employee name: ");
            st.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Employee gender: ");
            st.Gender = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Employee age: ");
            st.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter jobPosition: ");
            st.jobPosition = Convert.ToString(Console.ReadLine());

            Console.Write("Enter salery: ");
            st.salery = Convert.ToDouble(Console.ReadLine());

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

                Console.Write("Enter employee gender: ");
                // Nếu không nhập gì thì không cập nhật giới tính
                string gender = Convert.ToString(Console.ReadLine());
                if (gender != null && gender.Length > 0)
                {
                    st.Gender = gender;
                }

                Console.Write("Enter employee age: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (ageStr != null && ageStr.Length > 0)
                {
                    st.Age = Convert.ToInt32(ageStr);
                }

                Console.Write("Enter jobPosition: ");
                string jobPositionStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (jobPositionStr != null && jobPositionStr.Length > 0)
                {
                    st.jobPosition = jobPositionStr;
                }

                Console.Write("Enter salery: ");
                string saleryStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm văn
                if (saleryStr != null && saleryStr.Length > 0)
                {
                    st.salery = Convert.ToDouble(saleryStr);
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
