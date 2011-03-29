using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SharpNotes
{
    public class Tune: IEquatable<Tune>
    {
        #region Properties

        public string Path { get; set; }

        public string Artist { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        #endregion

        #region Construction

        private Tune() {}

        public Tune(string path)
        {
            Path = path;
            LoadMetadata();
        }

        #endregion

        #region Filtering

        static bool Matches(string value, string filter)
        {
            if (value == null && filter == null) return true;
            if (value == null || filter == null) return false;

            var lcValue = value.ToLowerInvariant();
            var lcFilter = filter.ToLowerInvariant();

            var result = lcValue.Contains(lcFilter);
            return result;
        }

        public bool Matches(string filter)
        {
            var parts = filter.Split(' ');
            foreach (var part in parts)
                if (
                    !(
                        Matches(Artist, part)
                        || Matches(Album, part)
                        || Matches(Name, part)
                    )
                )
                    return false;

            return true;
        }

        #endregion

        #region Metadata

        string Decode8859(byte[] array, int offset, int length)
        {
            // ID3v2.2 tags are encoded in ISO-8859-1: http://en.wikipedia.org/wiki/ID3
            // ISO-8859-1: http://en.wikipedia.org/wiki/ISO-8859-1#ISO-8859-1
            // ISO-8859-1 is known as code page 28591: http://msdn.microsoft.com/en-us/library/system.text.encoding.aspx

            var codepage = 28591;
            var decoder = Encoding.GetEncoding(codepage);
            var result = decoder.GetString(array, offset, length).Trim().Replace("\0", "");
            return result;
        }

        void LoadMetadata()
        {
            var lastDot = Path.LastIndexOf('.');
            var extension = Path.Substring(1 + lastDot).ToLowerInvariant();
            switch (extension)
            {
                case "it":
                    using (var s = File.OpenRead(Path))
                    {
                        var h = new byte[30];
                        s.Read(h, 0, h.Length);
                        Debug.Assert(h[0] == 'I' && h[1] == 'M' && h[2] == 'P' && h[3] == 'M');
                        Name = Decode8859(h, 4, 26);
                    }
                    break;

                case "s3m":
                    using (var s = File.OpenRead(Path))
                    {
                        var h = new byte[28];
                        s.Read(h, 0, 28);
                        Name = Decode8859(h, 0, 28);
                    }
                    break;

                case "mod":
                    using (var s = File.OpenRead(Path))
                    {
                        var h = new byte[20];
                        s.Read(h, 0, 20);
                        Name = Decode8859(h, 0, 20);
                    }
                    break;

                case "xm":
                    using (var s = File.OpenRead(Path))
                    {
                        var h = new byte[20];
                        s.Read(h, 0, 17);
                        s.Read(h, 0, 20);
                        Name = Decode8859(h, 0, 20);
                    }
                    break;

                case "mp3":
                    using (var s = File.OpenRead(Path))
                    {
                        var h = new byte[256];
                        s.Read(h, 0, 256);
                        if (h[0] == 'I' && h[1] == 'D' && h[2] == '3' && h[3] == 2)
                        {
                            for (var i = 0; i < h.Length - 7; i++)
                            {
                                Album = Album ?? TryParseId3v22("TAL", h, i);
                                Artist = Artist ?? TryParseId3v22("TP1", h, i);
                                Name = Name ?? TryParseId3v22("TT2", h, i);
                            }
                        }

                        // TODO: Support ID3v2.3
                        //
                        // http://www.id3.org/id3v2.3.0
                        //
                        // KKKK SSSS FF
                        // key  size flags
                        //
                        // Keys
                        // ====
                        // TIT2 => Title
                        // TALB => Album
                        // TPE1 => Artist
                    }
                    break;

                default:
                    break;
            }

            if (string.IsNullOrEmpty(Name))
            {
                var file = new FileInfo(Path);
                Name = file.Name;
            }
        }

        private string TryParseId3v22(string headerName, byte[] array, int offset)
        {
            var header = ASCIIEncoding.ASCII.GetBytes(headerName);
            for (int i = 0; i < header.Length; i++)
                if (header[i] != array[offset + i])
                    return null;

            try
            {
                var len = (array[offset + header.Length + 2]) + (array[offset + header.Length + 3] << 8) - 2;
                var result = Decode8859(array, offset + header.Length + 4, len);
                return result;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public bool Equals(Tune other)
        {
            var result = Path.Equals(other.Path);
            return result;
        }

        public void Merge(Tune t)
        {
            if (string.IsNullOrEmpty(Artist))
                Artist = t.Artist;

            if (string.IsNullOrEmpty(Album))
                Album = t.Album;

            if (string.IsNullOrEmpty(Name))
                Name = t.Name;
        }
    }
}
