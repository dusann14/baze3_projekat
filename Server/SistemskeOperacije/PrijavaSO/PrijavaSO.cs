using Common.Domen;
using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.PrijavaSO
{
    public class PrijavaSO : SistemskaOperacijaBaza
    {
        public Zaposleni Rezultat { get; set; }

        public PrijavaSO(Zaposleni zaposleni)
        {
            this.zaposleni = zaposleni;
        }

        private Zaposleni zaposleni;
        protected override void Izvrsi()
        {
            zaposleni.Uslov = $"z.KorisnickoIme = '{zaposleni.KorisnickoIme}' and z.Lozinka = '{zaposleni.Lozinka}'";
            Rezultat = (Zaposleni)repozitorijum.VratiJednog(zaposleni);
        }
    }
}
