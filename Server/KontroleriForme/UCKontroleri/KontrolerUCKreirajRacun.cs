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
    internal class KontrolerUCKreirajRacun
    {
        public UCKreirajRacun UCKreirajRacun { get; set; }

        public UCKreirajRacun GenerisiUC()
        {
            UCKreirajRacun = new UCKreirajRacun();
            UCKreirajRacun.button2.Click += Button2_Click;
            PopuniPodatke();
            return UCKreirajRacun;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(UCKreirajRacun.dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali firmu");
                return;
            }

            if (UCKreirajRacun.dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu firmu");
                return;
            }


            if (string.IsNullOrEmpty(UCKreirajRacun.textBox4.Text))
            {
                MessageBox.Show("Niste uneli broj racuna");
                return;
            }

            Racun racun = new Racun
            {
                Firma = (Firma)UCKreirajRacun.dataGridView2.SelectedRows[0].DataBoundItem,
                BrojRacuna = UCKreirajRacun.textBox4.Text,
                Banka = (Banka)UCKreirajRacun.comboBox1.SelectedItem
            };

            try
            {
                Kontroler.Instance.KreirajRacun(racun);
                MessageBox.Show("Sistem je uspesno kreirao racun");
            }catch(Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao racun: " + ex.Message);
            }

        }

        private void PopuniPodatke()
        {
            UCKreirajRacun.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajRacun.dataGridView2.DataSource = Kontroler.Instance.VratiFirme();
            UCKreirajRacun.comboBox1.DataSource = Kontroler.Instance.VratiBanke();
        }
    }
}
