using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.ZapisnikSO
{
    internal class KreirajZapisnikSO : SistemskaOperacijaBaza
    {
        private Zapisnik zapisnik;
        public KreirajZapisnikSO(Zapisnik zapisnik)
        {
            this.zapisnik = zapisnik;
        }

        protected override void Izvrsi()
        {
            int id = repozitorijum.VratiMax("BrojZapisnika", "Zapisnik");

            zapisnik.BrojZapisnika = id;

            repozitorijum.DodajView(zapisnik);

            id = repozitorijum.VratiMax("BrojZapisnika", "StavkaZapisnika");

            foreach (StavkaZapisnika stavka in zapisnik.Stavke)
            {
                stavka.BrojZapisnika = zapisnik.BrojZapisnika;
                stavka.IdStavke = id;
                id++;
                repozitorijum.Dodaj(stavka);
            }
        }
    }
}
