using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurLibrary
{
    public class FacebookPicture : IHavePicture,ILikeAble,ICommentable
    {
        public string ID { get; private set; }
        public string URL { get; private set; }

        public FacebookPicture(string i_URL)
        {
            this.URL = i_URL;
        }

        public FacebookPicture(string i_Id, string i_Url)
        {
            this.ID = i_Id;
            this.URL = i_Url;
        }

        public string GetPicture()
        {
            return this.URL;
        }

        public void Like()
        {
            throw new NotImplementedException();
        }

        public void Comment(string i_Comment)
        {
            throw new NotImplementedException();
        }
    }
}
