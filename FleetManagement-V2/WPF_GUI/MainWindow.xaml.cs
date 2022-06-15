using Domein;
using Domein.Controllers;
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
using WPF_GUI.MainPages;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        private string _actievePagina;
        private DomeinController _dc;
        public MainWindow(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();

            ZetActief("dbVullerPagina");

        }
        private void ZetActief(string pagina)
        {
            _actievePagina = pagina;
           
            switch(_actievePagina)
            {
                case "bestuurderPagina":
                    MainWnd.Content = new BestuurderPagina(_dc);
                    break;
                case "voertuigPagina":
                    MainWnd.Content = new VoertuigPagina(_dc);
                    break;

                case "tankkaartPagina":
                    MainWnd.Content = new TankkaartPagina(_dc);
                    break;
                case "dbVullerPagina":
                    MainWnd.Content = new DatabaseVullerPagina(_dc);
                    break;
            }    
        }

        private void btnBestuurders_Click(object sender, RoutedEventArgs e)
        {
            ZetActief("bestuurderPagina");
        }

        private void btnVoertuigen_Click(object sender, RoutedEventArgs e)
        {
            ZetActief("voertuigPagina");
        }

        private void btnTankkaarten_Click(object sender, RoutedEventArgs e)
        {
            ZetActief("tankkaartPagina");
        }

        private void btnDbVuller_Click(object sender, RoutedEventArgs e)
        {
            ZetActief("dbVullerPagina");
        }
    }
}
