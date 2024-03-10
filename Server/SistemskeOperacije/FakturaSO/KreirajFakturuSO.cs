using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.FakturaSO
{
    internal class KreirajFakturuSO : SistemskaOperacijaBaza
    {
        private Faktura faktura;
        public KreirajFakturuSO(Faktura faktura)
        {
            this.faktura = faktura;
        }

        protected override void Izvrsi()
        {
            double ukupanIznos = 0;
            foreach(StavkaFakture s in faktura.Stavke)
            {
                ukupanIznos += (double)(s.JedinicnaCena * s.Kolicina * ((100 - s.Popust) / 100));
            }

            faktura.UkupanIznos = ukupanIznos;
            repozitorijum.DodajView(faktura);

            int id = repozitorijum.VratiMax("IdStavke", "StavkaFakture");
          
            foreach (StavkaFakture s in faktura.Stavke)
            {
                s.IdStavke = id;
                id++;
                s.UkupanIznos = faktura.UkupanIznos;
                repozitorijum.Dodaj(s);

                s.Uslov = $"BrojFakture = {s.BrojFakture}";
                s.Update = "IznosBezPDV = KalkulatorPoreza.IzracunajIznosBezPDV()";
                repozitorijum.Promeni(s);
            };


            faktura.Uslov = $"BrojFakture = {faktura.BrojFakture}";
            faktura.Update = $"UkupnoPDV = (SELECT SUM(KalkulatorPoreza.IzracunajUkupnoPDV()) FROM StavkaFakture WHERE BrojFakture = {faktura.BrojFakture})";
            repozitorijum.Promeni(faktura);
        }
    }
}
