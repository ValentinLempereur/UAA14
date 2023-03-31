using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace CourseDeLevriers
{
    public struct Game
    {
        public void Jeu(out Dog[] dog, out Person[] person, out Pari[] parie)
        {
            //----------------Declaration----------------
            int[] PositionDepart = new int[2];

            person = new Person[3];
            dog = new Dog[4];
            parie = new Pari[3];



            //----------------Image----------------
            BitmapImage ImageCours = new BitmapImage();
            Image[] dogImage = new Image[4];

            for (int i = 0; i < 4; i++)
            {
                dogImage[i] = new Image();
            }

            ImageCours.BeginInit();
            ImageCours.UriSource = new Uri(@"Image\dog1.png", UriKind.Relative);
            ImageCours.EndInit();
            dogImage[0].Source = ImageCours;

            ImageCours.UriSource = new Uri(@"Image\dog2.png", UriKind.Relative);
            dogImage[1].Source = ImageCours;

            ImageCours.UriSource = new Uri(@"Image\dog3.png", UriKind.Relative);
            dogImage[2].Source = ImageCours;

            ImageCours.UriSource = new Uri(@"Image\dog4.png", UriKind.Relative);
            dogImage[3].Source = ImageCours;



            //----------------CreationPerson----------------
            person[0] = new Person("Joe", 50, 0);
            person[1] = new Person("Bob", 75, 0);
            person[2] = new Person("Bill", 45, 0);



            //----------------CreationDog----------------
            for (int i = 0; i < 4; i++)
            {
                PositionDepart[0] = 1;
                PositionDepart[1] = 1;
                dog[i] = new Dog(i, dogImage[i], PositionDepart, false);
            }



            //----------------CreationParie----------------
            parie[0] = new Pari("Joe", 0, 0);
            parie[1] = new Pari("Bob", 0, 0);
            parie[2] = new Pari("Bill0", 0, 0);

        }

        public void Parie()
        {
            
        }
    }
}
