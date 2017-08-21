using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookPost : ILikeAble,ICommentable
    {
        public string ID { get; private set; }

        public string Description { get; private set; }

        public FacebookFriend From { get; private set; }
        
        public Post OriginalPost { get; private set; }

        public FacebookPost(Post i_Post, FacebookFriend i_Friend)
        {
            ID = i_Post.Id;
            Description = i_Post.Description + i_Post.Message;
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
