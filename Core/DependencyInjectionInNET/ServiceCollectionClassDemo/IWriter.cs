using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCollectionClassDemo
{
    public interface IXMLWriter
    {
        void WriteXML();
    }
    public interface IJSONWriter
    {
        void WriteJSON();
    }
}
