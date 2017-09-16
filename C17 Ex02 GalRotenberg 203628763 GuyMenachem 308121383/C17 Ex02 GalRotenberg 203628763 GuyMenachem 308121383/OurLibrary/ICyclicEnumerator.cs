using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public interface ICyclicEnumerator<T> : IEnumerator<T>
    {
        bool MovePrev();

        string ID
        {
            get;
        }
    }
}
