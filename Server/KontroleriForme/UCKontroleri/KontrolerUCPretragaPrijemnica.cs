using Klijent;
using Server.Domen;
using Server.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.KontroleriForme.UCKontroleri
{
    internal class KontrolerUCPretragaPrijemnica
    {
        public UCPretragaPrijemnica UCPretragaPrijemnica { get; set; }

        public UCPretragaPrijemnica GenerisiUC()
        {
            UCPretragaPrijemnica = new UCPretragaPrijemnica();
            PopuniPodatke();
            UCPretragaPrijemnica.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            UCPretragaPrijemnica.dataGridView2.CellDoubleClick += DataGridView2_CellDoubleClick;
            UCPretragaPrijemnica.button3.Click += Button3_Click;
            return UCPretragaPrijemnica;
        }

        private void DataGridView2_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Prijemnica prijemnica = (Prijemnica)UCPretragaPrijemnica.dataGridView2.Rows[e.RowIndex].DataBoundItem;
            Koordinator.Instance.OtvoriPrijemnicaStavke(prijemnica);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            PopuniPodatke();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Prijemnica prijemnica = new Prijemnica
            {
                DatumIzdavanja = UCPretragaPrijemnica.dateTimePicker1.Value
            };
            UCPretragaPrijemnica.dataGridView2.DataSource = Kontroler.Instance.VratiPrijemnicePoUslovu(prijemnica);
        }

        private void PopuniPodatke()
        {
            UCPretragaPrijemnica.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretragaPrijemnica.dataGridView2.DataSource = Kontroler.Instance.VratiPrijemnice();
        }
    }
}
