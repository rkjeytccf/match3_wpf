using System;
using System.Windows.Media.Imaging;

namespace finalKursach
{
    public class Bomb : IFigure
    {
        public FigureType Type { get; set; }
        public Vector2 Position { get; set; }
        public bool IsNullObject { get; private set; }
        private const int PointsForDestroying = 100;
        public Bomb(IFigure figure)
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
            if (Position.Y > 0)
            {
                list[Position.X, Position.Y - 1].Destroy(list, gridsize);
                if (Position.X > 0)
                {
                    list[Position.X - 1, Position.Y - 1].Destroy(list, gridsize);
                }
                if (Position.X < Level1.GridSize - 1)
                {
                    list[Position.X + 1, Position.Y - 1].Destroy(list, gridsize);
                }
            }
            if (Position.Y < Level1.GridSize - 1)
            {
                list[Position.X, Position.Y + 1].Destroy(list, gridsize);
                if (Position.X > 0)
                {
                    list[Position.X - 1, Position.Y + 1].Destroy(list, gridsize);
                }
                if (Position.X < Level1.GridSize - 1)
                {
                    list[Position.X + 1, Position.Y + 1].Destroy(list, gridsize);
                }
            }
            if (Position.X > 0)
            {
                list[Position.X - 1, Position.Y].Destroy(list, gridsize);
            }
            if (Position.X < Level1.GridSize - 1)
            {
                list[Position.X + 1, Position.Y].Destroy(list, gridsize);
            }
        }
        public BitmapImage GetBitmapImage()
        {
            Uri uriSource;
            switch (Type)
            {
                case FigureType.Red:
                    uriSource = new Uri(@"pack://application:,,,/images/RedBomb.png");
                    return new BitmapImage(uriSource);
                case FigureType.Blue:
                    uriSource = new Uri(@"pack://application:,,,/images/BlueBomb.png");
                    return new BitmapImage(uriSource);
                case FigureType.Green:
                    uriSource = new Uri(@"pack://application:,,,/images/GreenBomb.png");
                    return new BitmapImage(uriSource);
                case FigureType.Orange:
                    uriSource = new Uri(@"pack://application:,,,/images/OrangeBomb.png");
                    return new BitmapImage(uriSource);
                default:
                    uriSource = new Uri(@"pack://application:,,,/images/PurpleBomb.png");
                    return new BitmapImage(uriSource);
            }
        }
    }
}
