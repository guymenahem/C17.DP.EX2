using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public interface IAlbumIterator : IIterator
    {
        void MovePrev();

        string ID
        {
            get;
        }
    }
}
