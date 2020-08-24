using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IStream
    {
        char getNext();
        Boolean hasNext();
    }
}
