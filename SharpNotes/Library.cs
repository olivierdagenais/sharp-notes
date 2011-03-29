using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace SharpNotes
{
    public class Library
    {
        #region Fields

        private string libraryFile;
        private Regex validator = new Regex("[.](s3m|it|xm|mod|mp3)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public List<Tune> Tunes = new List<Tune>();

        #endregion

        #region Persistence

        public static Library Load(string path)
        {
            Library result;

            if (!File.Exists(path)) result = new Library();
            else
            {
                var s = new XmlSerializer(typeof(Library));
                using (var file = File.OpenRead(path))
                    result = (Library)s.Deserialize(file);
            }

            result.libraryFile = path;
            return result;
        }

        public void Save()
        {
            var s = new XmlSerializer(typeof(Library));
            using (var file = File.Create(libraryFile))
                s.Serialize(file, this);
        }

        #endregion

        #region Import

        private void Import(FileInfo file)
        {
            var m = validator.Match(file.Name);
            if (m.Success)
            {
                var tune = new Tune(file.FullName);
                if (Tunes.Contains(tune))
                {
                    var match = Tunes.First(t => t.Equals(tune));
                    match.Merge(tune);
                }
                else
                {
                    Tunes.Add(tune);
                }
            }
        }

        private void Import(DirectoryInfo dir)
        {
            var q = new Queue<DirectoryInfo>(new[]{dir});
            while (q.Count > 0)
            {
                var d = q.Dequeue();
                foreach (var file in d.GetFiles())
                    Import(file);

                foreach (var sub in d.GetDirectories())
                    q.Enqueue(sub);
            }
        }

        public void Import(params string[] files)
        {
            foreach (var file in files)
                if (Directory.Exists(file))
                    Import(new DirectoryInfo(file));
                else if (File.Exists(file))
                    Import(new FileInfo(file));
        }

        #endregion

        public IEnumerable<Tune> Filter(string filter)
        {
            return Tunes.Where( t => t.Matches(filter) );
        }
    }
}
