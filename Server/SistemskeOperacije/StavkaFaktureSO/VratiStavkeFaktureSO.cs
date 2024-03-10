using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.StavkaFaktureSO
{
    internal class VratiStavkeFaktureSO : SistemskaOperacijaBaza
    {
        public List<StavkaFakture> Rezultat { get; set; }

        private Faktura faktura;

        public VratiStavkeFaktureSO(Faktura faktura)
        {
            this.faktura = faktura;
        }

        protected override void Izvrsi()
        {
            StavkaFakture stavka = new StavkaFakture
            {
                Uslov = $"sf.BrojFakture = {faktura.BrojFakture}"
            };
            Rezultat = repozitorijum.VratiPoUslovu(stavka).Cast<StavkaFakture>().ToList();
        }
    }
}
