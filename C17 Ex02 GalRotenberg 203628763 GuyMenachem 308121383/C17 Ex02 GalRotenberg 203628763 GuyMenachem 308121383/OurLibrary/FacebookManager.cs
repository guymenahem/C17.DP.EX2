using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using OurLibrary;
using static System.Windows.Forms.CheckedListBox;

namespace FacebookLogicUnit
{
    public class FacebookManager
    {
        private bool m_Connected;

        private ICyclicEnumerator<FacebookPicture> m_Iterator = null;

        /// <summary>
        /// Cover photo URL
        /// </summary>
        /// <returns></returns>
        public string CoverPhoto
        {
            get
            {
                m_Connected = true;
                return FacebookUser.Instance().CoverPhoto;
            }
        }

        /// <summary>
        /// Profile photo URL
        /// </summary>
        /// <returns></returns>
        public string ProfilePhoto
        {
            get
            {
                m_Connected = true;
                return FacebookUser.Instance().ProfilePictureUrl;
            }
        }

        public void Connect(string i_UserAccessToken)
        {
            FacebookUser.Instance(i_UserAccessToken);
            m_Connected = true;
        }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName
        {
            get
            {
                m_Connected = true;
                return FacebookUser.Instance().Name;
            }
        }

        public void LogIn()
        {
            throw new NotImplementedException();
        }

        /*
        /// <summary>
        /// Connect user to facebook
        /// </summary>
        /// <param name="userAccessToken">Access tocken of user</param>
        public void Connect(string userAccessToken)
        {
            this.User = new FacebookUser(FacebookService.Connect(userAccessToken).LoggedInUser);
        }
        */

        /// <summary>
        /// Fetch all posts of connected user
        /// </summary>
        /// <returns>COllection of posts</returns>
        public ICollection<IFacebookPostAdapter> FetchPosts()
        {
            m_Connected = true;
            return FacebookUser.Instance().FetchPosts();
        }

        /// <summary>
        /// Fetch of tagged posts
        /// </summary>
        /// <returns>get all posts the users taaged at</returns>
        public ICollection<FacebookPostAdapter> FetchTaggedPosts()
        {
            m_Connected = true;
            return FacebookUser.Instance().GetTaggedPosts();
        }

        /// <summary>
        /// Fetch all user albums
        /// </summary>
        /// <returns>Collection of albums</returns>
        public ICollection<FacebookAlbum> FetchAlbums()
        {
            m_Connected = true;
            return FacebookUser.Instance().GetUserAlbums();
        }

        /// <summary>
        /// Fetch user events
        /// </summary>
        /// <returns>Collection of the user events</returns>
        public ICollection<FacebookEventAdapter> FetchEvents()
        {
            m_Connected = true;
            return FacebookUser.Instance().FetchEvents();
        }

        /// <summary>
        /// Posts a meesage to a logged in user
        /// </summary>
        /// <param name="i_Message">Message</param>
        /// <returns>status</returns>
        public bool PostMessage(string i_Message)
        {
            return FacebookUser.Instance().Post(i_Message);
        }

        /// <summary>
        /// Get users friends
        /// </summary>
        /// <returns>Collection of friends</returns>
        public ICollection<FacebookFriendAdapter> FetchFriends()
        {
            return FacebookUser.Instance().GetUserFriends();
        }

        /// <summary>
        /// Get posts from friends
        /// </summary>
        /// <param name="i_friends">friends to get posts from</param>
        /// <returns></returns>
        public ICollection<IFacebookPostAdapter> GetPostsFromFriends(ICollection<FacebookFriendAdapter> i_friends)
        {
            return FacebookUser.Instance().GetFriendsPosts(i_friends);
        }

        /// <summary>
        /// Like and comment
        /// </summary>
        /// <param name="i_TaggedPosts">Posts to like and comment</param>
        /// <param name="i_Msg">Message</param>
        public void LikeAndComment(ObjectCollection i_TaggedPosts, string i_Msg)
        {
            FacebookUser.Instance().LikeAndComment(i_TaggedPosts, i_Msg);
        }

        public void LikeAndComment(CheckedItemCollection i_TaggedPosts, string i_Msg)
        {
            FacebookUser.Instance().LikeAndComment(i_TaggedPosts, i_Msg);
        }

        public bool IsConnected()
        {
            return m_Connected;
        }

        private string FromObjToPic(object i_Pic)
        {
            FacebookPicture pic = i_Pic as FacebookPicture;
            return pic.URL;
        }

        public string AlbumChanged(FacebookAlbum album)
        {
            if((m_Iterator == null) || (m_Iterator.ID != album.ID))
            {
                m_Iterator = (ICyclicEnumerator<FacebookPicture>)album.GetEnumerator();
            }

            return m_Iterator.Current.URL;   
        }

        public string NextPhoto()
        {
            m_Iterator.MoveNext();
            return m_Iterator.Current.URL;
        }

        public string PrevPhoto()
        {
            m_Iterator.MovePrev();
            return m_Iterator.Current.URL;
        }
    }
}
