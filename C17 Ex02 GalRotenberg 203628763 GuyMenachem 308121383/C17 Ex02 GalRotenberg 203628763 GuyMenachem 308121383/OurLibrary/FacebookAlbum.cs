using System;
using System.Collections;
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
    public class FacebookAlbum : IEnumerable<FacebookPicture> 
    {
        public string ID { get; private set; }

        public string Name { get; private set; }

        private List<FacebookPicture> m_Photos;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AlbumIterator(this);
        }

        public IEnumerator<FacebookPicture> GetEnumerator()
        {
            return new AlbumIterator(this);
        }

        private class AlbumIterator : ICyclicEnumerator<FacebookPicture>
        {
            private FacebookAlbum m_AlbumToScan;
            private int m_Index;
            private int m_Count;

            public string ID
            {
                get { return m_AlbumToScan.ID; }
            }

            public AlbumIterator(FacebookAlbum i_AlbumToScan)
            {
                m_AlbumToScan = i_AlbumToScan;
                m_Index = 0;
                m_Count = i_AlbumToScan.m_Photos.Count;
            }

            public bool MoveNext()
            {
                if(++m_Index < m_Count)
                {
                    return true;
                }
                else
                {
                    m_Index = 0;
                    return false;
                }
            }

            public bool MovePrev()
            {
                if(--m_Index < 0)
                {
                    m_Index = m_Count - 1;
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public FacebookPicture Current
            {
               get { return m_AlbumToScan.m_Photos[m_Index]; }
            }

            object IEnumerator.Current
            {
                get { return m_AlbumToScan.m_Photos[m_Index] as object; }
            }

            public void Reset()
            {
                m_Index = 0;
            }

            public void Dispose()
            {
                m_AlbumToScan = null;
            }
        }
      
        private bool m_HasPhotos;

        private int m_CurPhoto;
        
        public FacebookAlbum(Album i_Album)
        {
            this.ID = i_Album.Id;
            m_CurPhoto = 0;
            this.Name = i_Album.Name;
            m_Photos = new List<FacebookPicture>();

            int checkPhotos = 0;
            foreach(Photo p in i_Album.Photos)
            {
                checkPhotos++;
                m_Photos.Add(new FacebookPicture(p.Id, p.PictureAlbumURL));
            }

            m_HasPhotos = checkPhotos > 0;
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

        public bool HasPhotos
        {
            get { return m_HasPhotos; }
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
