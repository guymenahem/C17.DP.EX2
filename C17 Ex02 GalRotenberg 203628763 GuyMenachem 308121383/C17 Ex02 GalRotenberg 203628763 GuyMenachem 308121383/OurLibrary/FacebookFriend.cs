using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookFriend
    {
        public string ID { get; private set; }

        public string Name { get; private set; }


        public string ProfilePicture { get; private set; }

        public FacebookFriend(User i_friend)
        {
            ID = i_friend.Id;
            Name = i_friend.Name;
            ProfilePicture = i_friend.PictureSmallURL;
        }

        public bool Compare(User i_user)
        {
            return this.ID == i_user.Id;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
