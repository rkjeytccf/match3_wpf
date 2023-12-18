using System;
using System.Windows.Media.Imaging;

namespace finalKursach
{
    public interface IFigure
    {
        FigureType Type { get; set; }
        Vector2 Position { get; set; }
        bool IsNullObject { get; }
        void Destroy(IFigure[,] list, int gridsize);
        BitmapImage GetBitmapImage();
    }
}
