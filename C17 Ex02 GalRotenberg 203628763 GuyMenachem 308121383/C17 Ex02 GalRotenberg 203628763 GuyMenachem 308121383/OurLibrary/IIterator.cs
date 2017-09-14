using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public interface IIterator
    {
        bool MoveNext();
        object getCurrent();
        void Reset();
    }
}
