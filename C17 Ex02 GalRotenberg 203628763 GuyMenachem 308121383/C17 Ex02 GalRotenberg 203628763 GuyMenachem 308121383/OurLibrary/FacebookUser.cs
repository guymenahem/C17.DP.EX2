using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using static System.Windows.Forms.CheckedListBox;

namespace OurLibrary
{
    public sealed class FacebookUser
    {
        // Facebook user
        private static FacebookUser s_Instance = null;
        private static object m_Lock = new object();
        private FacebookWrapper.ObjectModel.User m_user;
        private string m_Token;
        private List<FacebookFriendAdapter> m_Friends;

        private FacebookUser(string i_Token)
        {
            LoginResult result;
            if (i_Token == null)
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
                m_Friends = new List<FacebookFriendAdapter>();
                foreach (User friend in m_user.Friends)
                {
                    m_Friends.Add(AdaptersFactory.CreateAdapterFromFacebookObj(friend) as FacebookFriendAdapter);
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
            if(s_Instance == null)
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

        public ICollection<FacebookPostAdapter> GetTaggedPosts()
        {
            ICollection<FacebookPostAdapter> rslt = new List<FacebookPostAdapter>();

            foreach (User friend in m_user.Friends)
            {
                foreach (Post post in friend.Posts)
                {
                    if(post.TargetUsers!=null)
                    {
                        foreach (User tagged in post.TargetUsers)
                        {
                            if (tagged.Id == this.m_user.Id)
                            {
                                rslt.Add(AdaptersFactory.CreateAdapterFromFacebookObj(post) as FacebookPostAdapter);
                            }
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

        public ICollection<FacebookEventAdapter> FetchEvents()
        {
            ICollection<FacebookEventAdapter> rslt = new List<FacebookEventAdapter>();

            foreach (Event evnt in m_user.Events)
            {
                rslt.Add(AdaptersFactory.CreateAdapterFromFacebookObj(evnt) as FacebookEventAdapter);
            }

            return rslt;
        }

        private FacebookFriendAdapter FindFriend(string i_ID)
        {
            FacebookFriendAdapter rslt = null;
            foreach (FacebookFriendAdapter friend in m_Friends)
            {
                if (friend.ID == i_ID)
                {
                    rslt = friend;
                    break;
                }
            }

            return rslt;
        }


        public ICollection<FacebookPostAdapter> FetchPosts()
        {
            // Create for output
            ICollection<FacebookPostAdapter> rslt = new List<FacebookPostAdapter>();

            // For each post
            foreach (Post p in m_user.Posts)
            {
                // get string from post
                FacebookPostAdapter curPost = AdaptersFactory.CreateAdapterFromFacebookObj(p) as FacebookPostAdapter;

                if (curPost.Title != string.Empty)
                {
                    rslt.Add(curPost);
                }
            }

            return rslt;
        }

        public ICollection<FacebookFriendAdapter> GetUserFriends()
        {
            return this.m_Friends;
        }

        public ICollection<FacebookPostAdapter> GetFriendsPosts(ICollection<FacebookFriendAdapter> i_Friends)
        {
            List<FacebookPostAdapter> posts = new List<FacebookPostAdapter>();

            foreach(User curUser in this.m_user.Friends)
            {
                foreach(FacebookFriendAdapter reqFriend in i_Friends)
                {
                    if(curUser.Id == reqFriend.ID)
                    {
                        foreach(Post post in curUser.Posts)
                        {
                            if(post.Description != null || post.Message != null)
                            {
                                posts.Add(AdaptersFactory.CreateAdapterFromFacebookObj(post) as FacebookPostAdapter);
                            }
                        }
                    }
                }
            }

            posts.Sort();

            return posts;
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
                post.Like();
                if (i_Msg != null)
                {
                    post.Comment(i_Msg);
                }
            }
        }

        public void LikeAndComment(CheckedItemCollection i_TaggedPosts, string i_Msg)
        {
            foreach (FacebookPostAdapter post in i_TaggedPosts)
            {
                post.Like();
                if (i_Msg != null)
                {
                    post.Comment(i_Msg);
                }
            }
        }
    }
}
