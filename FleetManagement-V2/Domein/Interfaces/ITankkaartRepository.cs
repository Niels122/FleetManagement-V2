using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Interfaces
{
    public interface ITankkaartRepository
    {
        List<int> GeefTankkaartnummers();
    }
}
