using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public interface IFacebookAdapter
    {
        string Name { get; }

        string ID { get; }

        string Description { get; }
    }
}
