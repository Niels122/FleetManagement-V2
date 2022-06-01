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

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for BestuurderPagina.xaml
    /// </summary>
    public partial class BestuurderPagina : Page
    {
        private DomeinController _dc;
        public BestuurderPagina(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
            RefreshBestuurders();
        }
        private void RefreshBestuurders()
        {
            List<Bestuurder> bestuurders = _dc.GeefBestuurders(); 
            foreach (Bestuurder bestuurder in bestuurders)          //over lijst van bestuurders lopen en deze invullen
            {
                lvOverzichtBestuurders.Items.Add(bestuurder);
            }
        }

        private void lvOverzichtBestuurders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnVoegBestuurderToe_Click(object sender, RoutedEventArgs e)
        {
            NieuweBestuurderWindow nieuweBestuurderWindow = new NieuweBestuurderWindow(_dc);
            nieuweBestuurderWindow.Show();
        }

        private void btnVerwijderBestuurder_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
