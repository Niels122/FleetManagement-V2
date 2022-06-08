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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_GUI.ReadWindows;
using WPF_GUI.ToevoegenWindows;
using WPF_GUI.UpdateWindows;

namespace WPF_GUI.MainPages
{
    /// <summary>
    /// Interaction logic for VoertuigPagina.xaml
    /// </summary>
    public partial class VoertuigPagina : Page
    {
        private DomeinController _dc;
        public VoertuigPagina(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
            RefreshVoertuigen();
        }

        private void RefreshVoertuigen()
        {
            var bestuurders = _dc.GeefBestuurders();

            List<Voertuig> voertuigen = _dc.GeefVoertuigen();
            foreach (Voertuig voertuig in voertuigen)
            {
                lvOverzichtVoertuigen.Items.Add(voertuig);
                Bestuurder? bstrdr = bestuurders.Where(b => b.VoertuigId == voertuig.VoertuigId).FirstOrDefault();

            }
        }
        private void btnWijzigVoertuig_Click(object sender, RoutedEventArgs e)
        {
            VoertuigUpdateWindow viw = new VoertuigUpdateWindow((Voertuig)lvOverzichtVoertuigen.SelectedItem, _dc);
            viw.Show();
        }

        private void btnVoegVoertuigToe_Click(object sender, RoutedEventArgs e)
        {
            NieuwVoertuigWindow nieuwVoertuig = new(_dc);
            nieuwVoertuig.Show();
        }

        private void btnVerwijderVoertuig_Click(object sender, RoutedEventArgs e)
        {
            //TODO: implementeren
        }

        private void btnToonAlleInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lvOverzichtVoertuigen.SelectedItem != null)
            {
                VoertuigInfoWindow voertuigInfo = new(_dc, (Voertuig)lvOverzichtVoertuigen.SelectedItem);
                voertuigInfo.Show();
            }
            else
            {
                MessageBox.Show("Geen item geslecteerd", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void lvOverzichtVoertuigen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void lvOverzichtBestuurders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VoertuigInfoWindow voertuigInfo = new(_dc, (Voertuig)lvOverzichtVoertuigen.SelectedItem);
            voertuigInfo.Show();
        }
    }
}
