using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FakturaSO
{
    internal class PretraziFaktureSO : SistemskaOperacijaBaza
    {
        public List<Faktura> Rezultat { get; set; }
        private Faktura faktura;
        public PretraziFaktureSO(Faktura faktura)
        {
            this.faktura = faktura;
        }

        protected override void Izvrsi()
        {
            faktura.Uslov = $"f.DatumIzdavanja = '{faktura.DatumIzdavanja}'";
            Rezultat = repozitorijum.VratiPoUslovu(faktura).Cast<Faktura>().ToList();
        }
    }
}
