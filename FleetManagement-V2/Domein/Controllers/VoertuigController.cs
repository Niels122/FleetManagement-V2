using Domein.Interfaces;
using Domein.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Controllers
{
    public class VoertuigController
    {
        private IVoertuigRepository _voertuigRepo;

        public VoertuigController(IVoertuigRepository voertuigRepo)
        {
            _voertuigRepo = voertuigRepo;
        }

        public List<Voertuig> GeefVoertuigen()
        {            
            return _voertuigRepo.GeefVoertuigen();
        }
    }
}
