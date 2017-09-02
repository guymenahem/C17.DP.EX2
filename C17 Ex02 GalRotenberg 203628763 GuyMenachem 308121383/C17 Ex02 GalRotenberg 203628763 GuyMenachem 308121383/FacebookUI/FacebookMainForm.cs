using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookLogicUnit;
using OurLibrary;
using FacebookWrapper;
using System.Threading;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    public partial class FacebookMainForm : Form
    {
        public FacebookMainForm()
        {
            InitializeComponent();

            m_AppManager = new FacebookManager();
            m_AppSettings = new AppSettings();
            
            // Adding Appsetting applications:
            m_AppSettings.LoadSettingsFromFile();
            if (m_AppSettings.RememberUser)
            {
                /// creating first apperance to FacebookUser.
                m_AppManager.Connect(m_AppSettings.UserAccessToken);
                //m_AppManager.Connect(m_AppSettings.UserAccessToken);
                this.LoginProccess();
                this.Size = m_AppSettings.WindowSize;
                this.Location = m_AppSettings.WindowsStart;
                this.checkBoxRememberMe.Checked = true;
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            this.LoginProccess();
        }

        private void LoginProccess()
        {
            /// <summary>
            /// initiate login process:
            /// 1. initializing photos of user.
            /// 2. initializing data to the form using multi-threading for UI
            /// </summary>
            /// 

            this.InitializeComponentsForLogIN();

            // set list view
            this.listViewPrevPosts.Columns.Add(string.Empty, string.Empty, this.listViewPrevPosts.Width - 20);

            // Get Posts
            this.addStringsToListView(this.listViewPrevPosts, m_AppManager.FetchPosts());
            

            // Get Albums
            new Thread(GetAlbums).Start();


            // Add events
            new Thread(GetEvents).Start();


            // Add tagged posts
            new Thread(GetTaggedPosts).Start();
            
            
            // Load all favorits page
            new Thread(this.loadFavoritsPage).Start();
        }

        private void InitializeComponentsForLogIN()
        {
            this.buttonLogIn.Hide();
            this.pictureBoxCoverPhoto.SendToBack();
            this.pictureBoxCoverPhoto.LoadAsync(m_AppManager.CoverPhoto);
            this.pictureBoxProfile.LoadAsync(m_AppManager.ProfilePhoto);
            this.pictureBoxProfile.Show();
            this.listViewPrevPosts.View = View.Details;
            this.TabControl.Enabled = true;

            ColorChangeLabel cl = new ColorChangeLabel();
            cl.Top = 92;
            cl.Left = 26;
            cl.Text = m_AppManager.UserName;
            cl.Font = new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold);
            cl.AutoSize = true;
            cl.AdjustColors(this.pictureBoxCoverPhoto);

            this.Controls.Add(cl);
            cl.BringToFront();
            
        }

        /// <summary>
        /// Add string to list view view
        /// </summary>
        /// <param name="i_ListView">The list view to add</param>
        /// <param name="i_Strings">String that shloud be added</param>
        private void addStringsToListView(ListView i_ListView, ICollection<string> i_Strings)
        {
            foreach (string str in i_Strings)
            {
                i_ListView.Items.Add(str);
            }
        }

        /// <summary>
        /// Add string to top of list view
        /// </summary>
        /// <param name="i_ListView">Lits view</param>
        /// <param name="i_string">string to add</param>
        private void addStringToTopOfList(ListView i_ListView, string i_string)
        {
            ListViewItem newPost = new ListViewItem();
            newPost.Text = this.textBoxPost.Text;

            i_ListView.Items.Insert(0, newPost);
        }

        private void GetAlbums()
        {
            foreach (FacebookAlbum album in m_AppManager.FetchAlbums())
            {
                this.listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
            }
            this.buttonNextPhoto.Invoke(new Action(() => buttonNextPhoto.Enabled = true));
            this.buttonPrevPhoto.Invoke(new Action(() => buttonPrevPhoto.Enabled = true));
        }

        private void GetEvents()
        {
            foreach (FacebookEvent fbE in m_AppManager.FetchEvents())
            {
                this.checkedListBoxEvents.Invoke(new Action(() => checkedListBoxEvents.Items.Add(fbE)));
            }
        }

        private void GetTaggedPosts()
        {
            foreach (FacebookPostAdapter fbP in m_AppManager.FetchTaggedPosts())
            {
                this.checkedListBoxPosts.Invoke(new Action(() => checkedListBoxPosts.Items.Add(fbP)));
            }
        }

        /// <summary>
        /// Click on post button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmitPost_Click(object sender, EventArgs e)
        {
            // try post
            if (m_AppManager.PostMessage(this.textBoxPost.Text))
            {
                this.addStringToTopOfList(this.listViewPrevPosts, this.textBoxPost.Text);
                this.textBoxPost.Clear();
            }
            else
            {
                MessageBox.Show("Empty posts are not allowed.");
            }
        }

        /// <summary>
        /// Clear the post button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPost.Clear();
        }

        /// <summary>
        /// On change of album selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            FacebookAlbum album = this.listBoxAlbums.Items[this.listBoxAlbums.SelectedIndex] as FacebookAlbum;
            this.pictureBoxUserPictures.LoadAsync(album.CurPhoto.GetPicture());
        }

        /// <summary>
        /// Change to previous photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrevPhoto_Click(object sender, EventArgs e)
        {
            if(this.listBoxAlbums.SelectedIndex>-1)
            {
                FacebookAlbum album = this.listBoxAlbums.Items[this.listBoxAlbums.SelectedIndex] as FacebookAlbum;
                this.pictureBoxUserPictures.LoadAsync(album.PrevPhoto.GetPicture());
            }
        }

        /// <summary>
        /// Change to next photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextPhoto_Click(object sender, EventArgs e)
        {
            if (this.listBoxAlbums.SelectedIndex > -1)
            {
                FacebookAlbum album = this.listBoxAlbums.Items[this.listBoxAlbums.SelectedIndex] as FacebookAlbum;
                this.pictureBoxUserPictures.LoadAsync(album.NextPhoto.GetPicture());
            } 
        }

        /// <summary>
        /// Change tab selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlTODO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlTODO.TabPages[TabControlTODO.SelectedIndex].Name == "EventsTab")
            {
                CommentTextBox.Hide();
                CommentTextBox.SendToBack();
                pictureBoxEvents.BringToFront();
                pictureBoxEvents.Show();
                labelTODO.Text = "Choose Option For Selected Events";

                comboBoxPosts.SendToBack();
                comboBoxEvents.BringToFront();
                comboBoxEvents.Show();
            }
            else
            {
                pictureBoxEvents.Hide();
                CommentTextBox.BringToFront();
                pictureBoxEvents.SendToBack();
                CommentTextBox.Show();
                labelTODO.Text = "Choose Option To Comment";

                comboBoxEvents.SendToBack();
                comboBoxPosts.BringToFront();
                comboBoxPosts.Show();
            }
        }

        /// <summary>
        /// Change events statues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            FacebookEvent evnt;
            if(this.checkedListBoxEvents.SelectedIndex < 0)
            {
                this.checkedListBoxEvents.SelectedIndex = 0;
            }

            evnt = checkedListBoxEvents.Items[checkedListBoxEvents.SelectedIndex] as FacebookEvent;
            pictureBoxEvents.ImageLocation = evnt.Image.GetPicture();
        }

        /// <summary>
        /// General action button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (TabControlTODO.TabPages[TabControlTODO.SelectedIndex].Name == "EventsTab")
            {
                if (checkedListBoxEvents.Items.Count != 0)
                {
                    List<FacebookEvent> lst = new List<FacebookEvent>();
                    foreach (FacebookEvent _event in this.checkedListBoxEvents.CheckedItems)
                    {
                        lst.Add(_event);
                    }

                    if (lst.Count != 0)
                    {
                        if(this.comboBoxEvents.SelectedIndex>-1)
                        {
                            if (this.comboBoxEvents.Items[this.comboBoxEvents.SelectedIndex].ToString() == "Attending")
                            {
                                this.m_AppManager.AttendTo(lst, "Attending");
                            }
                            else if (this.comboBoxEvents.Items[this.comboBoxEvents.SelectedIndex].ToString() == "Maybe")
                            {
                                this.m_AppManager.AttendTo(lst, "Maybe");
                            }
                            else
                            {
                                this.m_AppManager.AttendTo(lst, "Not Attending");
                            }

                            foreach (FacebookEvent _event in lst)
                            {
                                this.checkedListBoxEvents.Items.Remove(_event);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No option has been chosen");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("No Events has been chosen");
                    }
                }
                else
                {
                    MessageBox.Show("There are no avialble items");
                }
            }

            // Post
            else
            {
                if (checkedListBoxPosts.Items.Count != 0)
                {
                    if(comboBoxPosts.SelectedIndex>-1)
                    {
                        List<FacebookFriend> TaggedReplies = new List<FacebookFriend>();
                        if (comboBoxPosts.Items[comboBoxPosts.SelectedIndex].ToString() == "Like To All")
                        {
                            m_AppManager.LikeAndComment(checkedListBoxPosts.Items, null);
                        }
                        else if (comboBoxPosts.Items[comboBoxPosts.SelectedIndex].ToString() == "Like + Comment To All")
                        {
                            if (CommentTextBox.Text == string.Empty)
                            {
                                MessageBox.Show("Empty messages are not allowed.");
                            }
                            else
                            {
                                this.m_AppManager.LikeAndComment(checkedListBoxPosts.Items, CommentTextBox.Text);
                            }
                        }
                        else
                        {
                            if (this.checkedListBoxPosts.CheckedItems.Count != 0)
                            {
                                if (this.comboBoxPosts.Items[comboBoxPosts.SelectedIndex].ToString() == "Like To Selected")
                                {
                                    this.m_AppManager.LikeAndComment(this.checkedListBoxPosts.CheckedItems, null);
                                }
                                else
                                {
                                    // Check if message is empty
                                    if (this.CommentTextBox.Text == string.Empty)
                                    {
                                        MessageBox.Show("Empty messages are not allowed");
                                    }
                                    else
                                    {
                                        this.m_AppManager.LikeAndComment(this.checkedListBoxPosts.CheckedItems, this.CommentTextBox.Text);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No Posts selected");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No option has been chosen");
                    }
                }
                else
                {
                    MessageBox.Show("There are no avialble items");
                }
            }
        }

        /// <summary>
        /// Load the favorites page
        /// </summary>
        private void loadFavoritsPage()
        {
            // Load all the friends
            foreach(FacebookFriend friend in this.m_AppManager.FetchFriends())
            {
                this.checkedListBoxFriends.Invoke(new Action(() =>this.checkedListBoxFriends.Items.Add(friend)));
            }
        }

        /// <summary>
        /// Load posts from faivourites friends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadPosts_Click(object sender, EventArgs e)
        {
            List<FacebookFriend> friends = new List<FacebookFriend>();
            List<FacebookPostAdapter> posts = new List<FacebookPostAdapter>();

            foreach (FacebookFriend fr in this.checkedListBoxFriends.CheckedItems)
            {
                friends.Add(fr);
            }

            foreach(FacebookPostAdapter post in this.m_AppManager.GetPostsFromFriends(friends))
            {
                //this.listBoxPosts.Items.Add(post);
                posts.Add(post);
            }

            facebookPostBindingSource.DataSource = posts;
            this.listBoxPosts.DisplayMember = "Description";
        }


        /// <summary>
        /// Of form closine of main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FacebookMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_AppSettings.RememberUser = checkBoxRememberMe.Checked;
            this.m_AppSettings.WindowSize = this.Size;
            this.m_AppSettings.WindowsStart = this.Location;

            m_AppSettings.SaveSettingsToFile();
        }

        private void buttonLogOff_Click(object sender, EventArgs e)
        {
            this.buttonLogIn.Show();
            this.pictureBoxCoverPhoto.Image = null;
            this.pictureBoxProfile.Image = null;
            this.pictureBoxProfile.Hide();
            this.TabControl.Enabled = false;
            this.pictureBoxUserPictures.Image = null;

            this.listViewPrevPosts.Clear();
            this.listBoxAlbums.Items.Clear();
            this.checkedListBoxEvents.Items.Clear();
            this.checkedListBoxPosts.Items.Clear();
            this.checkedListBoxFriends.Items.Clear();
        }
    }
}
