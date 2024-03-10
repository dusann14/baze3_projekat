using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.MateijalSO
{
    internal class VratiMaterijaleSO : SistemskaOperacijaBaza
    {
        public List<Materijal> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Materijal()).Cast<Materijal>().ToList();
        }
    }
}
