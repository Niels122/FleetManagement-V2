using Domein;
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

namespace WPF_GUI.UpdateWindows
{
    /// <summary>
    /// Interaction logic for VoertuigUpdateWindow.xaml
    /// </summary>
    public partial class VoertuigUpdateWindow : Window
    {
        private DomeinController _dc;
        private Voertuig _voertuig;
        private Bestuurder _bestuurder;
        public VoertuigUpdateWindow(Voertuig voertuig, DomeinController dc)
        {
            InitializeComponent();

            _dc = dc;
            this._voertuig = voertuig;

            chassisnummer.Text = voertuig.Chassisnummer;
            nummerplaat.Text = voertuig.Nummerplaat;
            merk.Text = voertuig.Merk;
            model.Text = voertuig.Model;
            merk.Text = voertuig.Merk;
            typeWagen.Text = voertuig.Wagentype.ToString();
            deuren.Text = voertuig.AantalDeuren.ToString();
            kleur.Text = voertuig.Kleur;
            //bestuurder.Text = Bestuurder
        }
        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            UpdateVoertuig();
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateVoertuig()
        {

        }
    }
}
