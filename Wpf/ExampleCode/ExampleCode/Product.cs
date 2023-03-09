using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCode
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Product() { }

        public Product(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
