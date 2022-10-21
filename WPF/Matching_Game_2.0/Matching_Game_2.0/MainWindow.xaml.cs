using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matching_Game_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            prepareInterface();
        }

        public void prepareInterface()
        {
            //------------------------------Main Dimension---------------------------------
            this.Width = 400;
            this.Height = 450;
            //-----------------------------------------------------------------------------

            //-----------------------------------Grille------------------------------------
            ColumnDefinition[] colDef = new ColumnDefinition[4];
            RowDefinition[] rowDef = new RowDefinition[4];

            for (int i = 0; i < 4; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }
            //------------------------------------------------------------------------------

            //----------------------------------Ajout ?-------------------------------------
            TextBlock[] txt = new TextBlock[16];
            int h = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    txt[h] = new TextBlock();
                    txt[h].Text = "?";
                    txt[h].VerticalAlignment = VerticalAlignment.Center;
                    txt[h].HorizontalAlignment = HorizontalAlignment.Center;
                    txt[h].FontSize = 36;
                    txt[h].FontWeight = FontWeights.Bold;

                    Grid.SetRow(txt[h], i);
                    Grid.SetColumn(txt[h], j);
                    grdMain.Children.Add(txt[h]);
                    txt[h].MouseDown += new MouseButtonEventHandler(Clcik_Game);
                    h++;
                }
            }
            //------------------------------------------------------------------------------
        }

        public void Clcik_Game(object sender, MouseButtonEventArgs e)
        {
            ((TextBlock)sender).Text = "X";
        }

    }
}
