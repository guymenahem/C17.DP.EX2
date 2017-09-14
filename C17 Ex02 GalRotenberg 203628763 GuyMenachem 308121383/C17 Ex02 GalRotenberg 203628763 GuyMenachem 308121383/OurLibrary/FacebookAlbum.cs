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
    public class FacebookAlbum : IAggregate //: IEnumerable<FacebookPicture>
    {
        public string ID { get; private set; }

        public string Name { get; private set; }

        private List<FacebookPicture> m_Photos;

        public IIterator CreateIterator()
        {
            return new FacebookAlbumIterator(this);
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

        private class FacebookAlbumIterator : IAlbumIterator
        {
            private FacebookAlbum m_AlbumToScan;
            private int m_Index;
            private int m_Count;

            public string ID
            {
                get { return m_AlbumToScan.ID; }
            }

            public FacebookAlbumIterator(FacebookAlbum i_AlbumToScan)
            {
                m_AlbumToScan = i_AlbumToScan;
                m_Index = 0;
                m_Count = m_AlbumToScan.m_Photos.Count;
            }

            public bool MoveNext()
            {
                if(++m_Index >= m_Count)
                {
                    m_Index = 0;
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void MovePrev()
            {
                if(--m_Index < 0)
                {
                    m_Index = m_Count - 1;
                }
            }

            public object getCurrent()
            {
                return this.m_AlbumToScan.m_Photos[m_Index];
            }

            public void Reset()
            {
                this.m_Index = 0;
            }
        }

        /*
        private class FacebookAlbumIterator : IEnumerator<FacebookPicture>, IDisposable
        {
            private FacebookAlbum m_Collection;
            private int m_Index;
            private int m_Count;

            public FacebookAlbumIterator(FacebookAlbum i_Collection)
            {
                m_Collection = i_Collection;
                m_Index = -1;
                m_Count = m_Collection.m_Photos.Count;
            }

            public FacebookPicture Current
            {
                get
                    {
                        return m_Collection.m_Photos[m_Index];
                    }
            }

            public bool MoveNext()
            {
                return m_Index++ < m_Count;
            }

            public void Reset()
            {
                m_Index = 0;
            }

            public void Dispose()
            {
                this.m_Collection = null;
                this.m_Index = -1;
                this.m_Count = -1;
            }
        }
        */
    }
}
