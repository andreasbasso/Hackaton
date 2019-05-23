﻿using System;
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

namespace Hackaton
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = listing;
        }

        //Listes des Combos Box
        private List<string> Region = new List<string>() { "Bandle", "Bilgewater", "Demacia", "Freljord", "Ionia", "Mont Targon", "Noxus", "Néant", "Piltover", "Shurima", "Zaun", "Iles Obscures", "Runeterra" };
        private List<string> Classe = new List<string>() { "Tank", "Combattant", "Tueur", "Mage", "Controleur", "Tireur" };
        private List<string> Tank = new List<string>() { "Initiateur", "Gardien" };
        private List<string> Combattant = new List<string>() { "Colosse", "Blitzer" };
        private List<string> Tueur = new List<string>() { "Assassin", "Escarmoucheur" };
        private List<string> Mage = new List<string>() { "à Burst", "de Combat", "Artilleur" };
        private List<string> Controleur = new List<string>() { "Enchanteur", "Piégeur" };
        private List<string> Tireur = new List<string>() { "Tireur" };

        ObservableCollection<Champion> listing = new ObservableCollection<Champion>();
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        string nomdefichier = "/database.txt";

        private void Btn_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            FormulaireAjoutEdition fenetre2 = new FormulaireAjoutEdition();
            if (fenetre2.ShowDialog() == true) //on confirme l'opération
            {
                listing.Add(fenetre2.RecupDonneesSaisies());
                fenetre2.Close();
            }
            else //on annule l'opération
            {
                MessageBox.Show("Opération annulée");
            }
            fenetre2.Close();
        }
        private void Btn_Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (Dtg_datagrid01.SelectedItems.Count == 1)
            {
                Champion tmp = Dtg_datagrid01.Items[Dtg_datagrid01.SelectedIndex] as Champion;
                FormulaireAjoutEdition fenetre2 = new FormulaireAjoutEdition(tmp);

                if (fenetre2.ShowDialog() == true) //on confirme l'opération de modification
                {
                    listing.Remove(tmp);
                    listing.Add(fenetre2.RecupDonneesSaisies());
                }
                else //on annule l'opération de modification
                {
                    MessageBox.Show("Opération annulée");
                }
                fenetre2.Close();
            }
        }
        private void Btn_Suppprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Dtg_datagrid01.SelectedItems.Count == 1)
            {
                Champion tmp = Dtg_datagrid01.Items[Dtg_datagrid01.SelectedIndex] as Champion;
                listing.Remove(tmp);
            }
            else
            {
                MessageBox.Show("Selection vide ou trop nombreuse (max 1 à la fois)");
            }
        }


        private void Btn_Lecture_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_Sauvergarder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
