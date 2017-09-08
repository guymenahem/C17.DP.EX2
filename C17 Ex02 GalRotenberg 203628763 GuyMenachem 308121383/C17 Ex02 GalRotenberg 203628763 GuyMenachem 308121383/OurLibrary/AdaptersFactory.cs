using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public static class AdaptersFactory
    {
        public static Adapter CreateAdapter(object i_Referenced, AdaptersType i_ToAdapt)
        {
            Adapter result = null;

            switch(i_ToAdapt)
            {
                case AdaptersType.Event:
                    result = new FacebookEventAdapter(i_Referenced as Event);
                    break;
                case AdaptersType.Post:
                    result = new FacebookPostAdapter(i_Referenced as Post);
                    break;
            }
            if(result!=null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Selected option for adapter is unavailble");
            }
            
        }

        public enum AdaptersType
        {
            Event,
            Post
        }
    }
}
