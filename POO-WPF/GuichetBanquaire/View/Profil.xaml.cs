using System;
using System.Collections.Generic;
using System.Data;
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
using GuichetBanquaire.Class;
using GuichetBanquaire.Modele;

namespace GuichetBanquaire.View
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        MainWindow pagePrincipale = (MainWindow)App.Current.MainWindow;
        MysqlRequete mysql = new MysqlRequete();
        TextBox TxtName = new TextBox();
        TextBox TxtPassWord = new TextBox();

        public Profil()
        {
            InitializeComponent();
            PrepareInitialize();
        }
        public void PrepareInitialize()
        {
            this.Background = Brushes.BurlyWood;
            this.FontSize = 30;

            //-------------RechercheBD-------------
            mysql.SelectInfosAll("SELECT * FROM users", out DataSet ds, out int NbrRow);

            //mysql.SelectInfosAll("SELECT * FROM users", out DataSet ds, out int NbrRow);
            //mysql.SelectInfosAll("SELECT * FROM users", out DataSet ds, out int NbrRow);

            //-------------Dockpanel-------------
            DockPanel dock = new DockPanel();
            dock.HorizontalAlignment = HorizontalAlignment.Left;
            DockPanel dock1 = new DockPanel();
            DockPanel dock2 = new DockPanel();
            DockPanel dock3 = new DockPanel();
            DockPanel dock4 = new DockPanel();

            //-------------Margin-------------
            Thickness margin = new Thickness();
            margin.Left = 300;

            //-------------Button-------------
            Button modify = new Button();
            Button back = new Button();

            modify.Content = "modifier";
            modify.Width = 250;
            modify.Height = 90;
            modify.Click += new RoutedEventHandler(Modify_Click);
            modify.FontWeight = FontWeights.Bold;
            modify.Background = Brushes.OrangeRed;
            modify.Margin = margin;

            margin.Left = 500;

            back.Content = "retour";
            back.Width = 250;
            back.Height = 90;
            back.Click += new RoutedEventHandler(Back_Click);
            back.FontWeight = FontWeights.Bold;
            back.Background = Brushes.LawnGreen;
            back.Margin = margin;

            margin.Left = 300;

            //-------------Name-------------
            TextBlock TxtBName = new TextBlock();

            TxtBName.Text = "Nom de l'utilisateur :";
            TxtBName.Height = 50;
            TxtBName.Width = 300;
            TxtBName.Margin = margin;
            TxtBName.FontWeight = FontWeights.Bold;

            TxtName.Text = pagePrincipale.perso.name;
            TxtName.Height = 50;
            TxtName.Width = 400;

            //-------------PassWord-------------
            TextBlock TxtBPassWord = new TextBlock();

            TxtBPassWord.Text = "Mot de passe :";
            TxtBPassWord.Height = 50;
            TxtBPassWord.Width = 300;
            TxtBPassWord.Margin = margin;
            TxtBPassWord.FontWeight = FontWeights.Bold;

            TxtPassWord.Text = pagePrincipale.perso.MotDePasse;
            TxtPassWord.Height = 50;
            TxtPassWord.Width = 400;

            //-------------CompteCourant-------------
            TextBlock TxtBCourant = new TextBlock();
            ListBox ListCourant = new ListBox();

            TxtBCourant.Text = "Vos comptes courants :";
            TxtBCourant.Height = 50;
            TxtBCourant.Width = 300;
            TxtBCourant.Margin = margin;
            TxtBCourant.FontWeight = FontWeights.Bold;

            for (int i = 0; i < pagePrincipale.compteCourant.Length; i++)
            {
                ListCourant.Items.Add(pagePrincipale.compteCourant[i].NumeroBanquaire);
            }
            ListCourant.Height = 50;
            ListCourant.Width = 400;

            //-------------CompteEpargne-------------
            TextBlock TxtBEpargne = new TextBlock();
            ListBox ListEpargne = new ListBox();

            TxtBEpargne.Text = "Vos comptes épargnes :";
            TxtBEpargne.Height = 50;
            TxtBEpargne.Width = 300;
            TxtBEpargne.Margin = margin;
            TxtBEpargne.FontWeight = FontWeights.Bold;

            for (int i = 0; i < pagePrincipale.compteCourant.Length; i++)
            {
                ListEpargne.Items.Add(pagePrincipale.compteEpargne[i].NumeroBanquaire);
            }
            ListEpargne.Height = 50;
            ListEpargne.Width = 400;

            //-------------Affection-------------
            dock.Children.Add(modify);
            dock.Children.Add(back);
            Grid.SetRow(dock, 5);

            dock1.Children.Add(TxtBName);
            dock1.Children.Add(TxtName);
            Grid.SetRow(dock1, 1);

            dock2.Children.Add(TxtBPassWord);
            dock2.Children.Add(TxtPassWord);
            Grid.SetRow(dock2, 2);

            dock3.Children.Add(TxtBCourant);
            dock3.Children.Add(ListCourant);
            Grid.SetRow(dock3, 3);

            dock4.Children.Add(TxtBEpargne);
            dock4.Children.Add(ListEpargne);
            Grid.SetRow(dock4, 4);

            grdMain.Children.Add(dock);
            grdMain.Children.Add(dock1);
            grdMain.Children.Add(dock2);
            grdMain.Children.Add(dock3);
            grdMain.Children.Add(dock4);


        }

        public void Modify_Click(object sender, RoutedEventArgs e)
        {
            if (pagePrincipale.perso.name != TxtName.Text && pagePrincipale.perso.MotDePasse != TxtPassWord.Text)
            {
                MessageBox.Show("Votre nom d'utilisateur et votre mot de passe ont été modifié");
            }
            else if (pagePrincipale.perso.name != TxtName.Text)
            {
                MessageBox.Show("Votre nom d'utilisateur a été modifié");
            }
            else if (pagePrincipale.perso.MotDePasse != TxtPassWord.Text)
            {
                MessageBox.Show("votre mot de passe a été modifié");
            }

            pagePrincipale.perso.name = TxtName.Text;
            pagePrincipale.perso.MotDePasse = TxtPassWord.Text;
            mysql.ModifyUser(pagePrincipale.perso.Id, TxtName.Text, TxtPassWord.Text);
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            pagePrincipale.frame.Content = new Operation();
        }
    }
}
