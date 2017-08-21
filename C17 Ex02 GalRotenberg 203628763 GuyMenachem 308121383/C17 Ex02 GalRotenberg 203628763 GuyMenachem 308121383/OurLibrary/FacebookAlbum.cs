using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace OurLibrary
{
    /// <summary>
    /// Class for facebook album
    /// </summary>
    public class FacebookAlbum
    {
        public string ID { get; private set; }

        public string Name { get; private set; }

        private List<FacebookPicture> m_Photos;

        private int m_CurPhoto;
        
        public FacebookAlbum(Album i_Album)
        {
            this.ID = i_Album.Id;
            m_CurPhoto = 0;
            this.Name = i_Album.Name;
            m_Photos = new List<FacebookPicture>();

            foreach(Photo p in i_Album.Photos)
            {
                m_Photos.Add(new FacebookPicture(p.Id, p.PictureAlbumURL));
            }
        }

        /// <summary>
        /// Get Current photo
        /// </summary>
        public FacebookPicture CurPhoto
        {
            get
            {
                return this.m_Photos[m_CurPhoto];
            }
        }

        public FacebookPicture NextPhoto
        {
            get
            {
                if (++this.m_CurPhoto >= m_Photos.Count)
                {
                    this.m_CurPhoto = 0;
                }

                return this.CurPhoto;
            }
        }

        public FacebookPicture PrevPhoto
        {
            get
            {
                if (--this.m_CurPhoto < 0)
                {
                    this.m_CurPhoto = this.m_Photos.Count - 1;
                }

                return this.CurPhoto;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
