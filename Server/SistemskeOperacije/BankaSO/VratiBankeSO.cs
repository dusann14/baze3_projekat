using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.BankaSO
{
    internal class VratiBankeSO : SistemskaOperacijaBaza
    {
        public List<Banka> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Banka()).Cast<Banka>().ToList();
        }
    }
}
