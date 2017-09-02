using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookPostAdapter : ILikeAble,ICommentable
    {
        public string ID
        {
            get
            {
                return this.OriginalPost.ObjectID;
            }
        }

        public string Description
        {
            get
            {
                return this.OriginalPost.Description + this.OriginalPost.Message;
            }
        }

        public FacebookFriend From { get; private set; }
        
        public Post OriginalPost { get; private set; }

        public FacebookPostAdapter(Post i_Post, FacebookFriend i_Friend)
        {
            From = i_Friend;
            OriginalPost = i_Post;
        }

        public override string ToString()
        {
            return this.Description;
        }

        public void Comment(string i_Comment)
        {
            throw new NotImplementedException();
        }

        public void Like()
        {
            throw new NotImplementedException();
        }
    }
}
