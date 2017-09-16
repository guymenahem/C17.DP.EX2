using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public class FacebookPostAdapter : IFacebookPostAdapter
    {
        public string ID
        {
            get
            {
                return this.OriginalPost.Id;
            }
        }

        public string Description
        {
            get
            {
                return (this.OriginalPost.Description != null) ? this.OriginalPost.Description : string.Empty;
            }
        }

        public string Name
        {
            get
            {
                return (this.OriginalPost.Name != null) ? this.OriginalPost.Name : string.Empty; ;
            }
        }


        public FacebookFriendAdapter From { get; private set; }
        
        public Post OriginalPost { get; set; }

        public FacebookPostAdapter(Post i_Post)
        {
            OriginalPost = i_Post;
            From = new FacebookFriendAdapter(i_Post.From);
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
    }
}
