using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.DostavnicaSO
{
    internal class VratiDostavniceSO : SistemskaOperacijaBaza
    {
        public List<Dostavnica> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Dostavnica()).Cast<Dostavnica>().ToList();
        }
    }
}
