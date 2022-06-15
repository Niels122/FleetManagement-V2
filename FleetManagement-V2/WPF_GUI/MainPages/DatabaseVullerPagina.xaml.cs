using Domein;
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

namespace WPF_GUI.MainPages
{
    /// <summary>
    /// Interaction logic for DatabaseVullerPagina.xaml
    /// </summary>
    public partial class DatabaseVullerPagina : Page
    {
        private DomeinController _dc;
        public DatabaseVullerPagina(DomeinController dc)
        {
            _dc = dc;
            InitializeComponent();
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool succes = int.TryParse(tbAantalRecords.Text, out int AantalRecords);

                if (succes)
                {
                    _dc.DatabankVuller(AantalRecords);
                    MessageBox.Show($"{AantalRecords} records zijn toegevoegd aan de databank");
                }
                else
                {
                    throw new Exception("Input moet een numerieke waarde zijn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
