using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public class FacebookPostAdaFullTitleDecorator : FacebookPostAdapterDecorator
    {
        public FacebookPostAdaFullTitleDecorator(IFacebookPostAdapter post)
            : base(post)
        {
            
        }

        public override string ToString()
        {
            return this.Post.OriginalPost.Description + this.Post.OriginalPost.Message;
        }
    }
}
