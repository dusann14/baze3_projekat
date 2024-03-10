using Common.Domen;
using Server.Domen;
using Server.SistemskeOperacije;
using Server.SistemskeOperacije.DostavnicaSO;
using Server.SistemskeOperacije.FakturaSO;
using Server.SistemskeOperacije.FirmaSO;
using Server.SistemskeOperacije.MateijalSO;
using Server.SistemskeOperacije.OrganizacionaJedinicaSO;
using Server.SistemskeOperacije.OtpremnicaSO;
using Server.SistemskeOperacije.PrijavaSO;
using Server.SistemskeOperacije.ProzivodSO;
using Server.SistemskeOperacije.StavkaFaktureSO;
using Server.SistemskeOperacije.ValutaSO;
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
    }
}
