using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public interface ICustomerList
    {
        void Add(IItem item);
        void DisplayList();
    }
}
