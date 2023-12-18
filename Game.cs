using System.Collections.Generic;
using System.Threading.Tasks;
namespace finalKursach
{
    public enum GameState
    {
        FirstClick,
        SecondClick,
        Animation
    }
    public class Game
    {
        public static bool IsInitialized { get; private set; } = false;
        private static int _score;
        public static int _steps = 25;
        public static int blue = 29;
        private readonly Level1 window1;
        private readonly Level2 window2;
        private readonly Level3 window3;
        private readonly GameGrid _gameGrid;
        private int gridsize;
        private GameState _state;
        private Vector2 _selected = Vector2.NullObject;
        public struct Tasks
        {
            public FigureType Type;
            public int Count;
        }
        public List<Tasks> TasksList { get; private set; } = new List<Tasks>();
        public void AddTask(FigureType type, int count)
        {
            TasksList.Add(new Tasks { Type = type, Count = count });
        }
        private const int SwapDelayMilliseconds = 200;
        private const int VisualsDelayMilliseconds = 100;
        private const int DestroyDelayMilliseconds = 500;
        private const int PushDownDelayMilliseconds = 200;
        private bool three = false;
        public Game(Level1 window, int gridSize)
        {
            window1 = window;
            this.gridsize = gridSize;
            _gameGrid = new GameGrid(this.gridsize);
            _state = GameState.FirstClick;

        }
        public Game(Level2 window, int gridSize)
        {
            window2 = window;
            _steps = 20;
            this.gridsize = gridSize;
            _gameGrid = new GameGrid(this.gridsize);
            _state = GameState.FirstClick;

        }
        public Game(Level3 window, int gridSize)
        {
            window3 = window;
            _steps = 15;
            three = true;
            this.gridsize = gridSize;
            _gameGrid = new GameGrid(this.gridsize);
            blue =_gameGrid.SetBL(three);
            _state = GameState.FirstClick;

        }
        public IFigure GetFigure(Vector2 position) => _gameGrid.GetFigure(position);
        public int GetScore() => _score;
        public int GetSteps() => _steps;
        public int GetBl() => _gameGrid.GetBL(ref blue);
        public static void AddScore(int points)
        {
            _score += points;

        }
        public static void RemoveSteps() => _steps--;
        public static void NullifyScore() => _score = 0;
        public bool isCompletedTask(int score, int targetScore)
        {
            if (score >= targetScore)
            {
                
                return true;
            }
            return false;
        }
        public async void SelectFigure(Vector2 position, Level1 _window)
        {
            if (_state == GameState.FirstClick)
            {
                _selected = position;
                _window.MarkSelected(_selected);
                _state = GameState.SecondClick;
            }
            else if (_state == GameState.SecondClick)
            {
                if (_selected.IsNearby(position))
                {
                    _state = GameState.Animation;
                    SwapFigures(position, _window);
                    await Task.Delay(SwapDelayMilliseconds);
                    _window.SetVisuals();
                    await Task.Delay(VisualsDelayMilliseconds);
                    
                    if (_gameGrid.TryMatch(_selected, position))
                    {
                        
                        _window.MarkDeselected(_selected);
                        _window.DestroyAnimation();
                        await Task.Delay(DestroyDelayMilliseconds);
                        _gameGrid.PushFiguresDown(out var fromList, out var toList);
                        _window.PushDownAnimation(fromList, toList);
                        await Task.Delay(PushDownDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                        _gameGrid.RandomFill();
                        _window.SetVisuals();
                        
                        while (_gameGrid.TryMatchAll())
                        {
                            await Task.Delay(VisualsDelayMilliseconds);
                            _window.DestroyAnimation();
                            await Task.Delay(DestroyDelayMilliseconds);
                            _gameGrid.PushFiguresDown(out fromList, out toList);
                            _window.PushDownAnimation(fromList, toList);
                            await Task.Delay(PushDownDelayMilliseconds);
                            _window.SetVisuals();
                            await Task.Delay(VisualsDelayMilliseconds);
                            _gameGrid.RandomFill();
                            _window.SetVisuals();
                        }
                    }
                    else
                    {
                        _window.MarkDeselected(_selected);
                        SwapFigures(position, _window);
                        await Task.Delay(SwapDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                    }
                }
                else
                {
                    _window.MarkDeselected(_selected);
                }
                _selected = Vector2.NullObject;
                _state = GameState.FirstClick;
            }
        }
        public async void SelectFigure(Vector2 position, Level2 _window)
        {
            if (_state == GameState.FirstClick)
            {
                _selected = position;
                _window.MarkSelected(_selected);
                _state = GameState.SecondClick;
            }
            else if (_state == GameState.SecondClick)
            {
                if (_selected.IsNearby(position))
                {
                    _state = GameState.Animation;
                    SwapFigures(position, _window);
                    await Task.Delay(SwapDelayMilliseconds);
                    _window.SetVisuals();
                    await Task.Delay(VisualsDelayMilliseconds);

                    if (_gameGrid.TryMatch(_selected, position))
                    {
                        RemoveSteps();
                        _window.MarkDeselected(_selected);
                        _window.DestroyAnimation();
                        await Task.Delay(DestroyDelayMilliseconds);
                        _gameGrid.PushFiguresDown(out var fromList, out var toList);
                        _window.PushDownAnimation(fromList, toList);
                        await Task.Delay(PushDownDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                        _gameGrid.RandomFill();
                        _window.SetVisuals();

                        while (_gameGrid.TryMatchAll())
                        {
                            await Task.Delay(VisualsDelayMilliseconds);
                            _window.DestroyAnimation();
                            await Task.Delay(DestroyDelayMilliseconds);
                            _gameGrid.PushFiguresDown(out fromList, out toList);
                            _window.PushDownAnimation(fromList, toList);
                            await Task.Delay(PushDownDelayMilliseconds);
                            _window.SetVisuals();
                            await Task.Delay(VisualsDelayMilliseconds);
                            _gameGrid.RandomFill();
                            _window.SetVisuals();
                        }
                    }
                    else
                    {
                        _window.MarkDeselected(_selected);
                        SwapFigures(position, _window);
                        await Task.Delay(SwapDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                    }
                }
                else
                {
                    _window.MarkDeselected(_selected);
                }
                _selected = Vector2.NullObject;
                _state = GameState.FirstClick;
            }
        }
        public async void SelectFigure(Vector2 position, Level3 _window)
        {
            if (_state == GameState.FirstClick)
            {
                _selected = position;
                _window.MarkSelected(_selected);
                _state = GameState.SecondClick;
            }
            else if (_state == GameState.SecondClick)
            {
                if (_selected.IsNearby(position))
                {
                    _state = GameState.Animation;
                    SwapFigures(position, _window);
                    await Task.Delay(SwapDelayMilliseconds);
                    _window.SetVisuals();
                    await Task.Delay(VisualsDelayMilliseconds);

                    if (_gameGrid.TryMatch(_selected, position))
                    {
                        RemoveSteps();
                        _window.MarkDeselected(_selected);
                        _window.DestroyAnimation();
                        await Task.Delay(DestroyDelayMilliseconds);
                        _gameGrid.PushFiguresDown(out var fromList, out var toList);
                        _window.PushDownAnimation(fromList, toList);
                        await Task.Delay(PushDownDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                        _gameGrid.RandomFill();
                        _window.SetVisuals();

                        while (_gameGrid.TryMatchAll())
                        {
                            await Task.Delay(VisualsDelayMilliseconds);
                            _window.DestroyAnimation();
                            await Task.Delay(DestroyDelayMilliseconds);
                            _gameGrid.PushFiguresDown(out fromList, out toList);
                            _window.PushDownAnimation(fromList, toList);
                            await Task.Delay(PushDownDelayMilliseconds);
                            _window.SetVisuals();
                            await Task.Delay(VisualsDelayMilliseconds);
                            _gameGrid.RandomFill();
                            _window.SetVisuals();
                        }
                    }
                    else
                    {
                        _window.MarkDeselected(_selected);
                        SwapFigures(position, _window);
                        await Task.Delay(SwapDelayMilliseconds);
                        _window.SetVisuals();
                        await Task.Delay(VisualsDelayMilliseconds);
                    }
                }
                else
                {
                    _window.MarkDeselected(_selected);
                }
                _selected = Vector2.NullObject;
                _state = GameState.FirstClick;
            }
        }
        public void Initialize()
        {
            while (_gameGrid.TryMatchAll())
            {
                _gameGrid.RandomFill();
            }
            IsInitialized = true;
        }
        private void SwapFigures(Vector2 position, Level1 _window)
        {
            _gameGrid.SwapFigures(_selected, position);
            _window.SwapAnimation(_selected, position);
        }
        private void SwapFigures(Vector2 position, Level2 _window)
        {
            _gameGrid.SwapFigures(_selected, position);
            _window.SwapAnimation(_selected, position);
        }
        private void SwapFigures(Vector2 position, Level3 _window)
        {
            _gameGrid.SwapFigures(_selected, position);
            _window.SwapAnimation(_selected, position);
        }
    }
}
