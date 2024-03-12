using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PrijemnicaSO
{
    internal class VratiPrijemnicePoUslovuSO : SistemskaOperacijaBaza
    {
        public List<Prijemnica> Rezultat { get; set; }
        private Prijemnica prijemnica;
        public VratiPrijemnicePoUslovuSO(Prijemnica prijemnica)
        {
            this.prijemnica = prijemnica;
        }

        protected override void Izvrsi()
        {
            prijemnica.Uslov = $"p.DatumIzdavanja = '{prijemnica.DatumIzdavanja}'";
            Rezultat = repozitorijum.VratiPoUslovu(prijemnica).Cast<Prijemnica>().ToList();
        }
    }
}
