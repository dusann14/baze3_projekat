using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.RacunSO
{
    internal class VratiRacuneSO : SistemskaOperacijaBaza
    {
        public List<Racun> Rezultat { get; set; }

        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Racun()).Cast<Racun>().ToList();
        }
    }
}
