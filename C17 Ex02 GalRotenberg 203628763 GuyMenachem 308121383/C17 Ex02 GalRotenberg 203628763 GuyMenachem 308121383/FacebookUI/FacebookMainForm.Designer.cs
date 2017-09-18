using FacebookLogicUnit;

namespace C17_Ex01_Gal_203628763_Guy_308121383
{
    public partial class FacebookMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // TODO: Finding a propper place for the User(LogicUnit)
        private FacebookManager m_AppManager;
        private AppSettings m_AppSettings;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label descriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookMainForm));
            System.Windows.Forms.Label nameLabel;
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.TodoTab = new System.Windows.Forms.TabPage();
            this.comboBoxPosts = new System.Windows.Forms.ComboBox();
            this.labelTODO = new System.Windows.Forms.Label();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.ActionButton = new System.Windows.Forms.Button();
            this.ClearTextButton = new System.Windows.Forms.Button();
            this.PostCommentButton = new System.Windows.Forms.Button();
            this.TabControlTODO = new System.Windows.Forms.TabControl();
            this.EventsTab = new System.Windows.Forms.TabPage();
            this.checkedListBoxEvents = new System.Windows.Forms.CheckedListBox();
            this.PostsTab = new System.Windows.Forms.TabPage();
            this.checkedListBoxPosts = new System.Windows.Forms.CheckedListBox();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.pictureBoxEvents = new System.Windows.Forms.PictureBox();
            this.FavoritesTab = new System.Windows.Forms.TabPage();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.iFacebookPostAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.buttonLoadPosts = new System.Windows.Forms.Button();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.checkedListBoxFriends = new System.Windows.Forms.CheckedListBox();
            this.FacebookTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewPrevPosts = new System.Windows.Forms.ListView();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            this.buttonPrevPhoto = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBoxUserPictures = new System.Windows.Forms.PictureBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.buttonSubmitPost = new System.Windows.Forms.Button();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.pictureBoxCoverPhoto = new System.Windows.Forms.PictureBox();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.buttonLogOff = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            this.TodoTab.SuspendLayout();
            this.TabControlTODO.SuspendLayout();
            this.EventsTab.SuspendLayout();
            this.PostsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).BeginInit();
            this.FavoritesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iFacebookPostAdapterBindingSource)).BeginInit();
            this.FacebookTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(descriptionLabel, "descriptionLabel");
            descriptionLabel.Name = "descriptionLabel";
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.Name = "nameLabel";
            // 
            // buttonLogIn
            // 
            resources.ApplyResources(this.buttonLogIn, "buttonLogIn");
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // TodoTab
            // 
            resources.ApplyResources(this.TodoTab, "TodoTab");
            this.TodoTab.Controls.Add(this.comboBoxPosts);
            this.TodoTab.Controls.Add(this.labelTODO);
            this.TodoTab.Controls.Add(this.comboBoxEvents);
            this.TodoTab.Controls.Add(this.ActionButton);
            this.TodoTab.Controls.Add(this.ClearTextButton);
            this.TodoTab.Controls.Add(this.PostCommentButton);
            this.TodoTab.Controls.Add(this.TabControlTODO);
            this.TodoTab.Controls.Add(this.CommentTextBox);
            this.TodoTab.Controls.Add(this.pictureBoxEvents);
            this.TodoTab.Name = "TodoTab";
            this.TodoTab.UseVisualStyleBackColor = true;
            // 
            // comboBoxPosts
            // 
            this.comboBoxPosts.FormattingEnabled = true;
            this.comboBoxPosts.Items.AddRange(new object[] {
            resources.GetString("comboBoxPosts.Items"),
            resources.GetString("comboBoxPosts.Items1"),
            resources.GetString("comboBoxPosts.Items2"),
            resources.GetString("comboBoxPosts.Items3")});
            resources.ApplyResources(this.comboBoxPosts, "comboBoxPosts");
            this.comboBoxPosts.Name = "comboBoxPosts";
            // 
            // labelTODO
            // 
            resources.ApplyResources(this.labelTODO, "labelTODO");
            this.labelTODO.Name = "labelTODO";
            // 
            // comboBoxEvents
            // 
            this.comboBoxEvents.FormattingEnabled = true;
            this.comboBoxEvents.Items.AddRange(new object[] {
            resources.GetString("comboBoxEvents.Items"),
            resources.GetString("comboBoxEvents.Items1"),
            resources.GetString("comboBoxEvents.Items2")});
            resources.ApplyResources(this.comboBoxEvents, "comboBoxEvents");
            this.comboBoxEvents.Name = "comboBoxEvents";
            // 
            // ActionButton
            // 
            resources.ApplyResources(this.ActionButton, "ActionButton");
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.UseVisualStyleBackColor = true;
            this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // ClearTextButton
            // 
            resources.ApplyResources(this.ClearTextButton, "ClearTextButton");
            this.ClearTextButton.Name = "ClearTextButton";
            this.ClearTextButton.UseVisualStyleBackColor = true;
            // 
            // PostCommentButton
            // 
            resources.ApplyResources(this.PostCommentButton, "PostCommentButton");
            this.PostCommentButton.Name = "PostCommentButton";
            this.PostCommentButton.UseVisualStyleBackColor = true;
            // 
            // TabControlTODO
            // 
            this.TabControlTODO.Controls.Add(this.EventsTab);
            this.TabControlTODO.Controls.Add(this.PostsTab);
            resources.ApplyResources(this.TabControlTODO, "TabControlTODO");
            this.TabControlTODO.Name = "TabControlTODO";
            this.TabControlTODO.SelectedIndex = 0;
            this.TabControlTODO.SelectedIndexChanged += new System.EventHandler(this.TabControlTODO_SelectedIndexChanged);
            // 
            // EventsTab
            // 
            this.EventsTab.Controls.Add(this.checkedListBoxEvents);
            resources.ApplyResources(this.EventsTab, "EventsTab");
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxEvents
            // 
            this.checkedListBoxEvents.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxEvents, "checkedListBoxEvents");
            this.checkedListBoxEvents.Name = "checkedListBoxEvents";
            this.checkedListBoxEvents.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxEvents_SelectedIndexChanged);
            // 
            // PostsTab
            // 
            this.PostsTab.Controls.Add(this.checkedListBoxPosts);
            resources.ApplyResources(this.PostsTab, "PostsTab");
            this.PostsTab.Name = "PostsTab";
            this.PostsTab.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxPosts
            // 
            this.checkedListBoxPosts.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxPosts, "checkedListBoxPosts");
            this.checkedListBoxPosts.Name = "checkedListBoxPosts";
            // 
            // CommentTextBox
            // 
            resources.ApplyResources(this.CommentTextBox, "CommentTextBox");
            this.CommentTextBox.Name = "CommentTextBox";
            // 
            // pictureBoxEvents
            // 
            resources.ApplyResources(this.pictureBoxEvents, "pictureBoxEvents");
            this.pictureBoxEvents.Name = "pictureBoxEvents";
            this.pictureBoxEvents.TabStop = false;
            // 
            // FavoritesTab
            // 
            resources.ApplyResources(this.FavoritesTab, "FavoritesTab");
            this.FavoritesTab.Controls.Add(descriptionLabel);
            this.FavoritesTab.Controls.Add(this.descriptionTextBox);
            this.FavoritesTab.Controls.Add(nameLabel);
            this.FavoritesTab.Controls.Add(this.nameLabel1);
            this.FavoritesTab.Controls.Add(this.buttonLoadPosts);
            this.FavoritesTab.Controls.Add(this.listBoxPosts);
            this.FavoritesTab.Controls.Add(this.checkedListBoxFriends);
            this.FavoritesTab.Name = "FavoritesTab";
            this.FavoritesTab.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iFacebookPostAdapterBindingSource, "From.Description", true));
            resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            // 
            // iFacebookPostAdapterBindingSource
            // 
            this.iFacebookPostAdapterBindingSource.DataSource = typeof(OurLibrary.IFacebookPostAdapter);
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iFacebookPostAdapterBindingSource, "From.Name", true));
            resources.ApplyResources(this.nameLabel1, "nameLabel1");
            this.nameLabel1.Name = "nameLabel1";
            // 
            // buttonLoadPosts
            // 
            resources.ApplyResources(this.buttonLoadPosts, "buttonLoadPosts");
            this.buttonLoadPosts.Name = "buttonLoadPosts";
            this.buttonLoadPosts.UseVisualStyleBackColor = true;
            this.buttonLoadPosts.Click += new System.EventHandler(this.buttonLoadPosts_Click);
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.DataSource = this.iFacebookPostAdapterBindingSource;
            this.listBoxPosts.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxPosts, "listBoxPosts");
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxPosts_SelectedIndexChanged);
            // 
            // checkedListBoxFriends
            // 
            this.checkedListBoxFriends.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxFriends, "checkedListBoxFriends");
            this.checkedListBoxFriends.Name = "checkedListBoxFriends";
            // 
            // FacebookTab
            // 
            resources.ApplyResources(this.FacebookTab, "FacebookTab");
            this.FacebookTab.Controls.Add(this.label1);
            this.FacebookTab.Controls.Add(this.listViewPrevPosts);
            this.FacebookTab.Controls.Add(this.buttonNextPhoto);
            this.FacebookTab.Controls.Add(this.buttonPrevPhoto);
            this.FacebookTab.Controls.Add(this.buttonClear);
            this.FacebookTab.Controls.Add(this.pictureBoxUserPictures);
            this.FacebookTab.Controls.Add(this.listBoxAlbums);
            this.FacebookTab.Controls.Add(this.buttonSubmitPost);
            this.FacebookTab.Controls.Add(this.textBoxPost);
            this.FacebookTab.Name = "FacebookTab";
            this.FacebookTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // listViewPrevPosts
            // 
            resources.ApplyResources(this.listViewPrevPosts, "listViewPrevPosts");
            this.listViewPrevPosts.Name = "listViewPrevPosts";
            this.listViewPrevPosts.UseCompatibleStateImageBehavior = false;
            // 
            // buttonNextPhoto
            // 
            resources.ApplyResources(this.buttonNextPhoto, "buttonNextPhoto");
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            this.buttonNextPhoto.Click += new System.EventHandler(this.buttonNextPhoto_Click);
            // 
            // buttonPrevPhoto
            // 
            resources.ApplyResources(this.buttonPrevPhoto, "buttonPrevPhoto");
            this.buttonPrevPhoto.Name = "buttonPrevPhoto";
            this.buttonPrevPhoto.UseVisualStyleBackColor = true;
            this.buttonPrevPhoto.Click += new System.EventHandler(this.buttonPrevPhoto_Click);
            // 
            // buttonClear
            // 
            resources.ApplyResources(this.buttonClear, "buttonClear");
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // pictureBoxUserPictures
            // 
            resources.ApplyResources(this.pictureBoxUserPictures, "pictureBoxUserPictures");
            this.pictureBoxUserPictures.Name = "pictureBoxUserPictures";
            this.pictureBoxUserPictures.TabStop = false;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxAlbums, "listBoxAlbums");
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // buttonSubmitPost
            // 
            resources.ApplyResources(this.buttonSubmitPost, "buttonSubmitPost");
            this.buttonSubmitPost.Name = "buttonSubmitPost";
            this.buttonSubmitPost.UseVisualStyleBackColor = true;
            this.buttonSubmitPost.Click += new System.EventHandler(this.buttonSubmitPost_Click);
            // 
            // textBoxPost
            // 
            resources.ApplyResources(this.textBoxPost, "textBoxPost");
            this.textBoxPost.Name = "textBoxPost";
            // 
            // pictureBoxProfile
            // 
            resources.ApplyResources(this.pictureBoxProfile, "pictureBoxProfile");
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.TabStop = false;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.FacebookTab);
            this.TabControl.Controls.Add(this.FavoritesTab);
            this.TabControl.Controls.Add(this.TodoTab);
            resources.ApplyResources(this.TabControl, "TabControl");
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            // 
            // pictureBoxCoverPhoto
            // 
            resources.ApplyResources(this.pictureBoxCoverPhoto, "pictureBoxCoverPhoto");
            this.pictureBoxCoverPhoto.Name = "pictureBoxCoverPhoto";
            this.pictureBoxCoverPhoto.TabStop = false;
            // 
            // checkBoxRememberMe
            // 
            resources.ApplyResources(this.checkBoxRememberMe, "checkBoxRememberMe");
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // buttonLogOff
            // 
            resources.ApplyResources(this.buttonLogOff, "buttonLogOff");
            this.buttonLogOff.Name = "buttonLogOff";
            this.buttonLogOff.UseVisualStyleBackColor = true;
            this.buttonLogOff.Click += new System.EventHandler(this.buttonLogOff_Click);
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // FacebookMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonLogOff);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.pictureBoxCoverPhoto);
            this.Name = "FacebookMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FacebookMainForm_FormClosing);
            this.TodoTab.ResumeLayout(false);
            this.TodoTab.PerformLayout();
            this.TabControlTODO.ResumeLayout(false);
            this.EventsTab.ResumeLayout(false);
            this.PostsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvents)).EndInit();
            this.FavoritesTab.ResumeLayout(false);
            this.FavoritesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iFacebookPostAdapterBindingSource)).EndInit();
            this.FacebookTab.ResumeLayout(false);
            this.FacebookTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserPictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.TabPage TodoTab;
        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.Button ClearTextButton;
        private System.Windows.Forms.Button PostCommentButton;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.TabControl TabControlTODO;
        private System.Windows.Forms.TabPage EventsTab;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvents;
        private System.Windows.Forms.TabPage PostsTab;
        private System.Windows.Forms.CheckedListBox checkedListBoxPosts;
        private System.Windows.Forms.TabPage FavoritesTab;
        private System.Windows.Forms.TabPage FacebookTab;
        private System.Windows.Forms.Button buttonSubmitPost;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.PictureBox pictureBoxUserPictures;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.PictureBox pictureBoxCoverPhoto;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.Button buttonNextPhoto;
        private System.Windows.Forms.Button buttonPrevPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewPrevPosts;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.Label labelTODO;
        private System.Windows.Forms.PictureBox pictureBoxEvents;
        private System.Windows.Forms.ComboBox comboBoxPosts;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.CheckedListBox checkedListBoxFriends;
        private System.Windows.Forms.Button buttonLoadPosts;
        private System.Windows.Forms.Button buttonLogOff;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.BindingSource iFacebookPostAdapterBindingSource;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label nameLabel1;
    }
}