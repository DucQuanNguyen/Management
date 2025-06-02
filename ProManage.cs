using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StudentManagement;

namespace Management
{
    class ProManage
    {
        private List<Product> ListProduct = null;

        public ProManage()
        {
            ListProduct = new List<Product>();
        }

        /**
         * Hàm tạo ID tăng dần cho sản phẩm
         */
        private int GenerateID()
        {
            int max = 1;
            if (ListProduct != null && ListProduct.Count > 0)
            {
                max = ListProduct[0].ID;
                foreach (Product st in ListProduct)
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

        public int SoLuongProduct()
        {
            int Count = 0;
            if (ListProduct != null)
            {
                Count = ListProduct.Count;
            }
            return Count;
        }

        public void EnterProduct()
        {
            // Khởi tạo một sản phẩm mới
            Product st = new Product();
            st.ID = GenerateID();
            Console.Write("Enter Product name: ");
            st.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Product model: ");
            st.model = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Product brand name: ");
            st.brandName = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Product price: ");
            st.price = Convert.ToDouble(Console.ReadLine());

            ListProduct.Add(st);
        }

        public void UpdateProduct(int ID)
        {
            // Tìm kiếm sản phẩm trong danh sách ListProduct
            Product st = FindByID(ID);
            // Nếu sản phẩm tồn tại thì cập nhập thông tin sản phẩm
            if (st != null)
            {
                Console.Write("Enter Product name: ");
                string name = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tên
                if (name != null && name.Length > 0)
                {
                    st.Name = name;
                }

                Console.Write("Enter Product model: ");
                // Nếu không nhập gì thì không cập nhật giới tính
                string modelStr = Convert.ToString(Console.ReadLine());
                if (modelStr != null && modelStr.Length > 0)
                {
                    st.model = modelStr;
                }

                Console.Write("Enter Product brand name: ");
                string brandStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (brandStr != null && brandStr.Length > 0)
                {
                    st.brandName = brandStr;
                }

                Console.Write("Enter price: ");
                string priceStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (priceStr != null && priceStr.Length > 0)
                {
                    st.price = Convert.ToDouble(priceStr);
                }
            }
            else
            {
                Console.WriteLine("Product had ID = {0} not exits", ID);
            }
        }

        /**
         * Hàm sắp xếp danh sach Product theo ID tăng dần
         */
        public void SortByID()
        {
            ListProduct.Sort(delegate (Product st1, Product st2) {
                return st1.ID.CompareTo(st2.ID);
            });
        }

        /**
         * Hàm sắp xếp danh sach Product theo tên tăng dần
         */
        public void SortByName()
        {
            ListProduct.Sort(delegate (Product st1, Product st2) {
                return st1.Name.CompareTo(st2.Name);
            });
        }

        /**
         * Hàm sắp xếp danh sach Product theo giá tăng dần
         */
        public void SortByPrice()
        {
            ListProduct.Sort(delegate (Product st1, Product st2) {
                return st1.price.CompareTo(st2.price);
            });
        }

        /**
         * Hàm tìm kiếm sản phẩm theo ID
         * Trả về một sản phẩm
         */
        public Product FindByID(int ID)
        {
            Product searchResult = null;
            if (ListProduct != null && ListProduct.Count > 0)
            {
                foreach (Product st in ListProduct)
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
         * Hàm tìm kiếm sản phẩm theo tên
         * Trả về một danh sách sản phẩm
         */
        public List<Product> FindByName(String keyword)
        {
            List<Product> searchResult = new List<Product>();
            if (ListProduct != null && ListProduct.Count > 0)
            {
                foreach (Product st in ListProduct)
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
         * Hàm xóa sản phẩm theo ID
         */
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            // tìm kiếm sản phẩm theo ID
            Product st = FindByID(ID);
            if (st != null)
            {
                IsDeleted = ListProduct.Remove(st);
            }
            return IsDeleted;
        }
        public void ShowProduct(List<Product> listst)
        {
            foreach (var item in listst)
            {
                item.Display();
            }
        }

        /*
         * Hàm trả về danh sách sản phẩm hiện tại
         */
        public List<Product> getListProduct()
        {
            return ListProduct;
        }
    }
}
