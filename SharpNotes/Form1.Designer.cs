namespace SharpNotes
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.libraryList = new System.Windows.Forms.ListView();
            this.artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filter = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playlist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // libraryList
            // 
            this.libraryList.AllowDrop = true;
            this.libraryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.artist,
            this.album,
            this.song});
            this.libraryList.FullRowSelect = true;
            this.libraryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.libraryList.HideSelection = false;
            this.libraryList.Location = new System.Drawing.Point(6, 47);
            this.libraryList.Name = "libraryList";
            this.libraryList.Size = new System.Drawing.Size(402, 490);
            this.libraryList.TabIndex = 5;
            this.libraryList.UseCompatibleStateImageBehavior = false;
            this.libraryList.View = System.Windows.Forms.View.Details;
            this.libraryList.ItemActivate += new System.EventHandler(this.library_ItemActivate);
            this.libraryList.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_DragDrop);
            this.libraryList.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_DragEnter);
            this.libraryList.Resize += new System.EventHandler(this.list_Resize);
            // 
            // artist
            // 
            this.artist.Text = "Artist";
            // 
            // album
            // 
            this.album.Text = "Album";
            // 
            // song
            // 
            this.song.Text = "Song";
            // 
            // filter
            // 
            this.filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filter.Location = new System.Drawing.Point(41, 19);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(367, 20);
            this.filter.TabIndex = 6;
            this.filter.TextChanged += new System.EventHandler(this.filter_TextChanged);
            this.filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filter_KeyPress);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(6, 23);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(29, 13);
            this.filterLabel.TabIndex = 7;
            this.filterLabel.Text = "&Filter";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(3, 3);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(60, 13);
            this.time.TabIndex = 8;
            this.time.Text = "1:23 / 4:56";
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.time);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(822, 543);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.playlist);
            this.groupBox2.Location = new System.Drawing.Point(3, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 524);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Play List";
            // 
            // playlist
            // 
            this.playlist.AllowDrop = true;
            this.playlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.playlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlist.FullRowSelect = true;
            this.playlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playlist.HideSelection = false;
            this.playlist.Location = new System.Drawing.Point(3, 16);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(392, 505);
            this.playlist.TabIndex = 5;
            this.playlist.UseCompatibleStateImageBehavior = false;
            this.playlist.View = System.Windows.Forms.View.Details;
            this.playlist.ItemActivate += new System.EventHandler(this.playlist_ItemActivate);
            this.playlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_DragDrop);
            this.playlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_DragEnter);
            this.playlist.Resize += new System.EventHandler(this.list_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Artist";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Album";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Song";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.libraryList);
            this.groupBox1.Controls.Add(this.filter);
            this.groupBox1.Controls.Add(this.filterLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Library";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 567);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sharp Notes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView libraryList;
        private System.Windows.Forms.ColumnHeader artist;
        private System.Windows.Forms.ColumnHeader album;
        private System.Windows.Forms.ColumnHeader song;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView playlist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

