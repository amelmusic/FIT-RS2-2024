using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class DummyProizvodiService : ProizvodiService
    {
        DateTime time = DateTime.Now;

        public new List<Proizvodi> List = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodId = 1,
                Naziv = "Laptop",
                Cijena = 999
            }
        };
        public override List<Proizvodi> GetList()
        {
            var t = time;
            //Debugger.Launch();
            return List;
        }
    }
}
