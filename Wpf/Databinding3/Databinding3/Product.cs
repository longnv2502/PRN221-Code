using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databinding3
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Product(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
