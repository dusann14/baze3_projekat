using Server.Domen;
using Server.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.KontroleriForme.UCKontroleri
{
    internal class KontrolerUCPretragaRacuna
    {
        public UCPretragaRacuna UCPretragaRacuna { get; set; }
        private List<Racun> izmenjeniRacuni = new List<Racun>();
        private List<Banka> izmenjeneBanke = new List<Banka>();

        public UCPretragaRacuna GenerisiUC()
        {
            UCPretragaRacuna = new UCPretragaRacuna();
            PopuniPodatke();
            UCPretragaRacuna.button1.Click += Button1_Click;
            UCPretragaRacuna.button2.Click += Button2_Click;
            UCPretragaRacuna.button3.Click += Button3_Click;
            UCPretragaRacuna.dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            UCPretragaRacuna.dataGridView2.CellEndEdit += DataGridView2_CellEndEdit;
            return UCPretragaRacuna;
        }

        private void DataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Racun racun = (Racun)UCPretragaRacuna.dataGridView2.Rows[e.RowIndex].DataBoundItem;
            izmenjeniRacuni.Add(racun);
        }

        private void DataGridView1_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Banka banka = (Banka)UCPretragaRacuna.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            izmenjeneBanke.Add(banka);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Kontroler.Instance.IzmeniBanke(izmenjeneBanke);
                MessageBox.Show("Sistem je uspesno izmenio banke");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno izmenio banke: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Kontroler.Instance.IzmeniRacune(izmenjeniRacuni);
                MessageBox.Show("Sistem je uspesno izmenio racune");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno izmenio racune: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PopuniPodatke();
        }

        private void PopuniPodatke()
        {
            UCPretragaRacuna.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretragaRacuna.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretragaRacuna.dataGridView1.DataSource = Kontroler.Instance.VratiBanke();
            UCPretragaRacuna.dataGridView2.DataSource = Kontroler.Instance.VratiRacune();
        }
    }
}
