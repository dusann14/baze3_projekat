using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.ProzivodSO
{
    internal class VratiProzvodeSO : SistemskaOperacijaBaza
    {
        public List<Proizvod> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Proizvod()).Cast<Proizvod>().ToList();  
        }
    }
}
