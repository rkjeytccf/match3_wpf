using System;
using System.Windows.Media.Imaging;

namespace finalKursach
{
    public class VerticalLine : IFigure
    {
        public FigureType Type { get; set; }
        public Vector2 Position { get; set; }
        public bool IsNullObject { get; private set; }
        private const int PointsForDestroying = 100;
        public VerticalLine(IFigure figure)
        {
            Position = figure.Position;
            Type = figure.Type;
        }
        public void Destroy(IFigure[,] list, int gridsize)
        {
            if (IsNullObject)
                return;
            Game.AddScore(PointsForDestroying);
            IsNullObject = true;
            ActivateBonus(list, gridsize);
        }
        private void ActivateBonus(IFigure[,] list, int gridsize)
        {
            for (int i = 0; i < Level1.GridSize; i++)
            {
                list[Position.X, i].Destroy(list, gridsize);
            }
        }
        public BitmapImage GetBitmapImage()
        {
            Uri uriSource;
            switch (Type)
            {
                case FigureType.Red:
                    uriSource = new Uri(@"pack://application:,,,/images/LineRedV.png");
                    return new BitmapImage(uriSource);
                case FigureType.Blue:
                    uriSource = new Uri(@"pack://application:,,,/images/LineBlueV.png");
                    return new BitmapImage(uriSource);
                case FigureType.Green:
                    uriSource = new Uri(@"pack://application:,,,/images/LineGreenV.png");
                    return new BitmapImage(uriSource);
                case FigureType.Orange:
                    uriSource = new Uri(@"pack://application:,,,/images/LineOrangeV.png");
                    return new BitmapImage(uriSource);
                default:
                    uriSource = new Uri(@"pack://application:,,,/images/LinePurpleV.png");
                    return new BitmapImage(uriSource);
            }
        }
    }
}
