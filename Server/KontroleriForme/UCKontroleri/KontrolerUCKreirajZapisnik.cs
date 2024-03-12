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
    internal class KontrolerUCKreirajZapisnik
    {
        public UCKreirajZapisnik UCKreirajZapisnik { get; set; }
        private BindingList<StavkaZapisnika> dodateStavke = new BindingList<StavkaZapisnika>();

        public UCKreirajZapisnik GenerisiUC()
        {
            UCKreirajZapisnik = new UCKreirajZapisnik();
            PopuniPodatke();
            UCKreirajZapisnik.button1.Click += Button1_Click;
            UCKreirajZapisnik.button2.Click += Button2_Click;
            UCKreirajZapisnik.button3.Click += Button3_Click;
            return UCKreirajZapisnik;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StavkaZapisnika stavka = (StavkaZapisnika)UCKreirajZapisnik.dataGridView3.SelectedRows[0].DataBoundItem;
            dodateStavke.Remove(stavka);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dodateStavke.Count == 0)
            {
                MessageBox.Show("Niste dodali stavke");
                return;
            }

            if(UCKreirajZapisnik.dataGridView2.SelectedRows.Count > 0 && UCKreirajZapisnik.dataGridView4.SelectedRows.Count > 0 && UCKreirajZapisnik.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajZapisnik.dataGridView2.SelectedRows.Count > 0 && UCKreirajZapisnik.dataGridView4.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajZapisnik.dataGridView4.SelectedRows.Count > 0 && UCKreirajZapisnik.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            if (UCKreirajZapisnik.dataGridView2.SelectedRows.Count > 0 && UCKreirajZapisnik.dataGridView5.SelectedRows.Count > 0)
            {
                MessageBox.Show("Mozete izabrati samo jedan od dokumenata");
                return;
            }

            Faktura faktura = null;
            Dostavnica dostavnica = null;
            Otpremnica otpremnica = null;

            if(UCKreirajZapisnik.dataGridView2.SelectedRows.Count > 0)
            {
                faktura = (Faktura)UCKreirajZapisnik.dataGridView2.SelectedRows[0].DataBoundItem;
            }

            if (UCKreirajZapisnik.dataGridView4.SelectedRows.Count > 0)
            {
                dostavnica = (Dostavnica)UCKreirajZapisnik.dataGridView4.SelectedRows[0].DataBoundItem;
            }

            if (UCKreirajZapisnik.dataGridView5.SelectedRows.Count > 0)
            {
                otpremnica = (Otpremnica)UCKreirajZapisnik.dataGridView5.SelectedRows[0].DataBoundItem;
            }


            Zapisnik zapisnik = new Zapisnik
            {
                Aktivnost = UCKreirajZapisnik.textBox1.Text,
                Faktura = faktura,
                Otpremnica = otpremnica,
                Dostavnica = dostavnica,
                Stavke = dodateStavke.ToList(),
                Firma = Session.Instance.Navip,
                OrganizacionaJedinica = Session.Instance.Zaposleni.OrganizacionaJedinica,
                Overio = Session.Instance.Zaposleni,
                DatumIzdavanja = DateTime.Now
            };

            try
            {
                Kontroler.Instance.KreirajZapisnik(zapisnik);
                MessageBox.Show("Sistem je uspesno kreirao zapisnik");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao zapisnik: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StavkaZapisnika stavka = new StavkaZapisnika
            {
                Materijal = (Materijal)UCKreirajZapisnik.dataGridView1.SelectedRows[0].DataBoundItem,
                Kolicina = int.Parse(UCKreirajZapisnik.textBox4.Text),
            };
            dodateStavke.Add(stavka);
        }

        private void PopuniPodatke()
        {
            UCKreirajZapisnik.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajZapisnik.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajZapisnik.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajZapisnik.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajZapisnik.dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajZapisnik.dataGridView1.DataSource = Kontroler.Instance.VratiMaterijale();
            UCKreirajZapisnik.dataGridView2.DataSource = Kontroler.Instance.VratiFakture();
            UCKreirajZapisnik.dataGridView3.DataSource = dodateStavke;
            UCKreirajZapisnik.dataGridView4.DataSource = Kontroler.Instance.VratiDostavnice();
            UCKreirajZapisnik.dataGridView5.DataSource = Kontroler.Instance.VratiOtpremnice();
        }
    }
}
