using Domein;
using Domein.Objects;
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

            Array brandstoftypes = Enum.GetValues(typeof(Brandstoftype));
            cmbBrandstoftype.ItemsSource = brandstoftypes;

            Array wagentypes = Enum.GetValues(typeof(Wagentype));
            cmbWagentype.ItemsSource = wagentypes;
        }

        private void RefreshVoertuigen()
        {
            try
            {
                lvOverzichtVoertuigen.Items.Clear();
            

                List<Voertuig> voertuigen = _dc.GeefVoertuigenMetBestuurderId();
                foreach (Voertuig voertuig in voertuigen)
                {
                    lvOverzichtVoertuigen.Items.Add(voertuig);
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er liep iets mis bij het laden van voertuigen: {ex.Message}");
            }
        }
        private void btnWijzigVoertuig_Click(object sender, RoutedEventArgs e)
        {
            if (lvOverzichtVoertuigen.SelectedItem != null)
            {
                VoertuigUpdateWindow viw = new VoertuigUpdateWindow((Voertuig)lvOverzichtVoertuigen.SelectedItem, _dc);
                viw.Show();
            }
            else
            {
                MessageBox.Show("Geen item geslecteerd", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnVoegVoertuigToe_Click(object sender, RoutedEventArgs e)
        {
            NieuwVoertuigWindow nieuwVoertuig = new(_dc);
            nieuwVoertuig.Show();
        }

        private void btnVerwijderVoertuig_Click(object sender, RoutedEventArgs e)
        {
           
             Voertuig voertuig = (Voertuig)lvOverzichtVoertuigen.SelectedItem;
      
            MessageBoxResult result = MessageBox.Show($"Bent u zeker dat u voertuig met chassisnummer: {voertuig.Chassisnummer} wilt verwijderen?", "Verwijder voertuig", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _dc.DeleteVoertuig(voertuig);

                    MessageBox.Show("Voertuig verwijderd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Er liep iets mis bij het verwijderen: {ex.Message}", "Er liep iets mis", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    RefreshVoertuigen();
                }
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Geen items verwijderd.");
            }
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

        private void lvOverzichtVoertuigen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VoertuigInfoWindow voertuigInfo = new(_dc, (Voertuig)lvOverzichtVoertuigen.SelectedItem);
            voertuigInfo.Show();
        }

        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            string merk = tbMerk.Text;
            string model = tbModel.Text;
            string chassisnummer = tbChassisnummer.Text;
            string nummerplaat = tbNummerplaat.Text;
            string brandstoftype = cmbBrandstoftype.Text;
            string wagentype = cmbWagentype.Text;
            string bestuurderid = tbBestuurderId.Text;

            try
            {
                var gefilterdeVoertuigen = _dc.FilterLijstVoertuigV2(merk, model, chassisnummer, nummerplaat, 
                                                            brandstoftype, wagentype, bestuurderid);
                lvOverzichtVoertuigen.Items.Clear();

                foreach(Voertuig voertuig in gefilterdeVoertuigen)
                {
                    lvOverzichtVoertuigen.Items.Add(voertuig);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWisFilters_Click(object sender, RoutedEventArgs e)
        {
            tbMerk.Clear();
            tbModel.Clear();
            tbChassisnummer.Clear();
            tbNummerplaat.Clear();
            cmbBrandstoftype.SelectedIndex = -1;
            cmbWagentype.SelectedIndex = -1;
            tbBestuurderId.Clear();
            
            RefreshVoertuigen();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshVoertuigen();
        }

    }
}
