using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.StavkaPrijemniceSO
{
    internal class VratiStavkePrijemniceSO : SistemskaOperacijaBaza
    {
        public List<StavkaPrijemnice> Rezultat { get; set; }
        private Prijemnica prijemnica;
        public VratiStavkePrijemniceSO(Prijemnica prijemnica)
        {
            this.prijemnica = prijemnica;
        }

        protected override void Izvrsi()
        {
            StavkaPrijemnice stavkaPrijemnice = new StavkaPrijemnice
            {
                Uslov = $"sp.BrojPrijemnice = {prijemnica.BrojPrijemnice}"
            };
            Rezultat = repozitorijum.VratiPoUslovu(stavkaPrijemnice).Cast<StavkaPrijemnice>().ToList();
        }
    }
}
