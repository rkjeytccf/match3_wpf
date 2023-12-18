using System;
using System.Windows.Media;

namespace finalKursach
{
    public static class MusicManager
    {
        private static MediaPlayer player = new MediaPlayer();
        private static bool isPlaying = false;
        private static bool isPaused = false;
        private static TimeSpan pausedPosition = TimeSpan.Zero;
        public static void Play(string path)
        {
            player.Open(new Uri(path));
            player.Play();
            isPlaying = true;
        }
        public static void Pause()
        {
            if (player != null && player.Source != null && player.CanPause)
            {
                player.Pause();
                isPlaying = false;
                isPaused = true;
                pausedPosition = player.Position;
            }
        }
        public static void Resume()
        {
            if (player != null && player.Source != null)
            {
                if (isPaused)
                {
                    player.Position = pausedPosition;
                    player.Play();
                    isPlaying = true;
                    isPaused = false;
                }
            }
        }
        public static void Stop()
        {
            player.Stop();
            isPlaying = false;
        }
        public static bool IsPlaying()
        {
            return isPlaying;
        }
    }
}
