using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding01.Model
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Product() {
            ID = 4;
            Name = "Nguyen Hoan";
        }
    }
}
