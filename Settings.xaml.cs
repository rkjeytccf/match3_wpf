using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace finalKursach
{
    public partial class Settings : Page
    {
        private MediaPlayer player; 
        private List<string> songs;
        private int currentSongIndex; 
        private List<string> songTitles;
        private bool isfirst;

        public Settings()
        {
            InitializeComponent();

            // Инициализация списка путей к вашим аудиофайлам C:\Users\rugug\source\repos\3 сем\finalKursach\all_i_want_for_christmas.mp3
            songs = new List<string>
            {
                "C:\\Users\\rugug\\source\\repos\\3 сем\\finalKursach\\audio\\jinglebell.mp3",
                "C:\\Users\\rugug\\source\\repos\\3 сем\\finalKursach\\audio\\last_christmas.mp3",
                "C:\\Users\\rugug\\source\\repos\\3 сем\\finalKursach\\audio\\all_i_want_for_christmas.mp3"
};

            songTitles = new List<string>
            {
                "Jingle Bell",
                "Last Christmas",
                "All I Want For Christmas Is You"
            };

            currentSongIndex = 0; // Начальный индекс текущей песни
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            // Создание объекта MediaPlayer для воспроизведения аудио
            player = new MediaPlayer();
            isfirst = true;
        }

        private void PlayCurrentSong()
        {
            try
            {
                if (songs.Count > 0 && currentSongIndex >= 0 && currentSongIndex < songs.Count)
                {
                    MusicManager.Play(songs[currentSongIndex]);
                    MusicTitle.Text = "Current Music: " + songTitles[currentSongIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка воспроизведения: " + ex.Message);
            }
        }

        private void PauseImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MusicManager.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при остановке воспроизведения: " + ex.Message);
            }
        }

        private void PlayImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (isfirst)
                {
                    PlayCurrentSong();
                    isfirst= false;
                }
                else
                {
                    MusicManager.Resume();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при возобновлении воспроизведения: " + ex.Message);
            }
        }


        private void NextImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MusicManager.Stop();
                currentSongIndex = (currentSongIndex + 1) % songs.Count;
                PlayCurrentSong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при переключении песни: " + ex.Message);
            }
        }

        private void BackImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Menuu menu = new Menuu();
            menu.Show();

            if (Application.Current.MainWindow != null && Application.Current.MainWindow != menu)
            {
                Application.Current.MainWindow.Close();
            }

            Application.Current.MainWindow = menu;
        }


       
    }
}
