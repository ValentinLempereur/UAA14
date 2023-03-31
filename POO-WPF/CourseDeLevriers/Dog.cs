using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CourseDeLevriers
{
    public class Dog
    {
        private int _number;
        private Image _image;
        private int[] _position;
        private bool _win;

        public Dog(int Number, Image Image, int[] Position, bool Win)
        {
            _position = new int[2];

            _number = Number;
            _image = Image;
            _position[0] = Position[0];
            _position[1] = Position[1];
            _win = Win;
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
