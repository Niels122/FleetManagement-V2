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

namespace WPF_GUI.ReadWindows
{
    /// <summary>
    /// Interaction logic for VoertuigInfoWindow.xaml
    /// </summary>
    public partial class VoertuigInfoWindow : Window
    {
        private DomeinController _dc;
        public VoertuigInfoWindow(DomeinController dc, Voertuig voertuig)
        {
            _dc = dc;
            InitializeComponent();

        
            var bestuurders = _dc.GeefBestuurders();
            Bestuurder? bstrdr = bestuurders.Where(b => b.ChassisnummerVoertuig == voertuig.Chassisnummer).FirstOrDefault();

           
            merk.Text = voertuig.Merk;
            model.Text = voertuig.Model;
            chassisnummer.Text = voertuig.Chassisnummer;
            nummerplaat.Text = voertuig.Nummerplaat;
            brandstofType.Text = voertuig.Brandstoftype.ToString();
            wagenType.Text = voertuig.Wagentype.ToString();
            kleur.Text = voertuig.Kleur;
            aantalDeuren.Text = voertuig.AantalDeuren.ToString();
            bestuurder.Text = $"ID: {bstrdr?.BestuurderId} Naam: {bstrdr?.Voornaam} {bstrdr?.Naam}";

        }
    }
}
