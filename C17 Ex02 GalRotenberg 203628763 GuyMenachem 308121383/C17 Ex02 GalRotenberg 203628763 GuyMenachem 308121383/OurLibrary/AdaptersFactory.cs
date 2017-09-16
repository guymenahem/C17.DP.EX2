using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public static class AdaptersFactory
    {
        public static IFacebookAdapter CreateAdapterFromFacebookObj(object i_FacebookObj)
        {
            if(i_FacebookObj is Post)
            {
                return new FacebookPostAdaFullTitleDecorator(new FacebookPostAdapter((Post)i_FacebookObj));
            }
            else if(i_FacebookObj is Event)
            {
                return new FacebookEventAdapter((Event)i_FacebookObj);
            }
            else if(i_FacebookObj is User)
            {
                return new FacebookFriendAdapter((User)i_FacebookObj);
            }
            else
            {
                throw new Exception("object if not supported by Adapter factory");               
            }
        }
    }
}
