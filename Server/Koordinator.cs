﻿using Klijent.KontroleriForme;
using Server.Domen;
using Server.Forme;
using Server.KontroleriForme;
using Server.KontroleriForme.UCKontroleri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Koordinator
    {
        public Klijent KlijentForma { get; set; }

        public Login LoginForma { get; set; }

        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }

        }

        private Koordinator()
        {
            loginKontroler = new LoginKontroler();
            kontrolerForme = new KontrolerForme();
            kontrolerFakturaDetalji = new KontrolerFakturaDetalji();

            kontrolerUCKreirajFakturu = new KontrolerUCKreirajFakturu();
            kontrolerUCPretragaFaktura = new KontrolerUCPretragaFaktura();
            kontrolerUCKreirajDostavnicu = new KontrolerUCKreirajDostavnicu();
            kontrolerUCKreirajOtpremnicu = new KontrolerUCKreirajOtpremnicu();
            kontrolerUCKreirajZapisnik = new KontrolerUCKreirajZapisnik();
        }

        private LoginKontroler loginKontroler;
        private KontrolerForme kontrolerForme;
        private KontrolerFakturaDetalji kontrolerFakturaDetalji;

        private KontrolerUCKreirajFakturu kontrolerUCKreirajFakturu;
        private KontrolerUCPretragaFaktura kontrolerUCPretragaFaktura;
        private KontrolerUCKreirajDostavnicu kontrolerUCKreirajDostavnicu;
        private KontrolerUCKreirajOtpremnicu kontrolerUCKreirajOtpremnicu;
        private KontrolerUCKreirajZapisnik kontrolerUCKreirajZapisnik;

        internal void OtvoriLoginFormu()
        {   
            LoginForma = loginKontroler.NapraviLoginFormu();
            LoginForma.ShowDialog();
        }

        internal void OtvoriGlavnuFormu()
        {
            KlijentForma = kontrolerForme.NapraviGlavnuFormu();
            OtvoriKreirajFakturu();
            KlijentForma.ShowDialog();
        }

        internal void OtvoriKreirajFakturu()
        {
            KlijentForma.PostaviPanel(kontrolerUCKreirajFakturu.GenerisiUC());
        }

        internal void OtvoriUCPretragaFaktura()
        {
            KlijentForma.PostaviPanel(kontrolerUCPretragaFaktura.GenerisiUC());
        }

        internal void OtvoriFakturaDetalji(Faktura faktura)
        {
            FakturaDetalji fakturaDetalji = kontrolerFakturaDetalji.GenerisiFormu(faktura);
            fakturaDetalji.ShowDialog();
        }

        internal void OtvoriUCKreirajDostavnicu()
        {
            KlijentForma.PostaviPanel(kontrolerUCKreirajDostavnicu.GenerisiUC());
        }

        internal void OtvoriUCKreirajOtpremnicu()
        {
            KlijentForma.PostaviPanel(kontrolerUCKreirajOtpremnicu.GenerisiUC());
        }

        internal void OtvoriUCKreirajZapisnik()
        {
            KlijentForma.PostaviPanel(kontrolerUCKreirajZapisnik.GenerisiUC());
        }
    }
}