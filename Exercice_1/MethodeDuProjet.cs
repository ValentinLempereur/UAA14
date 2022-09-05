using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice_1
{
    public struct MethodeDuProjet
    {
        public double Lecture(string question)
        {
            double nbr;

            Console.WriteLine(question);
            while (!double.TryParse(Console.ReadLine(), out nbr))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Réencoder votre chiffre");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }

            return nbr;
        }

        public double Moyenne(double []T)
        {
            double result = 0;
            for (int i = 0; i < 10; i++)
            {
                result = result + T[i];
            }

            result = result / 10;

            return result;
        }

        public void Affiche(double[] T)
        {
            for (int i = 0; i < T.GetLength(0); i++)
            {
                Console.Write(T[i]);
            }
        }
    }
}
