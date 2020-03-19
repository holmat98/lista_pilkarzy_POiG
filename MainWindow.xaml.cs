using System;
using System.Collections.Generic;
using System.IO;
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

namespace app_lab2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private List<int> wiek = new List<int>();
        private List<Pilkarz> lista_pilkarzy = new List<Pilkarz>();
        public MainWindow()
        {
            InitializeComponent();
            for(int i=18; i<=40; i++)
            {
                wiek.Add(i);
            }

            if(File.Exists("dane.txt"))
            {
                string[] lines = File.ReadAllLines("dane.txt");
                for(int i=0; i<lines.Length; i++)
                {
                    string[] dane_wejsciowe = lines[i].Trim().Split(' ');
                    Pilkarz nowy_pilkarz = new Pilkarz(dane_wejsciowe[0], dane_wejsciowe[1], Convert.ToInt32(dane_wejsciowe[2]), Convert.ToDouble(dane_wejsciowe[3]));
                    lista_pilkarzy.Add(nowy_pilkarz);
                }
            }

            Wiek_cbx.ItemsSource = wiek;
            Wiek_cbx.Items.Refresh();

            Pilkarze_lbx.ItemsSource = lista_pilkarzy;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
    
            string waga_wartosc = Waga_S.Value.ToString();
            if (WartoscWaga_tb != null)
                WartoscWaga_tb.Text = Math.Round(((Slider)sender).Value,1).ToString();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if(imie_tbx.Text == "")
            {
                imie_tbx.BorderBrush = Brushes.Red;
                imie_tbx.BorderThickness.Equals(1);
            }
            else
            {
                imie_tbx.BorderThickness.Equals(0);
                imie_tbx.BorderBrush = Brushes.Silver;
                if(nazwisko_tbx.Text == "")
                {
                    nazwisko_tbx.BorderBrush = Brushes.Red;
                    nazwisko_tbx.BorderThickness.Equals(1);
                }
                else
                {
                    nazwisko_tbx.BorderBrush = Brushes.Silver;
                    nazwisko_tbx.BorderThickness.Equals(0);
                    if(Wiek_cbx.SelectedIndex == -1)
                    {
                        MessageBox.Show("Nie wybrałeś wieku");
                    }
                    else
                    {
                        string imie = imie_tbx.Text;
                        string nazwisko = nazwisko_tbx.Text;
                        int wiek = Convert.ToInt32(Wiek_cbx.SelectedItem.ToString());
                        double waga = Math.Round(Waga_S.Value, 1);

                        Pilkarz nowy = new Pilkarz(imie, nazwisko, wiek, waga);
                        lista_pilkarzy.Add(nowy);

                        Pilkarze_lbx.Items.Refresh();
                    }
                }
            }
            imie_tbx.Text = "";
            nazwisko_tbx.Text = "";
            Wiek_cbx.SelectedIndex = -1;
            Waga_S.Value = Waga_S.Minimum;
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int do_usuniecia = Pilkarze_lbx.SelectedIndex;
                lista_pilkarzy.Remove(lista_pilkarzy[do_usuniecia]);
                Pilkarze_lbx.Items.Refresh();
                imie_tbx.Text = "";
                nazwisko_tbx.Text = "";
                Wiek_cbx.SelectedIndex = -1;
                Waga_S.Value = Waga_S.Minimum;
            }
            catch
            {
            }
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int aktualny = Pilkarze_lbx.SelectedIndex;
                if (imie_tbx.Text == "")
                {
                    imie_tbx.BorderBrush = Brushes.Red;
                    imie_tbx.BorderThickness.Equals(1);
                }
                else
                {
                    imie_tbx.BorderThickness.Equals(0);
                    imie_tbx.BorderBrush = Brushes.Silver;
                    if (nazwisko_tbx.Text == "")
                    {
                        nazwisko_tbx.BorderBrush = Brushes.Red;
                        nazwisko_tbx.BorderThickness.Equals(1);
                    }
                    else
                    {
                        nazwisko_tbx.BorderBrush = Brushes.Silver;
                        nazwisko_tbx.BorderThickness.Equals(0);
                        if (Wiek_cbx.SelectedIndex == -1)
                        {
                            MessageBox.Show("Nie wybrałeś wieku");
                        }
                        else
                        {
                            lista_pilkarzy[aktualny].Imie = imie_tbx.Text;
                            lista_pilkarzy[aktualny].Nazwisko = nazwisko_tbx.Text;
                            lista_pilkarzy[aktualny].Wiek = Convert.ToInt32(Wiek_cbx.SelectedItem);
                            lista_pilkarzy[aktualny].Waga = Waga_S.Value;

                            Pilkarze_lbx.Items.Refresh();
                            Pilkarze_lbx.SelectedIndex = 0;
                        }
                    }
                }
                imie_tbx.Text = "";
                nazwisko_tbx.Text = "";
                Wiek_cbx.SelectedIndex = -1;
                Waga_S.Value = Waga_S.Minimum;
            }
            catch
            {

            }
            
        }
        private void Pilkarze_lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int aktualny = Pilkarze_lbx.SelectedIndex;
            imie_tbx.Text = lista_pilkarzy[aktualny].Imie;
            nazwisko_tbx.Text = lista_pilkarzy[aktualny].Nazwisko;
            Wiek_cbx.SelectedItem = lista_pilkarzy[aktualny].Wiek;
            Waga_S.Value = lista_pilkarzy[aktualny].Waga;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (File.Exists("dane.txt"))
                File.Delete("dane.txt");
            if (lista_pilkarzy.Count != 0)
            {
                for (int i = 0; i < lista_pilkarzy.Count; i++)
                {
                    string imie = lista_pilkarzy[i].Imie;
                    string nazwisko = lista_pilkarzy[i].Nazwisko;
                    int wiek = lista_pilkarzy[i].Wiek;
                    double waga = lista_pilkarzy[i].Waga;

                    StringBuilder dane = new StringBuilder();
                    dane.Append(imie);
                    dane.Append(" ");
                    dane.Append(nazwisko);
                    dane.Append(" ");
                    dane.Append(wiek);
                    dane.Append(" ");
                    dane.Append(waga);

                    FileStream plik = new FileStream("dane.txt", FileMode.Append);
                    StreamWriter dopisanie = new StreamWriter(plik);
                    dopisanie.WriteLine(dane.ToString());
                    dopisanie.Close();
                    plik.Close();
                }
            }
        }
    }
}
