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
            InitializeComponent();

            _dc = dc;
        }

        private void btnWijzigVoertuig_Click(object sender, RoutedEventArgs e)
        {
            VoertuigUpdateWindow viw = new VoertuigUpdateWindow((Voertuig)lvOverzichtVoertuigen.SelectedItem, _dc);
            viw.Show();
        }

        private void btnVoegVoertuigToe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVerwijderVoertuig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnToonAlleInfo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void lvOverzichtVoertuigen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
