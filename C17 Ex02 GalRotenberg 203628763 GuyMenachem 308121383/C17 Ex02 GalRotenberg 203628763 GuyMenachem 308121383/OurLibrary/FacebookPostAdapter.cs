using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookPostAdapter : IFacebookAdapter, ILikeAble, ICommentable, IComparable
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

        public string Name
        {
            get { return this.OriginalPost.Name; }
        }

        private string m_Title;
        public string Title
        {
            get
            {
                return m_Title;
            }

            private set
            {
                this.m_Title = value;
            }
        }

        public FacebookFriendAdapter From { get; private set; }
        
        public Post OriginalPost { get; set; }

        public FacebookPostAdapter(Post i_Post)
        {
            OriginalPost = i_Post;
            From = new FacebookFriendAdapter(i_Post.From);
            this.Title = this.BuildStringFromPost(this.OriginalPost);
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
            if(i_Comment != null)
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

        private string BuildStringFromPost(Post i_Post)
        {
            string ret = string.Empty;

            // Add decription
            if (i_Post.Description != null)
            {
                ret += i_Post.Description;
            }

            // Add message
            if (i_Post.Message != null)
            {
                ret += i_Post.Message;
            }

            return ret;
        }
    }
}
