using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookFriendAdapter : IFacebookAdapter
    {
        public string ID
        {
            get
            {
                return this.OriginalUser.Id;
            }
        }

        public string Description
        {
            get
            {
                return this.Name;
            }
        }

        public string Name
        {
            get
            {
                return this.OriginalUser.Name;
            }
        }

        private User OriginalUser { get; set; }

        public string ProfilePicture
        {
            get
            {
                return this.OriginalUser.PictureNormalURL;
            }
        }

        public FacebookFriendAdapter(User i_friend)
        {
            this.OriginalUser = i_friend;
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
