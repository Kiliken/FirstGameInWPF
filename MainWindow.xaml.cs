using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
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

namespace FirstGameInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const float GRAVITY = 0.5f;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        PlayerClass player = new PlayerClass(0,0);

        private class PlayerClass {
            struct Coordinates{ 
                public float X {get; set;}
                public float Y {get; set;}

            }

            Coordinates pos;
            Coordinates vel = new Coordinates{ X=0,Y=1};
            Canvas canvas;
            static double playerHeight = 100.0;

            private Rectangle playerSprite = new Rectangle{
                Tag="Player",
                Height = playerHeight,
                Width = 100,
                Fill = Brushes.Red,
            };

            public PlayerClass(float xPos, float yPos){
                pos.X = xPos;
                pos.Y = yPos;
                Draw();
            }

            public void SetCanvas(ref Canvas gameCanvas) {
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
                if (pos.Y + playerHeight + vel.Y < canvas.ActualHeight)
                    vel.Y += GRAVITY;
                else vel.Y = 0;
            }

        }

        //MAIN HERE

        public MainWindow()
        {
            InitializeComponent();
            player.SetCanvas(ref GameScreen);

            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            player.Update();
        }
    }
}
