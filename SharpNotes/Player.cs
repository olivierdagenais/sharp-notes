using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMOD;

namespace SharpNotes
{
    class Player
    {
        private FMOD.System system = null;
        private Sound sound = null;
        private Channel channel = null;
        private Action songEndAction;

        public Player(Action songEnd)
        {
            songEndAction = songEnd;
            uint version = 0;
            ERRCHECK( FMOD.Factory.System_Create(ref system) );
            ERRCHECK( system.getVersion(ref version) );
            if (version < FMOD.VERSION.number)
                throw new Exception("Error!  You are using an old version of FMOD " + version.ToString("X") + ".  This program requires " + FMOD.VERSION.number.ToString("X") + ".");

            ERRCHECK( system.init(1, FMOD.INITFLAGS.NORMAL, (IntPtr)null) );
        }

        public void Load(string path)
        {
            if (sound != null)
                ERRCHECK(sound.release());

            var mode = MODE._2D | MODE.HARDWARE | MODE.CREATESTREAM;
            ERRCHECK( system.createSound(path, mode, ref sound) );
            ERRCHECK( system.playSound(FMOD.CHANNELINDEX.FREE, sound, true, ref channel) );
            ERRCHECK( sound.setLoopCount(0) );
        }

        public void Shutdown()
        {
            ERRCHECK( channel.setCallback(null) );

            if (sound != null)
                ERRCHECK( sound.release() );

            if (system != null)
            {
                ERRCHECK(system.close());
                ERRCHECK(system.release());
            }
        }

        public void PlayOrPause()
        {
            if (channel == null) return;

            bool paused = false;
            ERRCHECK( channel.getPaused(ref paused) );
            ERRCHECK( channel.setPaused(!paused) );
            ERRCHECK( channel.setCallback(ChannelCallback) );
        }

        private RESULT ChannelCallback(IntPtr channelraw, CHANNEL_CALLBACKTYPE type, IntPtr commanddata1, IntPtr commanddata2)
        {
            if (type == CHANNEL_CALLBACKTYPE.END)
                songEndAction();

            return RESULT.OK;
        }

        public TimeSpan Position
        {
            get
            {
                if (sound == null || channel == null) return TimeSpan.Zero;

                uint ms = 0;

                var result = channel.getPosition(ref ms, TIMEUNIT.MS);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                if (system != null)
                    system.update();

                var position = TimeSpan.FromMilliseconds(ms);
                return position;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                if (sound == null || channel == null) return TimeSpan.Zero;

                uint ms = 0;

                var result = sound.getLength(ref ms, TIMEUNIT.MS);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                if (system != null)
                    system.update();

                var duration = TimeSpan.FromMilliseconds(ms);
                return duration;
            }
        }

        public bool IsPlaying
        {
            get
            {
                if (sound == null || channel == null) return false;

                RESULT result;
                var playing = false;
                var paused = false;

                result = channel.isPlaying(ref playing);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                result = channel.getPaused(ref paused);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                var boo = playing && !paused;
                return boo;
            }
        }

        public string GetProgress()
        {
            if (sound == null) return null;

            RESULT result;
            uint ms = 0;
            uint lenms = 0;
            bool playing = false;
            bool paused = false;

            if (channel != null)
            {
                result = channel.isPlaying(ref playing);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                result = channel.getPaused(ref paused);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                result = channel.getPosition(ref ms, TIMEUNIT.MS);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);

                result = sound.getLength(ref lenms, TIMEUNIT.MS);
                if ((result != RESULT.OK) && (result != RESULT.ERR_INVALID_HANDLE))
                    ERRCHECK(result);
            }

            if (system != null)
                system.update();

            var duration = TimeSpan.FromMilliseconds(lenms);
            var position = TimeSpan.FromMilliseconds(ms);

            var songName = new StringBuilder(64);
            sound.getName(songName, songName.Capacity);

            int numTags = 0;
            int blah = 0;
            sound.getNumTags(ref numTags, ref blah);
            var tags = new StringBuilder();
            for (var i = 0; i < numTags; i++)
            {
                TAG tag = new TAG();
                sound.getTag(null, i, ref tag);
                tags.AppendFormat("{0} => {1}", tag.name, tag.data).AppendLine();
            }

            var status = string.Format(
                @"{0:mm\:ss} / {1:mm\:ss}
{2}
{3}
{4}
",
                position, 
                duration, 
                paused ? "Paused " : playing ? "Playing" : "Stopped",
                songName,
                tags
            );
            return status;
        }

        private void ERRCHECK(RESULT result)
        {
            if (result != RESULT.OK)
                throw new Exception("FMOD error! " + result + " - " + Error.String(result));
        }
    }
}
