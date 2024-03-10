using Common.Domen;
using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Session
    {
        private static Session instance;

        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                    instance.Navip = new Firma
                    {
                        MaticniBroj = 17115880,
                        Adresa = "Radnicka br.14",
                        PoslovnoIme = "Navip Vinarstvo doo Vranje",
                        PIB = "101948563",
                        Grad = new Grad
                        {
                            PostanskiBroj = 17500,
                            Naziv = "Vranje"
                        }
                    };
                }
                return instance;
            }
        }

        private Session() { }


        public Zaposleni Zaposleni { get; set; }
        public Firma Navip { get; set; }
    }
}
