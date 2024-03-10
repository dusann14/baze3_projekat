using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.OrganizacionaJedinicaSO
{
    internal class VratiOrganizacioneJediniceSO : SistemskaOperacijaBaza
    {
        public List<OrganizacionaJedinica> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new OrganizacionaJedinica()).Cast<OrganizacionaJedinica>().ToList();  
        }
    }
}
