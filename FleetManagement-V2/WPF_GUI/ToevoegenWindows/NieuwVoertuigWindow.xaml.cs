using Domein;
using Domein.Enums;
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

        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
