using Klijent;
using Server.Domen;
using Server.Forme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.KontroleriForme
{
    internal class KontrolerFakturaDetalji
    {
        public FakturaDetalji FakturaDetalji { get; set; }
        public Faktura Faktura { get; set; }

        public FakturaDetalji GenerisiFormu(Faktura faktura)
        {
            Faktura = faktura;
            FakturaDetalji = new FakturaDetalji();
            PopuniPodatke();
            FakturaDetalji.button1.Click += Button1_Click;
            return FakturaDetalji;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Kontroler.Instance.ObrisiFakturu(Faktura);
                MessageBox.Show("Sistem je uspesno obrisao fakturu");
                FakturaDetalji.Dispose();
                Koordinator.Instance.OtvoriUCPretragaFaktura();
            }catch(Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno obrisao fakturu");
            }
        }

        private void PopuniPodatke()
        {
            FakturaDetalji.WindowState = FormWindowState.Maximized;
            FakturaDetalji.FormBorderStyle = FormBorderStyle.Sizable;
            FakturaDetalji.StartPosition = FormStartPosition.CenterScreen;
            FakturaDetalji.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            FakturaDetalji.dataGridView1.DataSource = Kontroler.Instance.VratiStavkeFakture(Faktura);
            FakturaDetalji.dateTimePicker1.Value = Faktura.DatumIzdavanja;
            FakturaDetalji.labelFaktura.Text = $"{Faktura.BrojFakture}";
            FakturaDetalji.labelPozivNaBroj.Text = $"{Faktura.PozivNaBroj}";
            FakturaDetalji.labelMaticniKupac.Text = $"{Session.Instance.Navip.MaticniBroj}";
            FakturaDetalji.labelPIBKupac.Text = $"{Session.Instance.Navip.PIB}";
            FakturaDetalji.labelKupacIme.Text = $"{Session.Instance.Navip.PoslovnoIme}";
            FakturaDetalji.labelKupacAdresa.Text = $"{Session.Instance.Navip.Grad.PostanskiBroj} {Session.Instance.Navip.Grad.Naziv}, {Session.Instance.Navip.Adresa}";
            FakturaDetalji.labelValuta.Text = $"{Faktura.Valuta.Zapis}";
            FakturaDetalji.labelUkupno.Text = $"{Faktura.UkupanIznos}";
            FakturaDetalji.labelProdavacIme.Text = $"{Faktura.Prodavac.PoslovnoIme}";
            FakturaDetalji.labelProdavacAdresa.Text = $"Adresa: {Faktura.Prodavac.Adresa}";
            FakturaDetalji.labelProdavacPIB.Text = $"PIB: {Faktura.Prodavac.PIB}";
            FakturaDetalji.labelProdavacMaticni.Text = $"Maticni broj: {Faktura.Prodavac.MaticniBroj}";
            FakturaDetalji.labelNapomena.Text = $"Napomena: {Faktura.Napomena}";
        }
    }
}
