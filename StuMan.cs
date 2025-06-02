using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class StuMan
    {
        private List<Student> ListStudent = null;
 
        public StuMan() {
            ListStudent = new List<Student>();
        }
 
        /**
         * Hàm tạo ID tăng dần cho sinh viên
         */
        private int GenerateID()
        {
            int max = 1;
            if (ListStudent != null && ListStudent.Count > 0)
            {
                max = ListStudent[0].ID;
                foreach (Student st in ListStudent)
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
 
        public int SoLuongStudent()
        {
            int Count = 0;
            if (ListStudent != null)
            {
                Count = ListStudent.Count;
            }
            return Count;
        }
 
        public void EnterStudent()
        {
            // Khởi tạo một sinh viên mới
            Student st = new Student();
            st.ID = GenerateID();
            Console.Write("Enter student name: ");
            st.Name = Convert.ToString(Console.ReadLine());
 
            Console.Write("Enter student gender: ");
            st.Gender = Convert.ToString(Console.ReadLine());
 
            Console.Write("Enter student age: ");
            st.Age = Convert.ToInt32(Console.ReadLine());
 
            Console.Write("Enter math score: ");
            st.DiemToan = Convert.ToDouble(Console.ReadLine());
 
            Console.Write("Enter Vietnamese score: ");
            st.DiemVan = Convert.ToDouble(Console.ReadLine());
 
            Console.Write("Enter English score: ");
            st.DiemAnh = Convert.ToDouble(Console.ReadLine());
 
            TinhDTB(st);
            XepLoaiHocLuc(st);
 
            ListStudent.Add(st);
        }
 
        public void UpdateStudent(int ID)
        {
            // Tìm kiếm sinh viên trong danh sách ListStudent
            Student st = FindByID(ID);
            // Nếu sinh viên tồn tại thì cập nhập thông tin sinh viên
            if (st != null)
            {
                Console.Write("Enter student name: ");
                string name = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tên
                if (name != null && name.Length > 0)
                {
                    st.Name = name;
                }
 
                Console.Write("Enter student gender: ");
                // Nếu không nhập gì thì không cập nhật giới tính
                string gender = Convert.ToString(Console.ReadLine());
                if (gender != null && gender.Length > 0)
                {
                    st.Gender = gender;
                }
 
                Console.Write("Enter student age: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (ageStr != null && ageStr.Length > 0)
                {
                    st.Age = Convert.ToInt32(ageStr);
                }
 
                Console.Write("Enter math score: ");
                string diemToanStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (diemToanStr != null && diemToanStr.Length > 0)
                {
                    st.DiemToan = Convert.ToDouble(diemToanStr);
                }
 
                Console.Write("Enter Vietnamese score: ");
                string diemVanStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm văn
                if (diemVanStr != null && diemVanStr.Length > 0)
                {
                    st.DiemVan = Convert.ToDouble(diemVanStr);
                }
 
                Console.Write("Enter English score: ");
                string diemAnhStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm tiếng anh
                if (diemAnhStr != null && diemAnhStr.Length > 0)
                {
                    st.DiemAnh = Convert.ToDouble(diemAnhStr);
                }
 
                TinhDTB(st);
                XepLoaiHocLuc(st);
            }
            else
            {
                Console.WriteLine("student had ID = {0} not exits", ID);
            }
        }
 
        /**
         * Hàm sắp xếp danh sach student theo ID tăng dần
         */
        public void SortByID()
        {
            ListStudent.Sort(delegate (Student st1, Student st2) {
                return st1.ID.CompareTo(st2.ID);
            });
        }
 
        /**
         * Hàm sắp xếp danh sach student theo tên tăng dần
         */
        public void SortByName()
        {
            ListStudent.Sort(delegate (Student st1, Student st2) {
                return st1.Name.CompareTo(st2.Name);
            });
        }
 
        /**
         * Hàm sắp xếp danh sach student theo điểm TB tăng dần
         */
        public void SortByDiemTB()
        {
            ListStudent.Sort(delegate (Student st1, Student st2) {
                return st1.DiemTB.CompareTo(st2.DiemTB);
            });
        }
 
        /**
         * Hàm tìm kiếm sinh viên theo ID
         * Trả về một sinh viên
         */
        public Student FindByID(int ID)
        {
            Student searchResult = null;
            if (ListStudent != null && ListStudent.Count > 0)
            {
                foreach (Student st in ListStudent)
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
         * Hàm tìm kiếm sinh viên theo tên
         * Trả về một danh sách sinh viên
         */
        public List<Student> FindByName(String keyword)
        {
            List<Student> searchResult = new List<Student>();
            if (ListStudent != null && ListStudent.Count > 0)
            {
                foreach (Student st in ListStudent)
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
         * Hàm xóa sinh viên theo ID
         */
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            // tìm kiếm sinh viên theo ID
            Student st = FindByID(ID);
            if (st != null)
            {
                IsDeleted = ListStudent.Remove(st);
            }
            return IsDeleted;
        }
 
        /**
         * Hàm tính điểm TB cho sinh viên
         */
        private void TinhDTB(Student st)
        {
            double DiemTB = (st.DiemToan + st.DiemVan + st.DiemAnh) / 3;
            st.DiemTB = Math.Round(DiemTB, 2, MidpointRounding.AwayFromZero);
        }

        /**
         * Hàm xếp loại học lực cho sinh viên
         */
        private void XepLoaiHocLuc(Student st)
        {
            if (st.DiemTB >= 8)
            {
                st.HocLuc = "Gioi";
            }
            else if (st.DiemTB >= 6.5)
            {
                st.HocLuc = "Kha";
            }
            else if (st.DiemTB >= 5)
            {
                st.HocLuc = "Trung Binh";
            }
            else
            {
                st.HocLuc = "Yeu";
            }
        }
 
        /**
         * Hàm hiển thị danh sách sinh viên ra màn hình console
         */
        public void ShowStudent(List<Student> listst)
        {
            // hien thi tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                  "ID", "Name", "Gender", "Age", "Math", "Vietnamese", "English", "GPA", "Hoc Luc");
            // hien thi danh sach student
            if (listst != null && listst.Count > 0)
            {
                foreach (Student st in listst)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 6} {6, 10} {7, 12} {8, 10}",
                                      st.ID, st.Name, st.Gender, st.Age, st.DiemToan, st.DiemVan, st.DiemAnh,
                                      st.DiemTB, st.HocLuc);
                }
            }
            Console.WriteLine();
        }
 
        /*
         * Hàm trả về danh sách sinh viên hiện tại
         */
        public List<Student> getListStudent()
        {
            return ListStudent;
        }
    }
}
