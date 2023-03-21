using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace CourseDeLevriers
{
    public struct Game
    {
        public void Jeu()
        {
            int[] PositionDepart = new int[2];
            

            BitmapImage ImageCours = new BitmapImage();
            ImageCours.BeginInit();
            ImageCours.UriSource = new Uri("Image/dog.png");
            ImageCours.EndInit();

            Image dogImage = new Image();
            dogImage.Source = ImageCours;

            Person Joe = new Person("Joe", 50, 0);
            Person Bob = new Person("Bob", 75, 0);
            Person Bill = new Person("Bill", 45, 0);

            PositionDepart[0] = 20;
            PositionDepart[1] = 20;
            Dog dog1 = new Dog(1, dogImage, PositionDepart, false);
            Dog dog2 = new Dog(2, dogImage, PositionDepart, false);
            Dog dog3 = new Dog(3, dogImage, PositionDepart, false);
            Dog dog4 = new Dog(4, dogImage, PositionDepart, false);

            Pari ParieJoe = new Pari("Joe", 0, 0);
            Pari ParieBob = new Pari("Bob", 0, 0);
            Pari ParieBill = new Pari("Bill0", 0, 0);

        }

        public void Parie()
        {
            
        }
    }
}
