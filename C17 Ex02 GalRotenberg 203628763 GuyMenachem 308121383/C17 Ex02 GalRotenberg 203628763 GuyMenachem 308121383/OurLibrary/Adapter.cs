using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public abstract class Adapter
    {
        public virtual string Name { get; }

        public virtual string ID { get; }

        public virtual string Description { get; }
    }
}
