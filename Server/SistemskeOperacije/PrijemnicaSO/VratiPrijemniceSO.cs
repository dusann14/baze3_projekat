using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PrijemnicaSO
{
    internal class VratiPrijemniceSO : SistemskaOperacijaBaza
    {
        public List<Prijemnica> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Prijemnica()).Cast<Prijemnica>().ToList();
        }
    }
}
