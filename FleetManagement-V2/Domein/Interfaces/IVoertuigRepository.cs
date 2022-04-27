using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Interfaces
{
     public interface IVoertuigRepository
    {
        List<int> GeefChassisnummers();
        List<string> GeefNummerplaten();
    }
}
