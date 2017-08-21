using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using static System.Windows.Forms.CheckedListBox;

namespace OurLibrary
{
    public class FacebookUser
    {
        // Facebook user
        private FacebookWrapper.ObjectModel.User m_user;
        private List<FacebookFriend> m_Friends;

        /// <summary>
        /// Ctor from logged in user - API object
        /// </summary>
        /// <param name="i_LoggedInUser">User</param>
        public FacebookUser(User i_LoggedInUser)
        {
            m_user = i_LoggedInUser;
            m_Friends = new List<FacebookFriend>();
            foreach (User friend in m_user.Friends)
            {
                m_Friends.Add(new FacebookFriend(friend));
            }
        }

        /// <summary>
        /// Name of user
        /// </summary>
        public string Name
        {
            get { return m_user.Name; }
        }

        /// <summary>
        /// Profile picture
        /// </summary>
        public string ProfilePictureUrl
        {
            get
            {
                return this.m_user.PictureNormalURL;
            }
        }

        /// <summary>
        /// Cover photo
        /// </summary>
        public string CoverPhoto
        {
            get { return m_user.Cover.SourceURL; }
        }

        public bool Post(string i_PostMsg)
        {
            if (i_PostMsg.Length == 0)
            {
                return false;
            }
            else
            {
                m_user.PostStatus(i_PostMsg);
                return true;
            }
        }

        /// <summary>
        /// Attend to events
        /// </summary>
        /// <param name="i_Events">events to attend</param>
        /// <param name="i_AttendStatus">action</param>
        internal void AttendTo(List<FacebookEvent> i_Events, string i_AttendStatus)
        {
            foreach (FacebookEvent even in i_Events)
            {
                // TODO: create cache for events/users/etc.. for faster operations on logic side...
                foreach (Event realEvent in m_user.Events)
                {
                    if (realEvent.Id == even.ID)
                    {
                        if (i_AttendStatus == "Attending")
                        {
                            realEvent.Respond(Event.eRsvpType.Attending);
                        }
                        else if (i_AttendStatus == "Maybe")
                        {
                                realEvent.Respond(Event.eRsvpType.Maybe);
                        }
                        else
                        {
                            realEvent.Respond(Event.eRsvpType.Declined);
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get all user albums
        /// </summary>
        /// <returns>Albums</returns>
        public ICollection<FacebookAlbum> GetUserAlbums()
        {
            ICollection<FacebookAlbum> rslt = new List<FacebookAlbum>();

            foreach (Album album in m_user.Albums)
            {
                rslt.Add(new FacebookAlbum(album));
            }

            return rslt;
        }

        /// <summary>
        /// Get user events
        /// </summary>
        /// <returns>Events</returns>
        public ICollection<FacebookEvent> GetEvents()
        {
            ICollection<FacebookEvent> rslt = new List<FacebookEvent>();
            foreach (Event e in m_user.Events)
            {
               rslt.Add(new FacebookEvent(e));
            }

            return rslt;
        }

        public ICollection<FacebookPost> GetTaggedPosts()
        {
            ICollection<FacebookPost> rslt = new List<FacebookPost>();

            foreach (User friend in m_user.Friends)
            {
                foreach (Post post in friend.Posts)
                {
                    foreach (User tagged in post.TaggedUsers)
                    {
                        if (tagged.Id == this.m_user.Id)
                        {
                            rslt.Add(new FacebookPost(post, FindFriend(friend.Id)));
                        }
                    }
                }
            }

            return rslt;
        }

        public bool RespondToEvent(string i_Id, Event.eRsvpType i_RespType)
        {
            Event CurrentEvent;
            foreach (Event e in m_user.Events)
            {
                if (e.Id == i_Id)
                {
                    CurrentEvent = e;
                    CurrentEvent.Respond(i_RespType);
                    return true;
                }
            }

            return false;
        }

        public ICollection<FacebookEvent> FetchEvents()
        {
            ICollection<FacebookEvent> rslt = new List<FacebookEvent>();

            foreach (Event evnt in m_user.Events)
            {
                rslt.Add(new FacebookEvent(evnt));
            }

            return rslt;
        }

        private FacebookFriend FindFriend(string i_ID)
        {
            FacebookFriend rslt = null;
            foreach (FacebookFriend friend in m_Friends)
            {
                if (friend.ID == i_ID)
                {
                    rslt = friend;
                    break;
                }
            }

            return rslt;
        }

        private string buildStringFromPost(Post i_Post)
        {
            string ret = string.Empty;

            // Add decription
            if (i_Post.Description != null)
            {
                ret += i_Post.Description;
            }

            // Add message
            if (i_Post.Message != null)
            {
                ret += i_Post.Message;
            }

            return ret;
        }

        public ICollection<string> FetchPosts()
        {
            // Create for output
            ICollection<string> rslt = new List<string>();

            // For each post
            foreach (Post p in m_user.Posts)
            {
                // get string from post
                string curPost = this.buildStringFromPost(p);

                if (curPost != string.Empty)
                {
                    rslt.Add(curPost);
                }
            }

            return rslt;
        }

        public ICollection<FacebookFriend> GetUserFriends()
        {
            return this.m_Friends;
        }

        public ICollection<FacebookPost> GetFriendsPosts(ICollection<FacebookFriend> i_Friends)
        {
            Dictionary<string, FacebookPost> posts = new Dictionary<string, FacebookPost>();

            foreach(User curUser in this.m_user.Friends)
            {
                foreach(FacebookFriend reqFriend in i_Friends)
                {
                    if(curUser.Id == reqFriend.ID)
                    {
                        foreach(Post post in curUser.Posts)
                        {
                            if(post.Description != null || post.Message != null)
                            {
                                posts.Add(post.Id, new FacebookPost(post, reqFriend));
                            }
                        }
                    }
                }
            }

            return posts.Values;
        }

        /// <summary>
        /// LikeAndComment function x2
        /// </summary>
        /// <param name="i_TaggedPosts"></param>
        /// <param name="i_Msg"></param>
        public void LikeAndComment(ObjectCollection i_TaggedPosts, string i_Msg)
        {
            foreach (FacebookPost post in i_TaggedPosts)
            {
                post.OriginalPost.Like();
                if (i_Msg != null)
                {
                    post.OriginalPost.Comment(i_Msg);
                }
            }
        }

        public void LikeAndComment(CheckedItemCollection i_TaggedPosts, string i_Msg)
        {
            foreach (FacebookPost post in i_TaggedPosts)
            {
                post.OriginalPost.Like();
                if (i_Msg != null)
                {
                    post.OriginalPost.Comment(i_Msg);
                }
            }
        }
    }
}
