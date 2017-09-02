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
        /// <summary>
        /// Cover photo URL
        /// </summary>
        /// <returns></returns>
        public string CoverPhoto
        {
            get
            {
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
                return FacebookUser.Instance().ProfilePictureUrl;
            }
        }

        public void Connect(string i_UserAccessToken)
        {
            FacebookUser.Instance(i_UserAccessToken);
        }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName
        {
            get
            {
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
        public ICollection<string> FetchPosts()
        {
            return FacebookUser.Instance().FetchPosts();
        }

        /// <summary>
        /// Fetch of tagged posts
        /// </summary>
        /// <returns>get all posts the users taaged at</returns>
        public ICollection<FacebookPostAdapter> FetchTaggedPosts()
        {
            return FacebookUser.Instance().GetTaggedPosts();
        }

        /// <summary>
        /// Fetch all user albums
        /// </summary>
        /// <returns>Collection of albums</returns>
        public ICollection<FacebookAlbum> FetchAlbums()
        {
            return FacebookUser.Instance().GetUserAlbums();
        }

        /// <summary>
        /// Fetch user events
        /// </summary>
        /// <returns>Collection of the user events</returns>
        public ICollection<FacebookEvent> FetchEvents()
        {
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
        /// Make a user attend to events
        /// </summary>
        /// <param name="i_Events">Events</param>
        /// <param name="i_AttendStatus">Status of attendetion</param>
        public void AttendTo(List<FacebookEvent> i_Events, string i_AttendStatus)
        {
            FacebookUser.Instance().AttendTo(i_Events, i_AttendStatus);
        }

        /// <summary>
        /// Get users friends
        /// </summary>
        /// <returns>Collection of friends</returns>
        public ICollection<FacebookFriend> FetchFriends()
        {
            return FacebookUser.Instance().GetUserFriends();
        }

        /// <summary>
        /// Get posts from friends
        /// </summary>
        /// <param name="i_friends">friends to get posts from</param>
        /// <returns></returns>
        public ICollection<FacebookPostAdapter> GetPostsFromFriends(ICollection<FacebookFriend> i_friends)
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
    }
}
