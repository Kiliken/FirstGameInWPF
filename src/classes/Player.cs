using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameClasses
{
    public class PlayerClass
    {

        

        public Coordinates pos;
        public Coordinates vel = new Coordinates { X = 0, Y = 0 };
        Canvas canvas;
        public static float playerHeight = 100.0f;

        private Rectangle playerSprite = new Rectangle
        {
            Tag = "Player",
            Height = playerHeight,
            Width = 100,
            Fill = Brushes.Red,
        };

        public PlayerClass(float xPos, float yPos)
        {
            pos.X = xPos;
            pos.Y = yPos;
            Draw();
        }

        public void SetCanvas(ref Canvas gameCanvas)
        {
            canvas = gameCanvas;
            canvas.Children.Add(playerSprite);
        }

        private void Draw()
        {
            Canvas.SetTop(playerSprite, pos.Y);
            Canvas.SetLeft(playerSprite, pos.X);
        }

        public void Update()
        {
            Draw();
            pos.Y += vel.Y;
            pos.X += vel.X;
            /*if (pos.Y + playerHeight + vel.Y < canvas.ActualHeight)
                vel.Y += GRAVITY;
            else vel.Y = 0;*/
        }

    }

    public struct Coordinates
    {
        public float X { get; set; }
        public float Y { get; set; }


        /*public Coordinates(float x = 0f, float y = 0f)
        {
            this.X = x;
            this.Y = y;
        }*/

    }
}