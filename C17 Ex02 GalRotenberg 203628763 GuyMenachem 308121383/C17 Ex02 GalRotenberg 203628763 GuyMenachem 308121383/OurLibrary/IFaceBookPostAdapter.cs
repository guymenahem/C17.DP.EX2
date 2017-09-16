using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    public interface IFacebookPostAdapter : IFacebookAdapter, ILikeAble, ICommentable, IComparable
    {
        Post OriginalPost { get; set; }
        string ToString();
        FacebookFriendAdapter From { get; }
    }
}
