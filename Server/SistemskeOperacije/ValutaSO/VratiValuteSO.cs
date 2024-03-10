using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.ValutaSO
{
    internal class VratiValuteSO : SistemskaOperacijaBaza
    {
        public List<Valuta> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Valuta()).Cast<Valuta>().ToList();
        }
    }
}
