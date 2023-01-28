using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace CeUAA14Partie2_dec22_Lempereur
{
    internal class Quadrillage
    {
        MainWindow quadrillage = (CeUAA14Partie2_dec22_Lempereur.MainWindow)App.Current.MainWindow;
        

        public void prepareInterface()
        {
            //------------------------------Main Dimension---------------------------------
            quadrillage.Width = 800;
            quadrillage.Height = 720;
            quadrillage.FontSize = 36;
            //-----------------------------------------------------------------------------
            Button[,] Btn = new Button[10, 10];


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Btn[i, j] = new Button();
                    Btn[i, j].Content = CalculNumero(i, j);
                    Btn[i, j].Width = 60;
                    Btn[i, j].Height = 60;
                    Grid.SetRow(Btn[i, j], i);
                    Grid.SetColumn(Btn[i, j], j);
                    quadrillage.grdMain2.Children.Add(Btn[i, j]);
                    Btn[i, j].VerticalAlignment = VerticalAlignment.Center;
                    Btn[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    if ((int)Btn[i, j].Content % 2 == 0)
                    {
                        Btn[i, j].Background = Brushes.Aqua;
                    }
                    else
                    {
                        Btn[i, j].Background = Brushes.Red;
                    }
                }
            }
        }


        public int CalculNumero(int i, int j)
        {

            if (i % 2 == 0)
            {
                return i * 10 + 1 + j;
            }
            else
            {
                return i * 10 + 10 - j;
            }
        }
    }
}
