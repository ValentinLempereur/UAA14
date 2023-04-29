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
using GuichetBanquaire.Modele;

namespace GuichetBanquaire.View
{
    /// <summary>
    /// Logique d'interaction pour Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        MainWindow pagePrincipale = (MainWindow)App.Current.MainWindow;

        MysqlRequete mysql = new MysqlRequete();

        StackPanel StackRegister = new StackPanel();

        TextBox RegisterName = new TextBox();
        TextBox RegisterPassWord = new TextBox();
        TextBox RegisterPassWord2 = new TextBox();

        public Register()
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
            Button Login = new Button();
            Button Enter = new Button();

            myThickness.Top = 20;

            Login.Content = "Se connecter";
            Login.Click += new RoutedEventHandler(login_Click);
            Login.Width = 100;
            Login.Height = 30;
            Login.Margin = myThickness;

            myThickness.Top = 350;

            Enter.Content = "Entrer";
            Enter.Click += new RoutedEventHandler(Enter_Click);
            Enter.Width = 120;
            Enter.Height = 40;
            Enter.Margin = myThickness;

            //-----------------Register-----------------
            myThickness.Top = 20;

            TextBlock TxtRegister = new TextBlock();

            myThickness.Left = 170;

            TxtRegister.Text = "Inscrivez-vous";
            TxtRegister.Width = 300;
            TxtRegister.Height = 30;
            TxtRegister.FontWeight = FontWeights.Bold;
            TxtRegister.Margin = myThickness;
            myThickness.Left = 0;

            RegisterName.Text = "Entrez un nom d'utilisateur";
            RegisterName.Width = 300;
            RegisterName.Height = 30;
            RegisterName.Margin = myThickness;

            myThickness.Top = 8;

            RegisterPassWord.Text = "Entrez un mot de passe";
            RegisterPassWord.Width = 300;
            RegisterPassWord.Height = 30;
            RegisterPassWord.Margin = myThickness;

            RegisterPassWord2.Text = "Entrez un nouveau votre mot de passe";
            RegisterPassWord2.Width = 300;
            RegisterPassWord2.Height = 30;
            RegisterPassWord2.Margin = myThickness;

            //-----------------StackPanel-----------------
            StackRegister.VerticalAlignment = VerticalAlignment.Center;
            StackRegister.HorizontalAlignment = HorizontalAlignment.Center;

            StackRegister.Children.Add(TxtRegister);
            StackRegister.Children.Add(RegisterName);
            StackRegister.Children.Add(RegisterPassWord);
            StackRegister.Children.Add(RegisterPassWord2);
            StackRegister.Children.Add(Login);

            grdMain.Children.Add(StackRegister);
            grdMain.Children.Add(Enter);
        }



        public void login_Click(object sender, RoutedEventArgs e)
        {
            pagePrincipale.frame.Content = new Login();
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterName.Text == "")
            {
                MessageBox.Show("Le champ utilisateur est vide");
            }
            else
            {
                if (RegisterPassWord.Text == "" || RegisterPassWord2.Text == "")
                {
                    MessageBox.Show("Le champ de mot de passe est vide");
                }
                else
                {
                    if (RegisterPassWord.Text == RegisterPassWord2.Text)
                    {
                        mysql.SelectInfosAll("SELECT * FROM users WHERE user_name =\"" + RegisterName.Text + "\"", out DataSet ds, out int Nbr);

                        if (Nbr >= 1)
                        {
                            MessageBox.Show("Le nom de l'utilisateur existe déjà");
                        }
                        else
                        {
                            if (mysql.NewUser(RegisterName.Text, RegisterPassWord.Text))
                            {
                                mysql.SelectInfosAll("SELECT * FROM users WHERE user_name =\"" + RegisterName.Text + "\"", out ds, out Nbr);
                                mysql.IdPerson(ds, out int id);
                                pagePrincipale.perso = new Class.Personne(id, RegisterName.Text, RegisterPassWord.Text);

                                pagePrincipale.frame.Content = new Operation();
                            }
                            else
                            {
                                MessageBox.Show("Imposible de s'enregistrer, Vérifier vos données");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Les mots de passe ne sont pas les même");
                    }
                }
            }
        }
    }
}
