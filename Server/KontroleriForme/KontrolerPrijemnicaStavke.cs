using Klijent;
using Server.Domen;
using Server.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.KontroleriForme.UCKontroleri
{
    internal class KontrolerPrijemnicaStavke
    {
        public PrijemnicaStavke PrijemnicaStavke { get; set; }
        private Prijemnica prijemnica;
        private List<StavkaPrijemnice> promenjeneStavke = new List<StavkaPrijemnice>();
        private BindingList<StavkaOtpremnice> dodateStavke = new BindingList<StavkaOtpremnice>();

        public PrijemnicaStavke GenerisiUC(Prijemnica prijemnica)
        {
            PrijemnicaStavke = new PrijemnicaStavke();
            this.prijemnica = prijemnica;
            PrijemnicaStavke.dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            PrijemnicaStavke.button2.Click += Button2_Click;
            PrijemnicaStavke.button1.Click += Button1_Click;
            PopuniPodatke();
            return PrijemnicaStavke;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Kontroler.Instance.IzmeniStavke(promenjeneStavke);
                MessageBox.Show("Sistem je uspesno izmenio stavke");
                PrijemnicaStavke.Dispose();
                Koordinator.Instance.OtvoriUCPretragaPrijemnica();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno izmeni stavke");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(PrijemnicaStavke.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali stavku");
                return;
            }

            StavkaPrijemnice stavkaPrijemnice = (StavkaPrijemnice)PrijemnicaStavke.dataGridView1.SelectedRows[0].DataBoundItem;
            
            if (!promenjeneStavke.Contains(stavkaPrijemnice))
            {
                stavkaPrijemnice.Status = StatusStavkePrijemnice.OBRISAN;
                promenjeneStavke.Add(stavkaPrijemnice);
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StavkaPrijemnice stavkaPrijemnice = (StavkaPrijemnice)PrijemnicaStavke.dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (!promenjeneStavke.Contains(stavkaPrijemnice))
            {
                stavkaPrijemnice.Status = StatusStavkePrijemnice.PROMENJEN;
                promenjeneStavke.Add(stavkaPrijemnice);
            }
        }

        private void PopuniPodatke()
        {
            PrijemnicaStavke.StartPosition = FormStartPosition.CenterScreen;
            PrijemnicaStavke.dateTimePicker1.Value = prijemnica.DatumIzdavanja;
            PrijemnicaStavke.brojPrijemnice.Text = $"Broj prijemnice: {prijemnica.BrojPrijemnice}";
            PrijemnicaStavke.prevoznoSredstvo.Text = $"Prevozno sredstvo, registarska oznaka: {prijemnica.PrevoznoSredstvo}";
            PrijemnicaStavke.napomena.Text = $"Napomena: {prijemnica.Napomena}";
            PrijemnicaStavke.zaposleniPrimio.Text = $"Zaposleni primio: {prijemnica.Primio.ImePrezime}";
            PrijemnicaStavke.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            PrijemnicaStavke.dataGridView1.DataSource = Kontroler.Instance.VratiStavkePrijemnice(prijemnica);
        }
    }
}
