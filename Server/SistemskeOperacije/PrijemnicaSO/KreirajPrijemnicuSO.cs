using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PrijemnicaSO
{
    internal class KreirajPrijemnicuSO : SistemskaOperacijaBaza
    {
        private Prijemnica prijemnica;
        public KreirajPrijemnicuSO(Prijemnica prijemnica)
        {
            this.prijemnica = prijemnica;
        }

        protected override void Izvrsi()
        {
            int id = repozitorijum.VratiMax("BrojPrijemnice", "Prijemnica");

            prijemnica.BrojPrijemnice = id;

            repozitorijum.DodajView(prijemnica);

            id = repozitorijum.VratiMax("BrojPrijemnice", "StavkaPrijemnice");

            foreach (StavkaPrijemnice stavka in prijemnica.Stavke)
            {
                stavka.BrojPrijemnice = prijemnica.BrojPrijemnice;
                stavka.IdStavke = id;
                id++;
                repozitorijum.DodajView(stavka);
            }
        }
    }
}
