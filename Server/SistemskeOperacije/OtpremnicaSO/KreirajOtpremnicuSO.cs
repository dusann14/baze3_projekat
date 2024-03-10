using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.OtpremnicaSO
{
    internal class KreirajOtpremnicuSO : SistemskaOperacijaBaza
    {
        private Otpremnica otpremnica;

        public KreirajOtpremnicuSO(Otpremnica otpremnica)
        {
            this.otpremnica = otpremnica;
        }

        protected override void Izvrsi()
        {
            int id = repozitorijum.VratiMax("BrojOtpremnice", "OtpremnicaView");

            otpremnica.BrojOtpremnice = id;

            repozitorijum.DodajView(otpremnica);

            id = repozitorijum.VratiMax("BrojOtpremnice", "StavkaOtpremnice");

            foreach (StavkaOtpremnice stavka in otpremnica.Stavke)
            {
                stavka.BrojOtpremnice = otpremnica.BrojOtpremnice;
                stavka.IdStavke = id;
                id++;
                repozitorijum.Dodaj(stavka);
            }
        }
    }
}
