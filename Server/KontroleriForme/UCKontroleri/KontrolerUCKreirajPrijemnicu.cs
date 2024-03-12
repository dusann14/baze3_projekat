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
    internal class KontrolerUCKreirajPrijemnicu
    {
        public UCKreirajPrijemnicu UCKreirajPrijemnicu { get; set; }
        private BindingList<StavkaPrijemnice> dodateStavke = new BindingList<StavkaPrijemnice>();

        public UCKreirajPrijemnicu GenerisiUC()
        {
            UCKreirajPrijemnicu = new UCKreirajPrijemnicu();
            PopuniPodatke();
            UCKreirajPrijemnicu.button1.Click += Button1_Click;
            UCKreirajPrijemnicu.button2.Click += Button2_Click;
            UCKreirajPrijemnicu.button3.Click += Button3_Click;
            return UCKreirajPrijemnicu;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StavkaPrijemnice stavka = (StavkaPrijemnice)UCKreirajPrijemnicu.dataGridView3.SelectedRows[0].DataBoundItem;
            dodateStavke.Remove(stavka);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dodateStavke.Count == 0)
            {
                MessageBox.Show("Niste dodali stavke");
                return;
            }

            if (UCKreirajPrijemnicu.dataGridView2.SelectedRows.Count > 0 && UCKreirajPrijemnicu.dataGridView4.SelectedRows.Count > 0 && UCKreirajPrijemnicu.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajPrijemnicu.dataGridView2.SelectedRows.Count > 0 && UCKreirajPrijemnicu.dataGridView4.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajPrijemnicu.dataGridView4.SelectedRows.Count > 0 && UCKreirajPrijemnicu.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajPrijemnicu.dataGridView2.SelectedRows.Count > 0 && UCKreirajPrijemnicu.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            Faktura faktura = null;
            Dostavnica dostavnica = null;
            Otpremnica otpremnica = null;

            if (UCKreirajPrijemnicu.dataGridView2.SelectedRows.Count > 0)
            {
                faktura = (Faktura)UCKreirajPrijemnicu.dataGridView2.SelectedRows[0].DataBoundItem;
            }

            if (UCKreirajPrijemnicu.dataGridView4.SelectedRows.Count > 0)
            {
                dostavnica = (Dostavnica)UCKreirajPrijemnicu.dataGridView4.SelectedRows[0].DataBoundItem;
            }

            if (UCKreirajPrijemnicu.dataGridView5.SelectedRows.Count > 0)
            {
                otpremnica = (Otpremnica)UCKreirajPrijemnicu.dataGridView5.SelectedRows[0].DataBoundItem;
            }


            Prijemnica prijemnica = new Prijemnica
            {
                PrevoznoSredstvo = UCKreirajPrijemnicu.textBox1.Text,
                Faktura = faktura,
                Otpremnica = otpremnica,
                Dostavnica = dostavnica,
                Stavke = dodateStavke.ToList(),
                Firma = Session.Instance.Navip,
                OrganizacionaJedinica = Session.Instance.Zaposleni.OrganizacionaJedinica,
                Primio = (Zaposleni)UCKreirajPrijemnicu.dataGridView6.SelectedRows[0].DataBoundItem,
                Isporucio = Session.Instance.Zaposleni,
                Napomena = UCKreirajPrijemnicu.textBox2.Text,
                DatumIzdavanja = DateTime.Now
            };

            try
            {
                Kontroler.Instance.KreirajPrijemnicu(prijemnica);
                MessageBox.Show("Sistem je uspesno kreirao prijemnicu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao prijemnicu: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StavkaPrijemnice stavka = new StavkaPrijemnice
            {
                Materijal = (Materijal)UCKreirajPrijemnicu.dataGridView1.SelectedRows[0].DataBoundItem,
                Kolicina = int.Parse(UCKreirajPrijemnicu.textBox4.Text),
                Jacina = int.Parse(UCKreirajPrijemnicu.textBox3.Text),
            };
            dodateStavke.Add(stavka);
        }

        private void PopuniPodatke()
        {
            UCKreirajPrijemnicu.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajPrijemnicu.dataGridView1.DataSource = Kontroler.Instance.VratiMaterijale();
            UCKreirajPrijemnicu.dataGridView2.DataSource = Kontroler.Instance.VratiFakture();
            UCKreirajPrijemnicu.dataGridView3.DataSource = dodateStavke;
            UCKreirajPrijemnicu.dataGridView4.DataSource = Kontroler.Instance.VratiDostavnice();
            UCKreirajPrijemnicu.dataGridView5.DataSource = Kontroler.Instance.VratiOtpremnice();
            UCKreirajPrijemnicu.dataGridView6.DataSource = Kontroler.Instance.VratiZaposlene();
        }
    }
}
