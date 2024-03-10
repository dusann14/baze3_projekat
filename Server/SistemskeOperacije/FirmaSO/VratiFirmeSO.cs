using Klijent;
using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FirmaSO
{
    internal class VratiFirmeSO : SistemskaOperacijaBaza
    {
        public List<Firma> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Firma firma = new Firma
            {
                Uslov = $"fi.MaticniBroj != {Session.Instance.Navip.MaticniBroj}"
            };
            Rezultat = repozitorijum.VratiPoUslovu(firma).Cast<Firma>().ToList();
        }
    }
}
