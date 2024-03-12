using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.OtpremnicaSO
{
    internal class VratiOtpremniceSO : SistemskaOperacijaBaza
    {
        public List<Otpremnica> Rezultat { get; set; }
        protected override void Izvrsi()
        {
            Rezultat = repozitorijum.VratiSve(new Otpremnica()).Cast<Otpremnica>().ToList();
        }
    }
}
