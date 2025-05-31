using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Policy;
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
using GameClasses;

namespace FirstGameInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const float GRAVITY = 0.5f;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private bool LeftKeyPressed,RightKeyPressed,freeFall;
        private float jumpCooldown;

        List<Rect> colliders = new List<Rect>();
        PlayerClass player = new PlayerClass(0,0);

        Sprite bg = new Sprite(new Rect(0, 1, 2, 2), "map/background.png");
        

        //MAIN HERE

        public MainWindow()
        {
            InitializeComponent();
            GameScreen.Focus();
            player.SetCanvas(ref GameScreen);

            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();


            GameScreen.Background = bg.image;

            foreach( var x in GameScreen.Children.OfType<Rectangle>()){
                
                if((string)x.Tag == "collider"){

                    //x.Stroke = Brushes.Black;
                    colliders.Add(new Rect(Canvas.GetLeft(x),Canvas.GetTop(x), x.Width, x.Height));
                    
                }
                
            }

            

        }

        private void GameTick(object sender, EventArgs e)
        {
            player.Update();

            player.vel.X = 0;
            if (LeftKeyPressed) player.vel.X = -5;
            else if (RightKeyPressed) player.vel.X = 5;


            Rect playerHitbox = new Rect(player.pos.X, player.pos.Y, 100f, PlayerClass.playerHeight);

            foreach (Rect x in colliders)
            {
                if (playerHitbox.IntersectsWith(x))
                {
                    //textInfo.Content = "player = " + playerHitbox.ToString() + "\n coll = " + x.ToString();



                    if (player.pos.Y > x.Top - x.Height / 2)
                    {
                        //
                    }
                    else
                    {
                        player.vel.Y = 0;
                        player.pos.Y = (float)x.Top - PlayerClass.playerHeight;
                        freeFall = false;
                    }
                }
                else
                    freeFall = true;
            }

            if (freeFall)
                player.vel.Y += GRAVITY;
            

        }

        private void OnKeyDown(object sender, KeyEventArgs e){
            switch(e.Key) {
                case Key.A:
                    LeftKeyPressed = true;
                    break;
                case Key.D:
                    RightKeyPressed = true;
                    break;
                case Key.W:
                    
                        player.vel.Y = -15;
                    
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e){
            switch(e.Key) {
                case Key.A:
                    LeftKeyPressed = false;
                    break;
                case Key.D:
                    RightKeyPressed = false;
                    break;
                
            }
        }
    }
}
