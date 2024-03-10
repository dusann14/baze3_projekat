using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FakturaSO
{
    internal class ObrisiFakturuSO : SistemskaOperacijaBaza
    {
        private Faktura faktura;
        public ObrisiFakturuSO(Faktura faktura)
        {
            this.faktura = faktura;
        }

        protected override void Izvrsi()
        {
            faktura.Uslov = $"BrojFakture = {faktura.BrojFakture}";
            repozitorijum.Obrisi(faktura);
        }
    }
}
