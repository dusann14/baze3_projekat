using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FakturaSO
{
    internal class VratiFaktureSO : SistemskaOperacijaBaza
    {
        public List<Faktura> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Faktura()).Cast<Faktura>().ToList();
        }
    }
}
