using Domein;
using Domein.Controllers;
using Persistentie;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application //waar andere deel van klasse?
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BestuurderRepository bestuurderRepo = new BestuurderRepository();
            AdresRepository adresRepo = new AdresRepository();
            VoertuigRepository voertuigRepo = new VoertuigRepository();
            TankkaartRepository tankkaartRepo = new TankkaartRepository();

            BestuurderController bestuurderCon = new BestuurderController(bestuurderRepo);
            AdresController adresCon = new AdresController(adresRepo);
            VoertuigController voertuigCon = new VoertuigController(voertuigRepo);
            TankkaartController tankkaartCon = new TankkaartController(tankkaartRepo);

            DomeinController dc = new DomeinController(voertuigCon, tankkaartCon, bestuurderCon, adresCon);
            
            MainWindow MainWnd = new MainWindow(dc);
            MainWnd.Title = "Fleet management app";

            MainWnd.Show();
            //base.OnStartup(e);
        }
    }
}
