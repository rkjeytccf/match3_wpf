using System;
using System.Windows.Media.Imaging;

namespace finalKursach
{
    public class BasicFigure : IFigure
    {
        public FigureType Type { get; set; }
        public Vector2 Position { get; set; }
        public bool IsNullObject { get; private set; }
        private const int PointsForDestroying = 100;
        public BasicFigure(FigureType type, Vector2 position)
        {
            Type = type;
            Position = position;
        }
        public void Destroy(IFigure[,] list, int gridsize)
        {
            if (IsNullObject)
                return;
            Game.AddScore(PointsForDestroying);
            IsNullObject = true;
        }
        public BitmapImage GetBitmapImage()
        {
            Uri uriSource;
            switch (Type)
            {
                case FigureType.Red:
                    uriSource = new Uri(@"pack://application:,,,/images/red.png");
                    return new BitmapImage(uriSource);
                case FigureType.Blue:
                    uriSource = new Uri(@"pack://application:,,,/images/blue.png");
                    return new BitmapImage(uriSource);
                case FigureType.Green:
                    uriSource = new Uri(@"pack://application:,,,/images/green.png");
                    return new BitmapImage(uriSource);
                case FigureType.Orange:
                    uriSource = new Uri(@"pack://application:,,,/images/orange.png");
                    return new BitmapImage(uriSource);
                default:
                    uriSource = new Uri(@"pack://application:,,,/images/purple.png");
                    return new BitmapImage(uriSource);
            }
        }
        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
