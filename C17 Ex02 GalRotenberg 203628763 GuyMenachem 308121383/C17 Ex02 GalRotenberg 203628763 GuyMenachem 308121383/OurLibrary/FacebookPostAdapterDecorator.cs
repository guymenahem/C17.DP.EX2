using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public abstract class FacebookPostAdapterDecorator : IFacebookPostAdapter
    {
        protected IFacebookPostAdapter Post { get; set; }

        protected FacebookPostAdapterDecorator(IFacebookPostAdapter i_Post)
        {
            this.Post = i_Post;
        }

        public string Name
        {
            get
            {
                return this.Post.Name;
            }
        }

        public string ID
        {
            get
            {
                return this.Post.ID;
            }
        }

        public string Description
        {
            get
            {
                return this.Post.Description;
            }
        }

        public Post OriginalPost
        {
            set
            {
                this.Post.OriginalPost = value;
            }

            get
            {
                return this.Post.OriginalPost;
            }
        }

        public FacebookFriendAdapter From
        {
            get
            {
                return this.Post.From;
            }
        }

        public void Like()
        {
            this.Post.Like();
        }

        public void Comment(string i_Comment)
        {
            this.Post.Comment(i_Comment);
        }

        public int CompareTo(object obj)
        {
            return this.Post.CompareTo(obj);
        }
    }
}
