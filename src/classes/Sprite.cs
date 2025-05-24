using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameClasses
{
    public class Sprite
    {

        public ImageBrush image { get; set; }
        Canvas canvas;

        public Sprite(Rect vp, string url)
        {
            image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/src/img/" + url));
            image.TileMode = TileMode.Tile;
            image.Viewport = vp;
            image.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            //image.Stretch = Stretch.Fill;
            image.Freeze();
        }

        /*private Rectangle spriteRect = new Rectangle{
            Tag="Player",
            Height = 100,
            Width = 100,
            Fill = Brushes.Red,
        };

        public void SetCanvas(ref Canvas gameCanvas)
        {
            canvas = gameCanvas;
            canvas.Children.Add(spriteRect);
        }

        public void SetBackground() {
            canvas.Background = image;
        }*/
    }
}