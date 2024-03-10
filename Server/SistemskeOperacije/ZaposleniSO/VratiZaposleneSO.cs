using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.ZaposleniSO
{
    internal class VratiZaposleneSO : SistemskaOperacijaBaza
    {
        public List<Zaposleni> Rezultat{ get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Zaposleni()).Cast<Zaposleni>().ToList();
        }
    }
}
