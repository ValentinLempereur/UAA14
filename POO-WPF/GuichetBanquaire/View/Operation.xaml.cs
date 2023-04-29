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
using System.Xml.Linq;
using GuichetBanquaire.Modele;
using System.Data;
using System.Diagnostics.Contracts;

namespace GuichetBanquaire.View
{
    /// <summary>
    /// Logique d'interaction pour Operation.xaml
    /// </summary>
    public partial class Operation : Page
    {
        MainWindow pagePrincipale = (MainWindow)App.Current.MainWindow;
        MysqlRequete mysql = new MysqlRequete();
        ListBox ListCompteDonneur = new ListBox();
        ListBox ListCompteReceveur = new ListBox();
        TextBox TxtSolde = new TextBox();
        TextBox TxtMontant = new TextBox();

        public Operation()
        {
            InitializeComponent();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {
            this.Background = Brushes.BurlyWood;
            this.FontSize = 30;

            //-------------Stackpanel-------------
            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Right;
            StackPanel stack1 = new StackPanel();

            //-------------Dockpanel-------------
            DockPanel dock = new DockPanel();
            DockPanel dock1 = new DockPanel();
            DockPanel dock2 = new DockPanel();
            DockPanel dock3 = new DockPanel();

            //-------------Margin-------------
            Thickness margin = new Thickness();

            margin.Top = 20;

            //-------------Button-------------
            Button profil = new Button();
            Button deconnexion = new Button();
            Button executer = new Button();

            profil.Content = "profil";
            profil.Width = 250;
            profil.Height = 90;
            profil.Click += new RoutedEventHandler(profil_Click);
            profil.FontWeight = FontWeights.Bold;
            profil.Background = Brushes.LawnGreen;

            deconnexion.Content = "deconnexion";
            deconnexion.Width = 250;
            deconnexion.Height = 90;
            deconnexion.Click += new RoutedEventHandler(deconnexion_Click);
            deconnexion.FontWeight = FontWeights.Bold;
            deconnexion.Background = Brushes.OrangeRed;

            executer.Content = "EXUCUTER";
            executer.Click += new RoutedEventHandler(executer_Click);
            executer.FontWeight = FontWeights.Bold;
            executer.VerticalAlignment = VerticalAlignment.Top;
            executer.Height = 60;
            executer.Margin = margin;

            margin.Left = 0;
            margin.Top = 0;

            //-------------GroupBox-------------
            GroupBox operation = new GroupBox();
            GroupBox virement = new GroupBox();

            operation.Header = "Opération";

            virement.Header = "Virement";

            //-------------solde-------------
            TextBlock TxtBSolde = new TextBlock();

            TxtBSolde.Text = "Solde :";
            TxtBSolde.Height = 50;
            TxtBSolde.Width = 300;
            TxtBSolde.FontWeight = FontWeights.Bold;
            TxtBSolde.Margin = margin;

            margin.Right = 500;

            TxtSolde.IsEnabled = false;
            TxtSolde.Height = 50;
            TxtSolde.Width = 400;
            TxtSolde.HorizontalAlignment = HorizontalAlignment.Right;
            TxtSolde.Margin = margin;

            margin.Top = 50;
            margin.Right = 0;

            //-------------CompteD-------------
            TextBlock TxtBCompteDonneur = new TextBlock();

            TxtBCompteDonneur.Text = "Numéro de compte donneur d'ordre :";
            TxtBCompteDonneur.Height = 50;
            TxtBCompteDonneur.Width = 540;
            TxtBCompteDonneur.FontWeight = FontWeights.Bold;
            TxtBCompteDonneur.Margin = margin;

            margin.Right = 500;

            ListCompteDonneur.Height = 50;
            ListCompteDonneur.Width = 400;
            ListCompteDonneur.HorizontalAlignment = HorizontalAlignment.Right;
            ListCompteDonneur.Margin = margin;
            ListCompteDonneur.SelectionChanged += new SelectionChangedEventHandler(Changed_list);

            margin.Right = 0;

            //-------------CompteR-------------
            TextBlock TxtBCompteReceveur = new TextBlock();

            TxtBCompteReceveur.Text = "Numéro de compte du receveur :";
            TxtBCompteReceveur.Height = 50;
            TxtBCompteReceveur.Width = 500;
            TxtBCompteReceveur.FontWeight = FontWeights.Bold;
            TxtBCompteReceveur.Margin = margin;

            margin.Right = 500;

            ListCompteReceveur.Height = 50;
            ListCompteReceveur.Width = 400;
            ListCompteReceveur.HorizontalAlignment = HorizontalAlignment.Right;
            ListCompteReceveur.Margin = margin;

            margin.Right = 0;

            //-------------Montant-------------
            TextBlock TxtBMontant = new TextBlock();

            TxtBMontant.Text = "Montant : ";
            TxtBMontant.Height = 50;
            TxtBMontant.Width = 500;
            TxtBMontant.FontWeight = FontWeights.Bold;
            TxtBMontant.Margin = margin;

            margin.Right = 500;

            TxtMontant.Height = 50;
            TxtMontant.Width = 400;
            TxtMontant.HorizontalAlignment = HorizontalAlignment.Right;
            TxtMontant.Margin = margin;

            //-------------Affection-------------
            Grid.SetRow(executer, 3);

            stack.Children.Add(profil);
            stack.Children.Add(deconnexion);
            Grid.SetRow(stack, 0);

            dock.Children.Add(TxtBSolde);
            dock.Children.Add(TxtSolde);

            dock1.Children.Add(TxtBCompteDonneur);
            dock1.Children.Add(ListCompteDonneur);

            dock2.Children.Add(TxtBCompteReceveur);
            dock2.Children.Add(ListCompteReceveur);

            dock3.Children.Add(TxtBMontant);
            dock3.Children.Add(TxtMontant);

            stack1.Children.Add(dock1);
            stack1.Children.Add(dock2);
            stack1.Children.Add(dock3);

            operation.Content = dock;
            Grid.SetRow(operation, 1);

            virement.Content = stack1;
            Grid.SetRow(virement, 2);

            grdMain.Children.Add(executer);
            grdMain.Children.Add(stack);
            grdMain.Children.Add(operation);
            grdMain.Children.Add(virement);

            //-------------RemplissageListe-------------
            ListCompteDonneur.Items.Add("----Compte Courant----");
            for (int i = 0; i < pagePrincipale.compteCourant.Length; i++)
            {
                ListCompteDonneur.Items.Add(pagePrincipale.compteCourant[i].NumeroBanquaire);
            }
            ListCompteDonneur.Items.Add("----Compte Epargne----");
            for (int i = 0; i < pagePrincipale.compteEpargne.Length; i++)
            {
                ListCompteDonneur.Items.Add(pagePrincipale.compteEpargne[i].NumeroBanquaire);
            }

            ListCompteReceveur.Items.Add("----Compte Courant----");
            mysql.SelectCompte("SELECT * from compte_courant", out DataTable ds, out int Nbr);
            for (int i = 0; i < Nbr; i++)
            {
                mysql.AfficheCompte(ds, i, out string Numero);
                ListCompteReceveur.Items.Add(Numero);
            }
            ListCompteReceveur.Items.Add("----Compte Epargne----");
            mysql.SelectCompte("SELECT * from compte_epargne", out ds, out Nbr);
            for (int i = 0; i < Nbr; i++)
            {
                mysql.AfficheCompte(ds, i, out string Numero);
                ListCompteReceveur.Items.Add(Numero);
            }

        }

        public void profil_Click(object sender, RoutedEventArgs e)
        {
            pagePrincipale.frame.Content = new Profil();
        }

        public void deconnexion_Click(object sender, RoutedEventArgs e)
        {
            pagePrincipale.frame.Content = new Login();
        }
        
        public void executer_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;

            if (ListCompteDonneur.SelectedItem.ToString().Substring(0, 4) == "BE64")
            {
                for (int i = 0; i < pagePrincipale.compteCourant.Length; i++)
                {
                    if (ListCompteDonneur.SelectedItem.ToString() == pagePrincipale.compteCourant[i].NumeroBanquaire)
                    {
                        if (pagePrincipale.compteCourant[i].Virement(Double.Parse(TxtMontant.Text)))
                        {
                            mysql.ModifySolde("compte_courant", pagePrincipale.compteCourant[i].NumeroBanquaire, pagePrincipale.compteCourant[i].Solde);

                            for (int x = 0; x < pagePrincipale.compteCourant.Length; x++)
                            {
                                if (ListCompteReceveur.SelectedItem.ToString() == pagePrincipale.compteCourant[x].NumeroBanquaire)
                                {
                                    pagePrincipale.compteCourant[x].Solde += Double.Parse(TxtMontant.Text);
                                    mysql.ModifySolde("compte_courant", pagePrincipale.compteCourant[x].NumeroBanquaire, pagePrincipale.compteCourant[x].Solde);
                                    ok = false;
                                    MessageBox.Show("Virement éffectué");
                                }
                            }

                            for (int x = 0; x < pagePrincipale.compteEpargne.Length; x++)
                            {
                                if (ListCompteReceveur.SelectedItem.ToString() == pagePrincipale.compteEpargne[x].NumeroBanquaire)
                                {
                                    pagePrincipale.compteEpargne[x].Solde += Double.Parse(TxtMontant.Text);
                                    mysql.ModifySolde("compte_epargne", pagePrincipale.compteEpargne[x].NumeroBanquaire, pagePrincipale.compteEpargne[x].Solde);
                                    ok = false;
                                    MessageBox.Show("Virement éffectué");
                                }
                            }

                            if (ok == true && ListCompteReceveur.SelectedItem.ToString().Substring(0, 4) == "BE64")
                            {
                                mysql.SelectInfosAll("SELECT * FROM compte_courant WHERE numero =\"" + ListCompteReceveur.SelectedItem.ToString() + "\"", out DataSet ds, out int nbr);
                                mysql.AfficheSolde(ds, out double solde);
                                mysql.ModifySolde("compte_courant", ListCompteReceveur.SelectedItem.ToString(), solde + Double.Parse(TxtMontant.Text));
                                ok = false;
                                MessageBox.Show("Virement éffectué");
                            }
                            else if (ok == true && ListCompteReceveur.SelectedItem.ToString().Substring(0, 4) == "BE54")
                            {
                                mysql.SelectInfosAll("SELECT * FROM compte_epargne WHERE numero =\"" + ListCompteReceveur.SelectedItem.ToString() + "\"", out DataSet ds, out int nbr);
                                mysql.AfficheSolde(ds, out double solde);
                                mysql.ModifySolde("compte_epargne", ListCompteReceveur.SelectedItem.ToString(), solde + Double.Parse(TxtMontant.Text));
                                ok = false;
                                MessageBox.Show("Virement éffectué");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas assezd'argent");
                        }
                    }
                }
            }

            else if(ListCompteDonneur.SelectedItem.ToString().Substring(0, 4) == "BE54")
            {
                for (int i = 0; i < pagePrincipale.compteEpargne.Length; i++)
                {
                    if (ListCompteDonneur.SelectedItem.ToString() == pagePrincipale.compteEpargne[i].NumeroBanquaire)
                    {
                        if(pagePrincipale.compteEpargne[i].Virement(Double.Parse(TxtMontant.Text)))
                        {
                            for (int x = 0; x < pagePrincipale.compteCourant.Length; x++)
                            {
                                mysql.ModifySolde("compte_epargne", pagePrincipale.compteEpargne[i].NumeroBanquaire, pagePrincipale.compteEpargne[i].Solde);
                                if (ListCompteReceveur.SelectedItem.ToString() == pagePrincipale.compteCourant[x].NumeroBanquaire)
                                {
                                    pagePrincipale.compteCourant[x].Solde += Double.Parse(TxtMontant.Text);
                                    mysql.ModifySolde("compte_courant", pagePrincipale.compteCourant[x].NumeroBanquaire, pagePrincipale.compteCourant[i].Solde);
                                    ok = false;
                                    MessageBox.Show("Virement éffectué");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas assez d'argent");
                            ok = false;
                        }
                        
                    }
                }

                if (ok == true)
                {
                    MessageBox.Show("Le compte épargne ne peut verser seulement sur un de vos comptes courants");
                }
            }

            ok = true;
            tanx_interet();
        }

        public void Changed_list(object sender, SelectionChangedEventArgs e)
        {
            for(int i = 0; i < pagePrincipale.compteCourant.Length; i++) 
            {
                if(ListCompteDonneur.SelectedItem.ToString() == pagePrincipale.compteCourant[i].NumeroBanquaire) 
                {
                    TxtSolde.Text = pagePrincipale.compteCourant[i].Solde.ToString();
                }
            }

            for (int i = 0; i < pagePrincipale.compteEpargne.Length; i++)
            {
                if (ListCompteDonneur.SelectedItem.ToString() == pagePrincipale.compteEpargne[i].NumeroBanquaire)
                {
                    TxtSolde.Text = pagePrincipale.compteEpargne[i].Solde.ToString();
                }
            }
        }

        public void tanx_interet()
        {
            for (int i = 0; i < pagePrincipale.compteEpargne.Length; i++)
            {
                pagePrincipale.compteEpargne[i].tanxInteret();
            }
        }
    }
}
