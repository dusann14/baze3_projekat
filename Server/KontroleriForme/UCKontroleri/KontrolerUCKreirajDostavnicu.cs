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
    internal class KontrolerUCKreirajDostavnicu
    {
        public UCKreirajDostavnicu UCKreirajDostavnicu { get; set; }
        private BindingList<StavkaDostavnice> dodateStavke = new BindingList<StavkaDostavnice>();

        public UCKreirajDostavnicu GenerisiUC()
        {
            UCKreirajDostavnicu = new UCKreirajDostavnicu();
            UCKreirajDostavnicu.button1.Click += Button1_Click;
            UCKreirajDostavnicu.button3.Click += Button3_Click;
            UCKreirajDostavnicu.button2.Click += Button2_Click;
            PopuniPodatke();
            return UCKreirajDostavnicu;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dodateStavke.Count == 0)
            {
                MessageBox.Show("Niste dodali stavke");
                return;
            }

            Zaposleni zaposleniPrimio = (Zaposleni)UCKreirajDostavnicu.dataGridView2.SelectedRows[0].DataBoundItem;
            OrganizacionaJedinica ojPrimila = (OrganizacionaJedinica)UCKreirajDostavnicu.comboBox1.SelectedItem;


            Dostavnica dostavnica = new Dostavnica
            {
                Stavke = dodateStavke.ToList(),
                DatumIzdavanja = DateTime.Now,
                OJIsporucila = Session.Instance.Zaposleni.OrganizacionaJedinica,
                OJPrimila = ojPrimila,
                Isporucio = Session.Instance.Zaposleni,
                Primio = zaposleniPrimio,
                Firma = Session.Instance.Navip
            };

            try
            {
                Kontroler.Instance.KreirajDostavnicu(dostavnica);
                MessageBox.Show("Sistem je uspesno kreirao dostavnicu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao dostavnicu");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StavkaDostavnice stavka = (StavkaDostavnice)UCKreirajDostavnicu.dataGridView3.SelectedRows[0].DataBoundItem;
            dodateStavke.Remove(stavka);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StavkaDostavnice stavka = new StavkaDostavnice
            {
                Materijal = (Materijal)UCKreirajDostavnicu.dataGridView1.SelectedRows[0].DataBoundItem,
                Kolicina = int.Parse(UCKreirajDostavnicu.textBox4.Text),
                Jacina = UCKreirajDostavnicu.textBox7.Text
            };
            dodateStavke.Add(stavka);
        }

        private void PopuniPodatke()
        {
            UCKreirajDostavnicu.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajDostavnicu.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajDostavnicu.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajDostavnicu.dataGridView1.DataSource = Kontroler.Instance.VratiMaterijale();
            UCKreirajDostavnicu.dataGridView2.DataSource = Kontroler.Instance.VratiZaposlene();
            UCKreirajDostavnicu.comboBox1.DataSource = Kontroler.Instance.VratiOrganizacioneJedinice();
            UCKreirajDostavnicu.dataGridView3.DataSource = dodateStavke;
        }
    }
}
