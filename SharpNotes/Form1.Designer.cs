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
            this.list = new System.Windows.Forms.ListView();
            this.artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filter = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.AllowDrop = true;
            this.list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.artist,
            this.album,
            this.song});
            this.list.FullRowSelect = true;
            this.list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list.HideSelection = false;
            this.list.Location = new System.Drawing.Point(13, 41);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(483, 270);
            this.list.TabIndex = 5;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.ItemActivate += new System.EventHandler(this.list_ItemActivate);
            this.list.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_DragDrop);
            this.list.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_DragEnter);
            this.list.Resize += new System.EventHandler(this.list_Resize);
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
            this.filter.Location = new System.Drawing.Point(241, 12);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(255, 20);
            this.filter.TabIndex = 6;
            this.filter.TextChanged += new System.EventHandler(this.filter_TextChanged);
            this.filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filter_KeyPress);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(206, 19);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(29, 13);
            this.filterLabel.TabIndex = 7;
            this.filterLabel.Text = "&Filter";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(12, 19);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(60, 13);
            this.time.TabIndex = 8;
            this.time.Text = "1:23 / 4:56";
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 323);
            this.Controls.Add(this.time);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sharp Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.ColumnHeader artist;
        private System.Windows.Forms.ColumnHeader album;
        private System.Windows.Forms.ColumnHeader song;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Label time;
    }
}

