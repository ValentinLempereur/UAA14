using System;
using System.Collections.Generic;
using System.Text;

namespace Sanduichs_aleatoire
{
    class SandwichMaker
    {
        string[] proteine = new string[4] {"jambon", "fromage", "roast beef", "salami"}; 
        string[] condiments = new string[4] {"de la mayonnaise", "du ketchup", "de la moutarde", "du tabasco"};
        string[] pain = new string[3] {"pain blanc", "pain gris", "pain complet"};
        string[] crudités = new string[4] {"salades", "oeufs", "tomates", "ognons"};

        int[] Nbr1 = new int[3];
        int Nbr2;
        Random random = new Random();

        public string ComposeSandwich()
        {

            Nbr2 = random.Next(3);

            for (int i = 0; i < 3; i++)
            {
                
                Nbr1[i] = random.Next(4);
            }

            return "Voici votre sandwich : un " + pain[Nbr2] + " avec du " + proteine[Nbr1[0]] + " " + crudités[Nbr1[1]] + " avec " + condiments[Nbr1[2]] + "\n";
        }
    }
}
