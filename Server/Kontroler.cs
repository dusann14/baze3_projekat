using Common.Domen;
using Server.Domen;
using Server.SistemskeOperacije;
using Server.SistemskeOperacije.BankaSO;
using Server.SistemskeOperacije.DostavnicaSO;
using Server.SistemskeOperacije.FakturaSO;
using Server.SistemskeOperacije.FirmaSO;
using Server.SistemskeOperacije.MateijalSO;
using Server.SistemskeOperacije.OrganizacionaJedinicaSO;
using Server.SistemskeOperacije.OtpremnicaSO;
using Server.SistemskeOperacije.PrijavaSO;
using Server.SistemskeOperacije.PrijemnicaSO;
using Server.SistemskeOperacije.ProzivodSO;
using Server.SistemskeOperacije.RacunSO;
using Server.SistemskeOperacije.StavkaFaktureSO;
using Server.SistemskeOperacije.StavkaPrijemniceSO;
using Server.SistemskeOperacije.ValutaSO;
using Server.SistemskeOperacije.ZapisnikSO;
using Server.SistemskeOperacije.ZaposleniSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler instance;

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }

        private Kontroler() { }

        internal Zaposleni Prijava(Zaposleni zaposleni)
        {
            PrijavaSO so = new PrijavaSO(zaposleni);
            so.Template();
            return so.Rezultat;
        }

        internal List<Valuta> VratiValute()
        {
            VratiValuteSO so = new VratiValuteSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Firma> VratiFirme()
        {
            VratiFirmeSO so = new VratiFirmeSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Materijal> VratiMaterijale()
        {
            VratiMaterijaleSO so = new VratiMaterijaleSO();
            so.Template();
            return so.Rezultat;
        }

        internal void KreirajFakturu(Faktura faktura)
        {
            KreirajFakturuSO so = new KreirajFakturuSO(faktura);
            so.Template();
        }

        internal List<Faktura> VratiFakture()
        {
            VratiFaktureSO so = new VratiFaktureSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Faktura> PretraziFakture(Faktura faktura)
        {
            PretraziFaktureSO so = new PretraziFaktureSO(faktura);
            so.Template();
            return so.Rezultat;
        }

        internal List<StavkaFakture> VratiStavkeFakture(Faktura faktura)
        {
            VratiStavkeFaktureSO so = new VratiStavkeFaktureSO(faktura);
            so.Template();
            return so.Rezultat;
        }

        internal void ObrisiFakturu(Faktura faktura)
        {
            ObrisiFakturuSO so = new ObrisiFakturuSO(faktura);
            so.Template();
        }

        internal List<Zaposleni> VratiZaposlene()
        {
            VratiZaposleneSO so = new VratiZaposleneSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<OrganizacionaJedinica> VratiOrganizacioneJedinice()
        {
            VratiOrganizacioneJediniceSO so = new VratiOrganizacioneJediniceSO();
            so.Template();
            return so.Rezultat;
        }

        internal void KreirajDostavnicu(Dostavnica dostavnica)
        {
            KreirajDostavnicuSO so = new KreirajDostavnicuSO(dostavnica);
            so.Template();
        }

        internal List<Proizvod> VratiProzivode()
        {
            VratiProzvodeSO so = new VratiProzvodeSO();
            so.Template();
            return so.Rezultat;
        }

        internal void KreirajOtpremnicu(Otpremnica otpremnica)
        {
            KreirajOtpremnicuSO so = new KreirajOtpremnicuSO(otpremnica);
            so.Template();
        }

        internal List<Dostavnica> VratiDostavnice()
        {
            VratiDostavniceSO so = new VratiDostavniceSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Otpremnica> VratiOtpremnice()
        {
            VratiOtpremniceSO so = new VratiOtpremniceSO();
            so.Template();
            return so.Rezultat;
        }

        internal void KreirajZapisnik(Zapisnik zapisnik)
        {
            KreirajZapisnikSO so = new KreirajZapisnikSO(zapisnik);
            so.Template();
        }

        internal void KreirajPrijemnicu(Prijemnica prijemnica)
        {
            KreirajPrijemnicuSO so = new KreirajPrijemnicuSO(prijemnica);
            so.Template();
        }

        internal List<Prijemnica> VratiPrijemnice()
        {
            VratiPrijemniceSO so = new VratiPrijemniceSO();
            so.Template();
            return so.Rezultat;
        }

        internal List<Prijemnica> VratiPrijemnicePoUslovu(Prijemnica prijemnica)
        {
            VratiPrijemnicePoUslovuSO so = new VratiPrijemnicePoUslovuSO(prijemnica);
            so.Template();
            return so.Rezultat;
        }

        internal List<StavkaPrijemnice> VratiStavkePrijemnice(Prijemnica prijemnica)
        {
            VratiStavkePrijemniceSO so = new VratiStavkePrijemniceSO(prijemnica);
            so.Template();
            return so.Rezultat;
        }

        internal void IzmeniStavke(List<StavkaPrijemnice> promenjeneStavke)
        {
            IzmeniStavkeSO so = new IzmeniStavkeSO(promenjeneStavke);
            so.Template();
        }

        internal List<Banka> VratiBanke()
        {
            VratiBankeSO so = new VratiBankeSO();
            so.Template();
            return so.Rezultat;
        }

        internal void KreirajRacun(Racun racun)
        {
            KreirajRacunSO so = new KreirajRacunSO(racun);
            so.Template();
        }

        internal List<Racun> VratiRacune()
        {
            VratiRacuneSO so = new VratiRacuneSO();
            so.Template();
            return so.Rezultat;
        }

        internal void IzmeniRacune(List<Racun> izmenjeniRacuni)
        {
            IzmeniRacuneSO so = new IzmeniRacuneSO(izmenjeniRacuni);
            so.Template();
        }

        internal void IzmeniBanke(List<Banka> izmenjeneBanke)
        {
            IzmeniBankeSO so = new IzmeniBankeSO(izmenjeneBanke);
            so.Template();
        }
    }
}
