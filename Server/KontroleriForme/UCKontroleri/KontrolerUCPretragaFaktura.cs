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
    internal class KontrolerUCPretragaFaktura
    {
        public UCPretragaFaktura UCPretragaFaktura { get; set; }

        public UCPretragaFaktura GenerisiUC()
        {
            UCPretragaFaktura = new UCPretragaFaktura();
            PostaviPodatke();
            UCPretragaFaktura.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCPretragaFaktura.dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            UCPretragaFaktura.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            return UCPretragaFaktura;
        }

        private void DataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Faktura faktura = (Faktura)UCPretragaFaktura.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Koordinator.Instance.OtvoriFakturaDetalji(faktura);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Faktura faktura = new Faktura
            {
                DatumIzdavanja = UCPretragaFaktura.dateTimePicker1.Value
            };
            UCPretragaFaktura.dataGridView1.DataSource = Kontroler.Instance.PretraziFakture(faktura);
        }

        private void PostaviPodatke()
        {
            UCPretragaFaktura.dataGridView1.DataSource = Kontroler.Instance.VratiFakture();
        }
    }
}
