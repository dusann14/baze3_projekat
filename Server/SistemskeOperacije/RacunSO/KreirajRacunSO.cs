using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.RacunSO
{
    internal class KreirajRacunSO : SistemskaOperacijaBaza
    {
        private Racun racun;
        public KreirajRacunSO(Racun racun)
        {
            this.racun = racun;
        }

        protected override void Izvrsi()
        {
            repozitorijum.DodajView(racun);
        }
    }
}
