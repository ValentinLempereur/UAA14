using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CourseDeLevriers
{
    public class Dog
    {
        private int _number;
        private Image _image;
        private int[] _position;
        private bool _win;
        Random rand = new Random();

        public Dog(int Number, int[] Position, bool Win)
        {
            _position = new int[2];
            _position[0] = Position[0];
            _position[1] = Position[1];

            _number = Number;
            _win = Win;



            //----------------------------image----------------------------
            MainWindow plateau = (CourseDeLevriers.MainWindow)App.Current.MainWindow;

            BitmapImage ImageCours = new BitmapImage();
            ImageCours.BeginInit();
            ImageCours.UriSource = new Uri(@"Image\dog.png", UriKind.Relative);
            ImageCours.EndInit();

            _image = new Image();
            _image.Source = ImageCours;
            _image.Stretch = System.Windows.Media.Stretch.None;

            Canvas.SetLeft(_image, position[0]);
            Canvas.SetTop(_image, position[1]);
            plateau.CanvasDog.Children.Add(image);
            //--------------------------------------------------------


        }

        public void ResetMoov()
        {
            position[0] = 40;
            Canvas.SetLeft(_image, position[0]);
        }
        public bool MoovDog()
        {
            position[0] += rand.Next(10, 50);
            Canvas.SetLeft(_image, position[0]);

            if (position[0] >= 650)
            {
                _win = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsWin()
        {
            if (_win == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public Image image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        public int[] position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public bool win
        {
            get
            {
                return _win;
            }
            set
            {
                _win = value;
            }
        }
    }
}
