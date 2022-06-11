using Domein;
using Domein.Enums;
using Domein.Objects;
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
using System.Windows.Shapes;

namespace WPF_GUI.ToevoegenWindows
{
    /// <summary>
    /// Interaction logic for NieuwVoertuigWindow.xaml
    /// </summary>
    public partial class NieuwVoertuigWindow : Window
    {
        private DomeinController _dc;
        public NieuwVoertuigWindow(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
            FillBrandstofType();
            FillWagenType();
            FillKleur();
            FillAantalDeuren();
        }
        private void FillBrandstofType()
        {
            var brandstoftypes = Enum.GetValues(typeof(Brandstoftype)).Cast<Brandstoftype>().ToList().Distinct();
            cmbBrandstoftype.ItemsSource = brandstoftypes;
        }
        private void FillWagenType()
        {
            var wagentypes = Enum.GetValues(typeof(Wagentype)).Cast<Wagentype>().ToList().Distinct();
            cmbWagentype.ItemsSource = wagentypes;
        }
        private void FillKleur()
        {
            string[] kleuren = { "Zwart", "Wit", "Groen", "Blauw", "Geel" };
            cmbKleur.ItemsSource = kleuren;

        }
        private void FillAantalDeuren()
        {
            var aantalDeuren = Enum.GetValues(typeof(Deuren)).Cast<Deuren>().ToList().Distinct();
            cmbAantalDeuren.ItemsSource = aantalDeuren;
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string _Merk = tbMerk.Text;
            string _Model = tbModel.Text;
            string _Chassisnummer = tbChassisnummer.Text;
            string _Nummerplaat = tbNummerplaat.Text;
            Brandstoftype _Brandstoftype = (Brandstoftype)cmbBrandstoftype.SelectedItem;
            Wagentype _Wagentype = (Wagentype)cmbWagentype.SelectedItem;
            string _Kleur = cmbKleur.Text;
            int? _Deuren;

            if (cmbAantalDeuren.SelectedItem != null)
            {
                _Deuren = int.Parse(cmbAantalDeuren.SelectedItem.ToString());
            }
            else
            {
                _Deuren = null;
            }

            Voertuig nieuwVoertuig = new(_Merk, _Model, _Chassisnummer, _Nummerplaat, _Brandstoftype, _Wagentype, _Kleur, _Deuren);

            try
            {
                _dc.CreateVoertuig(nieuwVoertuig);
                MessageBox.Show($"Nieuw voertuig met chassisnummer: {_Chassisnummer} is succesvol toegevoegd.", "Succes", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
