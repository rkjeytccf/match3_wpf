﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace finalKursach
{
    /// <summary>
    /// Логика взаимодействия для Level3.xaml
    /// </summary>
    public partial class Level3 : Page
    {
        public const int GridSize = 8;
        public const int CellSizePx = 75;
        public const int CanvasTop = 80; // XAML 
        public const int CanvasLeft = 260;
        private const int TimeForGame = 5000;
        private const int TargetTask = 55500;

        private bool isClosed;
        private int currentScore;
        private int steps;
        private readonly int blue;


        private readonly Dictionary<Vector2, Image> _images;
        private readonly Dictionary<Vector2, Button> _buttons;
        private readonly Game _game;
        private readonly GameAnimator _animator;
        private DispatcherTimer _timer;
        private bool _isWindowInitialized = false;
        private int _timeSeconds;

        public Level3()
        {
            
            
            currentScore = 0;
            isClosed = false;
            InitializeComponent();
            _game = new Game(this, GridSize);
            blue = _game.GetBl();
            _animator = new GameAnimator();
            _buttons = new Dictionary<Vector2, Button>();
            _images = new Dictionary<Vector2, Image>();
            CreateGridLayout();
            _game.Initialize();
            SetVisuals();
            InitializeCounters();
            steps = 25;
        }

        public void MarkSelected(Vector2 buttonIndex)
        {
            _buttons[buttonIndex].Background = new SolidColorBrush(Colors.LightPink);
        }

        public void MarkDeselected(Vector2 buttonIndex)
        {
            _buttons[buttonIndex].Background = new SolidColorBrush(Colors.WhiteSmoke);
        }

        public void DestroyAnimation()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var position = new Vector2(i, j);
                    if (_game.GetFigure(position).IsNullObject)
                    {
                        _animator.DestroyAnimation(_images[position]);
                    }
                }
            }
        }

        public void SwapAnimation(Vector2 firstPosition, Vector2 secondPosition)
        {
            var firstFigure = _images[firstPosition];
            var secondFigure = _images[secondPosition];
            _animator.MoveAnimation(firstFigure, firstPosition, secondPosition);
            _animator.MoveAnimation(secondFigure, secondPosition, firstPosition);
        }

        public void PushDownAnimation(List<Vector2> dropsFrom, List<Vector2> dropsTo)
        {
            for (int i = 0; i < dropsFrom.Count; i++)
            {
                var figure = _images[dropsFrom[i]];
                _animator.MoveAnimation(figure, dropsFrom[i], dropsTo[i]);
            }
        }

        public void SetVisuals()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var position = new Vector2(i, j);
                    if (Game.IsInitialized && _isWindowInitialized)
                        CanvasLayout.Children.Remove(_images[position]);

                    var figure = _game.GetFigure(position);
                    if (figure.IsNullObject)
                        continue;

                    var image = new Image
                    {
                        Source = _game.GetFigure(position).GetBitmapImage(),
                        Width = CellSizePx
                    };
                    Canvas.SetTop(image, CanvasTop + CellSizePx * j);
                    Canvas.SetLeft(image, CanvasLeft + CellSizePx * i);
                    image.IsHitTestVisible = false;
                    CanvasLayout.Children.Add(image);
                    _images[position] = image;
                }
            }
            UpdateScore();
            _isWindowInitialized = true;
        }

        private void UpdateScore()
        {
            currentScore = _game.GetScore();
            steps = _game.GetSteps();
            ScoreText.Text = currentScore.ToString();
            StepsText.Text = steps.ToString();
            BlueTask.Text = "Blue left: " + _game.GetBl().ToString();
        }

        private void InitializeCounters()
        {

            Game.NullifyScore();
            UpdateScore();
            _timeSeconds = 0;
            _timer = new DispatcherTimer();
            _timer.Tick += UpdateTime;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            _timeSeconds++;
            if (_timeSeconds >= TimeForGame || _game.isCompletedTask(currentScore, TargetTask) || steps == 0 || isClosed || _game.GetBl() <= 0)
            {
                _timer.Tick -= UpdateTime;
                if (_timeSeconds >= TimeForGame || (steps == 0 && (!_game.isCompletedTask(currentScore, TargetTask) || blue > 0 )))
                {
                    Level33.Content = new Results(false, currentScore.ToString(), 3);
                }
                else if (_game.GetBl() <= 0)
                {
                    Level33.Content = new Results(true, currentScore.ToString(), 3);
                }
                else
                {
                }
                


            }
            TimeText.Text = _timeSeconds.ToString();

        }

        private void GridClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var id = (Vector2)button.DataContext;
            _game.SelectFigure(id, this);
        }

        private void CreateGridLayout()
        {
            for (int i = 0; i < GridSize; i++)
            {
                var column = new ColumnDefinition
                {
                    Width = new GridLength(CellSizePx)
                };
                var row = new RowDefinition()
                {
                    Height = new GridLength(CellSizePx)
                };
                GridLayout.ColumnDefinitions.Add(column);
                GridLayout.RowDefinitions.Add(row);
            }

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var button = new Button()
                    {
                        Background = new SolidColorBrush(Colors.WhiteSmoke),
                        Opacity = 0.8,
                        BorderThickness = new Thickness(1),
                        BorderBrush = new SolidColorBrush(Colors.LightPink),
                        DataContext = new Vector2(i, j)
                    };
                    button.Click += GridClick;
                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    GridLayout.Children.Add(button);

                    _buttons[new Vector2(i, j)] = button;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Level33.Content = new Levels();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Level33.Content = new Rules(3);
            _timer.Stop();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isClosed = true;
            Level33.Content = new Level3();
        }

    }
}
