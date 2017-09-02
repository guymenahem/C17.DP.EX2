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
using FacebookWrapper;

namespace OurLibrary
{
    public sealed class FacebookUser
    {
        // Facebook user
        private static FacebookUser s_Instance = null;
        private static object m_Lock = new object();
        private FacebookWrapper.ObjectModel.User m_user;
        private string m_Token;
        private List<FacebookFriend> m_Friends;

        private FacebookUser(string i_Token)
        {
            LoginResult result;
            if (i_Token==null)
            {
                // Repilicated code for check
                /// (desig patter's "Design Patterns Course App 2.4" app)
                    result = FacebookService.Login(
                    "898130767007817",
                    "public_profile",
                    "user_education_history",
                    "user_birthday",
                    "user_actions.video",
                    "user_actions.news",
                    "user_actions.music",
                    "user_actions.fitness",
                    "user_actions.books",
                    "user_about_me",
                    "user_friends",
                    "publish_actions",
                    "user_events",
                    "user_games_activity",
                    "user_hometown",
                    "user_likes",
                    "user_location",
                    "user_managed_groups",
                    "user_photos",
                    "user_posts",
                    "user_relationships",
                    "user_relationship_details",
                    "user_religion_politics",
                    "user_tagged_places",
                    "user_videos",
                    "user_website",
                    "user_work_history",
                    "read_custom_friendlists",
                    "read_page_mailboxes",
                    "manage_pages",
                    "publish_pages",
                    "publish_actions",
                    "rsvp_event");
            }
            else
            {
                result = FacebookService.Connect(i_Token);
            }

            if (result.LoggedInUser != null)
            {
                m_user = result.LoggedInUser;
                m_Token = result.AccessToken;
                m_Friends = new List<FacebookFriend>();
                foreach (User friend in m_user.Friends)
                {
                    m_Friends.Add(new FacebookFriend(friend));
                }
            }
            else
            {
                throw new TaskCanceledException("Could not Connect to facebook for some reason. Please try agin...");
            }

        }

        public string Token
        {
            get { return m_Token; }
            private set { m_Token = value; }
        }

        public static FacebookUser Instance(string i_Token = null)
        {
            if(s_Instance==null)
            {
                lock(m_Lock)
                {
                    if(s_Instance == null)
                    {
                        s_Instance = new FacebookUser(i_Token);
                    }
                }
            }

            return s_Instance;
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

        public ICollection<FacebookPostAdapter> GetTaggedPosts()
        {
            ICollection<FacebookPostAdapter> rslt = new List<FacebookPostAdapter>();

            foreach (User friend in m_user.Friends)
            {
                foreach (Post post in friend.Posts)
                {
                    foreach (User tagged in post.TaggedUsers)
                    {
                        if (tagged.Id == this.m_user.Id)
                        {
                            rslt.Add(new FacebookPostAdapter(post, FindFriend(friend.Id)));
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

        public ICollection<FacebookPostAdapter> GetFriendsPosts(ICollection<FacebookFriend> i_Friends)
        {
            Dictionary<string, FacebookPostAdapter> posts = new Dictionary<string, FacebookPostAdapter>();

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
                                posts.Add(post.Id, new FacebookPostAdapter(post, reqFriend));
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
            foreach (FacebookPostAdapter post in i_TaggedPosts)
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
            foreach (FacebookPostAdapter post in i_TaggedPosts)
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
