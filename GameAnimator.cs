using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
namespace finalKursach
{
    public class GameAnimator
    {
        public void DestroyAnimation(Image figure)
        {
            var widthAnimation = new DoubleAnimation()
            {
                From = figure.ActualWidth,
                To = figure.ActualWidth + 25,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            var heightAnimation = new DoubleAnimation()
            {
                From = figure.ActualHeight,
                To = figure.ActualHeight + 25,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            var opacityAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            figure.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            figure.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);
            figure.BeginAnimation(FrameworkElement.HeightProperty, heightAnimation);
        }
        public void MoveAnimation(Image figure, Vector2 from, Vector2 to)
        {
            DoubleAnimation moveAnimation;
            if (from.X == to.X)
            {
                moveAnimation = new DoubleAnimation
                {
                    From = Level1.CanvasTop + Level1.CellSizePx * from.Y,
                    To = Level1.CanvasTop + Level1.CellSizePx * to.Y,
                    Duration = TimeSpan.FromMilliseconds(100)
                };
                figure.BeginAnimation(Canvas.TopProperty, moveAnimation);
            }
            else
            {
                moveAnimation = new DoubleAnimation
                {
                    From = Level1.CanvasLeft + Level1.CellSizePx * from.X,
                    To = Level1.CanvasLeft + Level1.CellSizePx * to.X,
                    Duration = TimeSpan.FromMilliseconds(100)
                };
                figure.BeginAnimation(Canvas.LeftProperty, moveAnimation);
            }
        }
    }
}
