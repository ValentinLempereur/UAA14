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

namespace Calculette_Binaire_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ushort[] t1 = new ushort[8];
        ushort[] t2 = new ushort[8];
        ushort[] tRes = new ushort[8];
        Function fonction = new Function();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            t1 = fonction.RemplirTableau(Txtbox1.Text);
            t2 = fonction.RemplirTableau(Txtbox2.Text);

            if (RadioBtnAddition.IsChecked == true)
            {
                fonction.Additionne(out tRes, out bool ok, t1, t2);
                for (int i = 0; i < 8; i++)
                {
                    TxtResult.Text = TxtResult.Text + tRes[i];
                }
                MessageBox.Show(TxtResult.Text);
            }
            else if (RadioBtnSoustraction.IsChecked == true)
            {
                fonction.Soustraction(t1, t2, out tRes);
                for (int i = 0; i < 8; i++)
                {
                    TxtResult.Text = TxtResult.Text + tRes[i];
                }
                MessageBox.Show(TxtResult.Text);
            }
        }
    }
}
