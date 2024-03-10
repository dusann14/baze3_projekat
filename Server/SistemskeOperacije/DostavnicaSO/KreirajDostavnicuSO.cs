using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.DostavnicaSO
{
    internal class KreirajDostavnicuSO : SistemskaOperacijaBaza
    {
        private Dostavnica dostavnica;

        public KreirajDostavnicuSO(Dostavnica dostavnica)
        {
            this.dostavnica = dostavnica;
        }

        protected override void Izvrsi()
        {
            int id = repozitorijum.VratiMax("BrojDostavnice", "DostavnicaView");

            dostavnica.BrojDostavnice = id;

            repozitorijum.DodajView(dostavnica);

            id = repozitorijum.VratiMax("BrojDostavnice", "StavkaDostavnice");

            foreach (StavkaDostavnice stavka in dostavnica.Stavke)
            {
                stavka.BrojDostavnice = dostavnica.BrojDostavnice;
                stavka.IdStavke = id;
                id++;
                repozitorijum.Dodaj(stavka);
            }
        }
    }
}
