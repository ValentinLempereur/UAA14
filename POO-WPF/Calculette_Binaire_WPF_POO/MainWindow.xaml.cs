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

namespace Calculette_Binaire_WPF_POO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnCalculer.Click += new RoutedEventHandler(BtnCalculer_Click);
        }

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            Function t1 = new Function(Txtbox1.Text);
            Function t2 = new Function(Txtbox2.Text);
            Function tRes;

            if (RadioBtnAddition.IsChecked == true)
            {
                tRes = t1.Additionne(t2);
                TxtResult.Text = "";
                for (int i = 0; i < 8; i++)
                {
                    TxtResult.Text = TxtResult.Text + tRes.T[i];
                }
                MessageBox.Show(TxtResult.Text);
            }
            else if (RadioBtnSoustraction.IsChecked == true)
            {
                tRes = t1.Soustraction(t2);
                TxtResult.Text = "";
                for (int i = 0; i < 8; i++)
                {
                    TxtResult.Text = TxtResult.Text + tRes.T[i];
                }
                MessageBox.Show(TxtResult.Text);
            }
        }
    }
}
