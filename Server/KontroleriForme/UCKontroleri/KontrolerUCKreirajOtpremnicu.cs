using Klijent;
using Server.Domen;
using Server.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.KontroleriForme.UCKontroleri
{
    internal class KontrolerUCKreirajOtpremnicu
    {
        public UCKreirajOtpremnicu UCKreirajOtpremnicu { get; set; }
        private BindingList<StavkaOtpremnice> dodateStavke = new BindingList<StavkaOtpremnice>();

        public UCKreirajOtpremnicu GenerisiUC()
        {
            UCKreirajOtpremnicu = new UCKreirajOtpremnicu();
            PopuniPodatke();
            UCKreirajOtpremnicu.button1.Click += Button1_Click;
            UCKreirajOtpremnicu.button3.Click += Button3_Click;
            UCKreirajOtpremnicu.button2.Click += Button2_Click;
            return UCKreirajOtpremnicu;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dodateStavke.Count == 0)
            {
                MessageBox.Show("Niste dodali stavke");
                return;
            }

            Zaposleni zaposleniPrimio = (Zaposleni)UCKreirajOtpremnicu.dataGridView2.SelectedRows[0].DataBoundItem;
            Firma firmaPrimila = (Firma)UCKreirajOtpremnicu.comboBox1.SelectedItem;


            Otpremnica otpremnica = new Otpremnica
            {
                Stavke = dodateStavke.ToList(),
                DatumIzdavanja = DateTime.Now,
                OJIzdala = Session.Instance.Zaposleni.OrganizacionaJedinica,
                Kupila = firmaPrimila,
                Isporucio = Session.Instance.Zaposleni,
                Primio = zaposleniPrimio,
                Izdala = Session.Instance.Navip
            };

            try
            {
                Kontroler.Instance.KreirajOtpremnicu(otpremnica);
                MessageBox.Show("Sistem je uspesno kreirao dostavnicu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao dostavnicu");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StavkaOtpremnice stavka = (StavkaOtpremnice)UCKreirajOtpremnicu.dataGridView3.SelectedRows[0].DataBoundItem;
            dodateStavke.Remove(stavka);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StavkaOtpremnice stavka = new StavkaOtpremnice
            {
                Prozivod = (Proizvod)UCKreirajOtpremnicu.dataGridView1.SelectedRows[0].DataBoundItem,
                Kolicina = int.Parse(UCKreirajOtpremnicu.textBox4.Text),
                Jacina = UCKreirajOtpremnicu.textBox7.Text
            };
            dodateStavke.Add(stavka);
        }

        private void PopuniPodatke()
        {
            UCKreirajOtpremnicu.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajOtpremnicu.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajOtpremnicu.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajOtpremnicu.dataGridView1.DataSource = Kontroler.Instance.VratiProzivode();
            UCKreirajOtpremnicu.dataGridView2.DataSource = Kontroler.Instance.VratiZaposlene();
            UCKreirajOtpremnicu.comboBox1.DataSource = Kontroler.Instance.VratiFirme();
            UCKreirajOtpremnicu.dataGridView3.DataSource = dodateStavke;
        }
    }
}
