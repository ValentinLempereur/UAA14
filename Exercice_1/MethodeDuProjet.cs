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
                Console.WriteLine("Reencoder votre chiffre");
            }

            return nbr;
        }
    }
}
