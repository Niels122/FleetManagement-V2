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
using System.Windows.Shapes;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for BestuurderWindow.xaml
    /// </summary>
    public partial class BestuurderWindow : Window
    {
        private DomeinController _dc;
        public BestuurderWindow(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
            RefreshBestuurders();
        }

        private void RefreshBestuurders()
        {
            //List<Bestuurder> bestuurderView = new();
            //List<List<String>> bestuurdersInfo = _dc.GeefBestuurders();

            //foreach (List<String> bestuurderInfo in bestuurdersInfo)
            //{
            //    //bestuurderView.Add(new BestuurderView(bestuurderInfo[0], bestuurderInfo[1], bestuurderInfo[2]));
            //}

            //LVOverzichtBestuurder.ItemsSource = bestuurderView;
        }

    }
    public class BestuurderView
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Rijksregisternummer { get; set; }

        public BestuurderView(string naam, string voornaam, string rijksregisternummer)
        {
            Naam = naam;
            Voornaam = voornaam;
            Rijksregisternummer = rijksregisternummer;

        }
    }
}

