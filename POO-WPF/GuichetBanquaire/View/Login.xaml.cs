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
//Base de donnée
using System.Data;
using GuichetBanquaire.Modele;
using GuichetBanquaire;

namespace GuichetBanquaire.View
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow pagePrincipale = (MainWindow)App.Current.MainWindow;

        MysqlRequete mysql = new MysqlRequete();

        StackPanel StackLogin = new StackPanel();

        TextBox LoginName = new TextBox();
        TextBox LoginPassWord = new TextBox();

        public Login()
        {
            InitializeComponent();
            PrepareInitialize();
        }
        public void PrepareInitialize()
        {
            //-----------------This-------------------
            this.Background = Brushes.Tomato;
            this.FontSize = 16;

            //-----------------Margin-----------------
            Thickness myThickness = new Thickness();

            //-----------------Bouton-----------------
            Button Register = new Button();
            Button Enter = new Button();

            myThickness.Top = 20;

            Register.Content = "S'enregiste";
            Register.Click += new RoutedEventHandler(Register_Click);
            Register.Width = 100;
            Register.Height = 30;
            Register.Margin = myThickness;

            myThickness.Top = 350;

            Enter.Content = "Entrer";
            Enter.Click += new RoutedEventHandler(Enter_Click);
            Enter.Width = 120;
            Enter.Height = 40;
            Enter.Margin = myThickness;

            //-----------------Login-----------------
            myThickness.Top = 20;

            TextBlock TxtLogin = new TextBlock();

            myThickness.Left = 130;

            TxtLogin.Text = "Connectez-vous";
            TxtLogin.FontWeight = FontWeights.Bold;
            TxtLogin.Width = 250;
            TxtLogin.Height = 30;
            TxtLogin.Margin = myThickness;
            myThickness.Left = 0;

            LoginName.Text = "Entrez votre nom d'utilisateur";
            LoginName.Width = 250;
            LoginName.Height = 30;
            LoginName.Margin = myThickness;

            myThickness.Top = 8;

            LoginPassWord.Text = "Entrez votre mot de passe";
            LoginPassWord.Width = 250;
            LoginPassWord.Height = 30;
            LoginPassWord.Margin = myThickness;

            //-----------------StackPanel-----------------
            StackLogin.VerticalAlignment = VerticalAlignment.Center;
            StackLogin.HorizontalAlignment = HorizontalAlignment.Center;

            StackLogin.Children.Add(TxtLogin);
            StackLogin.Children.Add(LoginName);
            StackLogin.Children.Add(LoginPassWord);
            StackLogin.Children.Add(Register);

            grdMain.Children.Add(StackLogin);
            grdMain.Children.Add(Enter);
        }


        public void Register_Click(object sender, RoutedEventArgs e)
        {
            pagePrincipale.frame.Content = new Register();
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (LoginName.Text == "")
            {
                MessageBox.Show("Le champ utilisateur est vide");
            }
            else
            {
                if (LoginPassWord.Text == "")
                {
                    MessageBox.Show("Le champ de mot de passe est vide");
                }
                else
                {
                    mysql.SelectInfosAll("SELECT * FROM users WHERE user_name =\"" + LoginName.Text + "\"", out DataSet ds, out int Nbr);
                    if (Nbr == 0)
                    {
                        MessageBox.Show("Utilisateur introuvable");
                    }
                    else
                    {
                        mysql.InfosUser(ds, out int Id, out string Name, out string Password);
                        if (Password == LoginPassWord.Text)
                        {
                            //---------------------------------------Personne---------------------------------------
                            mysql.SelectInfosAll("SELECT * FROM users WHERE user_name =\"" + LoginName.Text + "\"", out ds, out Nbr);
                            mysql.IdPerson(ds, out int id);
                            pagePrincipale.perso = new Class.Personne(id, LoginName.Text, LoginPassWord.Text);

                            //---------------------------------------CompteCourant---------------------------------------
                            mysql.SelectInfosAll("SELECT * FROM compte_courant WHERE compte_user_id=" + id, out ds, out Nbr);
                            pagePrincipale.compteCourant = new Class.CompteCourant[Nbr];
                            for (int i = 0; i < Nbr; i++)
                            {
                                mysql.InfosCompteCourant(ds, i, out string Numero, out double Solde, out double DecouvertMax);
                                pagePrincipale.compteCourant[i] = new Class.CompteCourant(Numero, Solde, DecouvertMax);
                            }

                            //---------------------------------------CompteEpargne---------------------------------------
                            mysql.SelectInfosAll("SELECT * FROM compte_epargne WHERE compte_user_id=" + id, out ds, out Nbr);
                            pagePrincipale.compteEpargne = new Class.CompteEpargne[Nbr];
                            for (int i = 0; i < Nbr; i++)
                            {
                                mysql.InfosCompteEpargne(ds, i, out string Numero, out double Solde, out double TauxInteret);
                                pagePrincipale.compteEpargne[i] = new Class.CompteEpargne(Numero, Solde, TauxInteret);
                            }

                            //---------------------------------------ChangerDePage---------------------------------------
                            pagePrincipale.frame.Content = new Operation();
                        }
                        else
                        {
                            MessageBox.Show("Le mot de passe est incorrect");
                        }
                    }
                }
            }
        }
    }
}