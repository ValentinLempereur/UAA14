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
using Banque.Class;

namespace Banque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MysqlRequete mysql = new MysqlRequete();

        StackPanel StackLogin = new StackPanel();
        StackPanel StackRegister = new StackPanel();

        TextBox LoginName = new TextBox();
        TextBox LoginPassWord = new TextBox();

        TextBox RegisterName = new TextBox();
        TextBox RegisterPassWord = new TextBox();
        TextBox RegisterPassWord2 = new TextBox();
        public MainWindow()
        {
            InitializeComponent();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {
            //-----------------This-----------------
            this.Background = Brushes.Tomato;
            this.FontSize = 16;

            //-----------------Margin-----------------
            Thickness myThickness = new Thickness();
            

            //-----------------Bouton-----------------
            Button Login = new Button();
            Button Register = new Button();
            Button Enter = new Button();

            myThickness.Top = 20;

            Login.Content = "Se connecter";
            Login.Click += new RoutedEventHandler(login_Click);
            Login.Width = 100;
            Login.Height = 30;
            Login.Margin = myThickness;

            Register.Content = "S'en registrer";
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

            LoginName.Text = "entrez votre nom d'utilisateur";
            LoginName.Width = 250;
            LoginName.Height = 30;
            LoginName.Margin = myThickness;

            myThickness.Top = 8;

            LoginPassWord.Text = "Entrez votre mot de passe";
            LoginPassWord.Width = 250;
            LoginPassWord.Height = 30;
            LoginPassWord.Margin = myThickness;

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
            StackLogin.VerticalAlignment = VerticalAlignment.Center;
            StackLogin.HorizontalAlignment = HorizontalAlignment.Center;

            StackRegister.VerticalAlignment = VerticalAlignment.Center;
            StackRegister.HorizontalAlignment = HorizontalAlignment.Center;

            StackLogin.Children.Add(TxtLogin);
            StackLogin.Children.Add(LoginName);
            StackLogin.Children.Add(LoginPassWord);
            StackLogin.Children.Add(Register);

            StackRegister.Children.Add(TxtRegister);
            StackRegister.Children.Add(RegisterName);
            StackRegister.Children.Add(RegisterPassWord);
            StackRegister.Children.Add(RegisterPassWord2);
            StackRegister.Children.Add(Login);

            StackRegister.Visibility = Visibility.Hidden;

            //-----------------grdMain-----------------
            grdMain.Children.Add(StackLogin);
            grdMain.Children.Add(StackRegister);
            grdMain.Children.Add(Enter);
        }

        public void login_Click(object sender, RoutedEventArgs e)
        {
            StackLogin.Visibility = Visibility.Visible;
            StackRegister.Visibility = Visibility.Hidden;

            LoginName.Text = "entrez votre nom d'utilisateur";
            LoginPassWord.Text = "Entrez votre mot de passe";
        }


        public void Register_Click(object sender, RoutedEventArgs e)
        {
            StackLogin.Visibility = Visibility.Hidden;
            StackRegister.Visibility = Visibility.Visible;
            
            RegisterName.Text = "Entrez un nom d'utilisateur";
            RegisterPassWord.Text = "Entrez un mot de passe";
            RegisterPassWord2.Text = "Entrez un nouveau votre mot de passe";
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (StackLogin.Visibility == Visibility.Visible)
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
                        if(Nbr == 0)
                        {
                            MessageBox.Show("Utilisateur introuvable");
                        }
                        else
                        {
                            mysql.InfosUser(ds, out int Id, out string Name, out string Password);
                            if (Password == LoginPassWord.Text)
                            {
                                //changer de page
                            }
                            else
                            {
                                MessageBox.Show("Le mot de passe est incorrect");
                            }
                        }
                    }
                }
            }
            else
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
                                if(mysql.NewUser(RegisterName.Text, RegisterPassWord.Text))
                                {
                                    //changer de page
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
}
