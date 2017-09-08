using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookPostAdapter : Adapter, ILikeAble,ICommentable,IComparable
    {

        public override string ID
        {
            get
            {
                return this.OriginalPost.ObjectID;
            }
        }

        public override string Description
        {
            get
            {
                return this.OriginalPost.Description + this.OriginalPost.Message;
            }
        }

        public override string Name
        {
            get { return this.OriginalPost.Name; }
        }

        public FacebookFriend From { get; private set; }
        
        public Post OriginalPost {  get; private set; }

        public FacebookPostAdapter(Post i_Post)
        {
            OriginalPost = i_Post;
            From = new FacebookFriend(i_Post.From);
        }

        public override string ToString()
        {
            return this.Description;
        }

        public int CompareTo(object obj)
        {
            FacebookPostAdapter fpa = obj as FacebookPostAdapter;

            if(fpa == null)
            {
                return -1;
            }

            if(this.OriginalPost.UpdateTime > fpa.OriginalPost.UpdateTime)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public void Comment(string i_Comment)
        {
            if(i_Comment!=null)
            {
                this.OriginalPost.Comment(i_Comment);
            }
            else
            {
                throw new ArgumentException("cant send empty message as comment.");
            }
        }

        public void Like()
        {
            this.OriginalPost.Like();
        }
    }
}
