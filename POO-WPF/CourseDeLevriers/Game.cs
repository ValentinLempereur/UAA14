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


            //----------------CreationPerson----------------
            person[0] = new Person("Joe", 50, 0);
            person[1] = new Person("Bob", 75, 0);
            person[2] = new Person("Bill", 45, 0);



            //----------------CreationDog----------------

            PositionDepart[0] = 40; //730
            PositionDepart[1] = 25;
            dog[0] = new Dog(0, PositionDepart, false);

            PositionDepart[1] = 75;
            dog[1] = new Dog(1, PositionDepart, false);

            PositionDepart[1] = 150;
            dog[2] = new Dog(2, PositionDepart, false);

            PositionDepart[1] = 225;
            dog[3] = new Dog(3, PositionDepart, false);




            //----------------CreationParie----------------
            parie[0] = new Pari("Joe", 0, 0);
            parie[1] = new Pari("Bob", 0, 0);
            parie[2] = new Pari("Bill0", 0, 0);

        }

        public void Parie(Person[] person, int nbr, int ndog, string who, out string text, Pari[] parie)
        {
            text = who + " n'a pas encore parié";

            if (ndog >= 1 && ndog <= 4)
            {
                if (nbr >= 5)
                {
                    if (who == "Joe")
                    {
                        if (nbr < person[0].money)
                        {
                            text = "Joe a parié " + nbr + " sur le chien n° " + ndog;
                            parie[0].montant = nbr;
                            parie[0].numberDog = ndog;
                        }
                    }
                    else if (who == "Bob")
                    {
                        if (nbr < person[1].money)
                        {
                            text = "Bob a parié " + nbr + " sur le chien n° " + ndog;
                            parie[0].montant = nbr;
                            parie[0].numberDog = ndog;
                        }
                    }
                    else if (who == "Bill")
                    {
                        if (nbr < person[2].money)
                        {
                            text = "bill a parié " + nbr + " sur le chien n° " + ndog;
                            parie[0].montant = nbr;
                            parie[0].numberDog = ndog;
                        }
                    }
                }
            }
        }
    }
}
