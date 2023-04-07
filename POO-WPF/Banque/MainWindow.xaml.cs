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

namespace Banque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {
            this.Background = Brushes.Bisque;

            StackPanel StackLogin = new StackPanel();
            StackPanel StackRegister = new StackPanel();

            Button Login = new Button();
            Button Register = new Button();
            Button Enter = new Button();

            Login.Click += new RoutedEventHandler(login_Click);
            Register.Click += new RoutedEventHandler(Register_Click);
            Enter.Click += new RoutedEventHandler(Enter_Click);

            TextBlock TxtLogin = new TextBlock();
            TextBox Loginname = new TextBox();
            TextBox LoginPassWord = new TextBox();

            TxtLogin.Text = "Connectez-vous";
            Loginname.Text = "entrez votre nom d'utilisateur";
            LoginPassWord.Text = "Entrez votre mot de passe";

            TextBlock TxtRegister = new TextBlock();
            TextBox RegisterName = new TextBox();
            TextBox RegisterPassWord = new TextBox();
            TextBox RegisterPassWord2 = new TextBox();

            TxtRegister.Text = "Inscrivez-vous";
            RegisterName.Text = "Entrez un nom d'utilisateur";
            RegisterPassWord.Text = "Entrez un mot de passe";
            RegisterPassWord2.Text = "Entrez un nouveau votre mot de passe";

            StackLogin.Children.Add(TxtLogin);
            StackLogin.Children.Add(Loginname);
            StackLogin.Children.Add(Register);
            StackLogin.Children.Add(Enter);

            StackRegister.Children.Add(TxtRegister);
            StackRegister.Children.Add(RegisterName);
            StackRegister.Children.Add(RegisterPassWord);
            StackRegister.Children.Add(RegisterPassWord2);
            StackRegister.Children.Add(Enter);

            StackRegister.Visibility = Visibility.Visible;

            grdMain.Children.Add(StackLogin);
            grdMain.Children.Add(StackRegister);
        }

        public void login_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public void Register_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
