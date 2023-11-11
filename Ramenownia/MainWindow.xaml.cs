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

namespace Ramenownia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        RadioButton danie = new RadioButton();
        RadioButton rozmiar = new RadioButton();
        RadioButton spicy = new RadioButton();
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Output.Clear();
            info.Foreground = Brushes.Green;
            info.Text = "Pomyślnie wyczyszczono!";
            jajka.IsChecked = false;
            shitake.IsChecked = false;
            kimchi.IsChecked = false;
            tofu.IsChecked = false;
            kukurydza.IsChecked = false;
            wakame.IsChecked = false;
            Danie_default.IsChecked = true;
            Rozmiar_default.IsChecked = true;
            Spicy_default.IsChecked = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool dodatek = false;
                string Dane = dane.Text;
                int cena = 0;
                string Danie = danie.Content.ToString();
                string[] pom_rozmiar = rozmiar.Content.ToString().Split(" ");
                string Rozmiar = pom_rozmiar[0];
                string[] pom_ostrosc = spicy.Content.ToString().Split("-");
                string ostrosc = pom_ostrosc[1];
                string koncowy = Dane + "\n***\n" + Rozmiar + " " + ostrosc + " " + Danie + "\nDODATKI\n";
                switch (Rozmiar)
                {
                    case "Mały":
                        cena += 20;
                        break;
                    case "Średni":
                        cena += 30;
                        break;
                    case "Duży":
                        cena += 40;
                        break;
                    case "Gigant":
                        cena += 50;
                        break;
                }
                if (jajka.IsChecked == true)
                {
                    dodatek = true;
                    cena += 3 * (int.Parse(jajka_ilosc.Text));
                    koncowy += jajka_ilosc.Text + " x " + jajka.Content.ToString() + "\n";
                }
                if (shitake.IsChecked == true)
                {
                    dodatek = true;
                    cena += 6 * (int.Parse(shitake_ilosc.Text));
                    koncowy += shitake_ilosc.Text + " x " + shitake.Content.ToString() + "\n";
                }
                if (kimchi.IsChecked == true)
                {
                    dodatek = true;
                    cena += 8 * (int.Parse(kimchi_ilosc.Text));
                    koncowy += kimchi_ilosc.Text + " x " + kimchi.Content.ToString() + "\n";
                }
                if (tofu.IsChecked == true)
                {
                    dodatek = true;
                    cena += 6 * (int.Parse(tofu_ilosc.Text));
                    koncowy += tofu_ilosc.Text + " x " + tofu.Content.ToString() + "\n";
                }
                if (kukurydza.IsChecked == true)
                {
                    dodatek = true;
                    cena += 4 * (int.Parse(kukurydza_ilosc.Text));
                    koncowy += kukurydza_ilosc.Text + " x " + kukurydza.Content.ToString() + "\n";
                }
                if (wakame.IsChecked == true)
                {
                    dodatek = true;
                    cena += 4 * (int.Parse(wakame_ilosc.Text));
                    koncowy += wakame_ilosc.Text + " x " + wakame.Content.ToString() + "\n";
                }
                if(!dodatek)
                {
                    koncowy += "BRAK\n\n";
                }
                koncowy += "RAZEM DO ZAPLATY " + cena;
                Output.Text = koncowy;
            }
            catch(Exception ex)
            {
                info.Foreground = Brushes.Red;
                info.Text = ex.Message;
            }


        }

        private void danie_Checked(object sender, RoutedEventArgs e)
        {
            danie = (sender as RadioButton);            
        }
        private void rozmiar_Checked(object sender, RoutedEventArgs e)
        {
            rozmiar = (sender as RadioButton);
        }

        private void spicy_Checked(object sender, RoutedEventArgs e)
        {
            spicy = (sender as RadioButton);
        }



        private void jajka_Unchecked(object sender, RoutedEventArgs e)
        {
            jajka_vis.Visibility = Visibility.Hidden;
        }

        private void jajka_Checked(object sender, RoutedEventArgs e)
        {
            jajka_vis.Visibility=Visibility.Visible;
        }

        private void shitake_Checked(object sender, RoutedEventArgs e)
        {
            shitake_vis.Visibility = Visibility.Visible;
        }
        private void shitake_Unchecked(object sender, RoutedEventArgs e)
        {
            shitake_vis.Visibility = Visibility.Hidden;
        }

        private void kimchi_Checked(object sender, RoutedEventArgs e)
        {
            kimchi_vis.Visibility = Visibility.Visible;
        }
        private void kimchi_Unchecked(object sender, RoutedEventArgs e)
        {
            kimchi_vis.Visibility = Visibility.Hidden;
        }

        private void tofu_Checked(object sender, RoutedEventArgs e)
        {
            tofu_vis.Visibility = Visibility.Visible;
        }
        private void tofu_Unchecked(object sender, RoutedEventArgs e)
        {
            tofu_vis.Visibility = Visibility.Hidden;
        }

        private void kukurydza_Checked(object sender, RoutedEventArgs e)
        {
            kukurydza_vis.Visibility = Visibility.Visible;
        }
        private void kukurydza_Unchecked(object sender, RoutedEventArgs e)
        {
            kukurydza_vis.Visibility = Visibility.Hidden;
        }

        private void wakame_Checked(object sender, RoutedEventArgs e)
        {
            wakame_vis.Visibility = Visibility.Visible;
        }
        private void wakame_Unchecked(object sender, RoutedEventArgs e)
        {
            wakame_vis.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Nie wiedzialem czy tylko o to chodzi jako "Kontrola wpisania nazwiska"
            if(dane.Text != string.Empty)
            {
                Add.IsEnabled = true;
            }
            else
            {
                Add.IsEnabled = false;
            }
        }
    }
}
