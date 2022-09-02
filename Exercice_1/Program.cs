using System;

namespace Exercice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodeDuProjet Outils = new MethodeDuProjet();
            double[] T = new double[9];

            string question = "encoder un chiffre";

            for (int i = 0; i > 10; i++)
            {
                T[i] = Outils.Lecture(question);
            }
        }
    }
}
