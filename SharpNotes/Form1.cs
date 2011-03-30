using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SharpNotes
{
    public partial class Form1 : Form
    {
        #region Fields

        Player player;
        System.Timers.Timer timer;
        Library library;
        const string libraryFile = "SharpNotes.xml";
        IEnumerable<Tune> visible;
        List<Tune> playQueue = new List<Tune>();
        Tune playing;

        #endregion

        #region Construction

        public Form1()
        {
            InitializeComponent();
            player = new Player( PlayNext );
            library = Library.Load(libraryFile);
            UpdateList();

            new InterceptKeys(HandleGlobalKey);
            RefreshStatus();

            timer = new System.Timers.Timer(1000) { AutoReset = true };
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer.Stop();
            library.Save();
            player.Shutdown();
            base.OnFormClosing(e);
        }
        
        #endregion

        #region Status

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshStatus();
        }

        void RefreshStatus()
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new MethodInvoker(RefreshStatus));
                }
                catch (ObjectDisposedException) { }
            }
            else
            {
                var sb = new StringBuilder();
                if (!player.IsPlaying) sb.Append("(");
                sb.AppendFormat("{0:mm\\:ss}", player.Position);
                if (!player.IsPlaying) sb.Append(")");
                time.Text = sb.ToString();
            }
        }

        #endregion

        #region Drag and drop

        private void list_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void list_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData("FileNameW");
            library.Import(files);
            UpdateList();
            library.Save();
        }

        #endregion

        #region Playing and pausing

        void Play()
        {
            var index = 0;

            var selectedIndexes = playlist.SelectedIndices;
            if (selectedIndexes.Count > 0)
                index = selectedIndexes[0];

            Play(index);
        }

        void Play(int index)
        {
            index %= playQueue.Count();
            Tune tune = playQueue[index];

            if (tune != null && tune != playing)
            {
                player.Load(tune.Path);
                tune.Duration = player.Duration;
                playing = tune;
            }

            playlist.SelectedIndices.Clear();
            playlist.SelectedIndices.Add(index);

            player.PlayOrPause();
            RefreshStatus();
        }

        void PlayNext()
        {
            var current = playQueue.IndexOf(playing);
            if (current < 0) current = 0;
            Play(current + 1);
        }

        private void time_Click(object sender, EventArgs e)
        {
            Play();
        }

        void AddSelectionToPlaylist()
        {
            var l = visible.ToList();
            for(var i=0; i<libraryList.SelectedIndices.Count; i++)
            {
                var index = libraryList.SelectedIndices[i];
                var tune = visible.ElementAt(index);
                if (!playQueue.Contains(tune))
                    playQueue.Add(tune);
            }

            UpdatePlaylist();
        }

        private void library_ItemActivate(object sender, EventArgs e)
        {
            AddSelectionToPlaylist();
        }

        private void playlist_ItemActivate(object sender, EventArgs e)
        {
            Play();
        }

        void HandleGlobalKey(Keys key)
        {
            if (key == Keys.MediaPlayPause && Control.ModifierKeys == 0)
                Play();

            if (key == Keys.MediaPlayPause && Control.ModifierKeys == Keys.Control)
                Visible ^= true;
        }

        #endregion

        #region Song list

        void UpdateListColumnWidths()
        {
            foreach (var list in new[] { libraryList, playlist })
            {
                for (var i = 0; i < list.Columns.Count; i++)
                {
                    var column = list.Columns[i];
                    column.Width = (int)Math.Floor(1.0 * (list.Width - list.Margin.Horizontal) / list.Columns.Count);
                }
            }
            //for (var i = 0; i < libraryList.Columns.Count; i++)
            //{
            //    var column = libraryList.Columns[i];
            //    column.Width = (int)Math.Floor(1.0 * (libraryList.Width - libraryList.Margin.Horizontal) / libraryList.Columns.Count);
            //}
        }

        private void filter_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        void UpdateList()
        {
            visible = library.Filter(filter.Text);
            libraryList.Items.Clear();
            foreach (var tune in visible)
            {
                var columns = new[] { tune.Artist, tune.Album, tune.Name };
                var item = new ListViewItem(columns);
                libraryList.Items.Add(item);
            }

            UpdateListColumnWidths();
        }

        void UpdatePlaylist()
        {
            playlist.Items.Clear();
            foreach (var tune in playQueue)
            {
                var columns = new[] { tune.Artist, tune.Album, tune.Name };
                var item = new ListViewItem(columns);
                playlist.Items.Add(item);
            }

            UpdateListColumnWidths();
        }

        private void filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                Play();
            }
            else if (e.KeyChar == 27)
            {
                e.Handled = true;
                filter.Text = string.Empty;
            }
        }

        private void list_Resize(object sender, EventArgs e)
        {
            UpdateListColumnWidths();
        }

        #endregion

    }
}
