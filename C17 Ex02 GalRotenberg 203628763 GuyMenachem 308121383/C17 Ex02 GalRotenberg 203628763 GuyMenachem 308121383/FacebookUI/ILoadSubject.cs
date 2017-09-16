using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    interface ILoadSubject
    {
        void Observe(ILoadObserver observer);

        void RemoveObserver(ILoadObserver observer);
    }
}
