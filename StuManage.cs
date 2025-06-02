using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management;

namespace StudentManagement
{
    class StuManage
    {
        private List<Student> ListStudent = null;

        public StuManage() {
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
            //nhập tên sinh viên
            do
            {
                Console.Write("Enter student name: ");
                st.Name = Convert.ToString(Console.ReadLine());
                if (st.Name.Equals(null))
                {
                    Console.WriteLine("Please enter student name!");
                }
            } while (st.Name.Equals(null));            
            //nhập giới tính sinh viên
            int gen;
            do
            {
                Console.Write("Chose student gender: ");
                Console.Write("1. Male");
                Console.Write("2. Female");
                Console.Write("3. Other");
                gen = Convert.ToInt32(Console.ReadLine());
                if(gen != 1 || gen != 2 || gen != 3)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (gen != 1 || gen != 2 || gen != 3);

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
            double tMath, tVn, tEng;
            //check tuổi sinh viên
            do
            {
                Console.Write("Enter student age: ");
                tAge = Convert.ToInt32(Console.ReadLine());
                if(tAge is < 0 or > 100)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tAge is < 0 or > 100);
            //check điểm toán
            do
            {
                Console.Write("Enter math score: ");
                tMath = Convert.ToDouble(Console.ReadLine());
                if (tMath is < 0 or > 10)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tMath is < 0 or > 10);
            //check điểm văn
            do
            {
                Console.Write("Enter Vietnamese score: ");
                tVn = Convert.ToDouble(Console.ReadLine());
                if (tVn is < 0 or > 10)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tVn is < 0 or > 10);
            //check điểm anh
            do
            {
                Console.Write("Enter English score: ");
                tEng = Convert.ToDouble(Console.ReadLine());
                if (tEng is < 0 or > 10)
                {
                    Console.WriteLine("Input invalid!");
                }
            } while (tEng is < 0 or > 10);
            //lưu và tính điểm
            st.Age = tAge;
            st.DiemToan = tMath;
            st.DiemVan = tVn;
            st.DiemAnh = tEng;
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
                //check gender
                int gen;
                do
                {
                    Console.Write("Chose student gender: ");
                    Console.Write("1. Male");
                    Console.Write("2. Female");
                    Console.Write("3. Other");
                    gen = Convert.ToInt32(Console.ReadLine());
                    if (gen != 1 || gen != 2 || gen != 3)
                    {
                        Console.WriteLine("Input invalid!");
                    }
                } while (gen != 1 || gen != 2 || gen != 3);
                //nhập gender để update
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
            foreach (var item in listst)
            {
                item.Display();
            }
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
