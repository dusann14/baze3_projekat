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
    internal class KontrolerUCKreirajFakturu
    {
        public UCKreirajFakturu UCKreirajFakturu { get; set; }
        private BindingList<StavkaFakture> dodateStavke = new BindingList<StavkaFakture>();

        public UCKreirajFakturu GenerisiUC()
        {
            UCKreirajFakturu = new UCKreirajFakturu();
            UCKreirajFakturu.button1.Click += Button1_Click;
            UCKreirajFakturu.button2.Click += Button2_Click;
            UCKreirajFakturu.button3.Click += Button3_Click;
            PostaviPodatke();
            return UCKreirajFakturu;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            StavkaFakture stavka = (StavkaFakture)UCKreirajFakturu.dataGridView3.SelectedRows[0].DataBoundItem;
            dodateStavke.Remove(stavka);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Materijal materijal = (Materijal)UCKreirajFakturu.dataGridView2.SelectedRows[0].DataBoundItem;

            StavkaFakture stavka = new StavkaFakture
            {
                Materijal = materijal,
                Kolicina = int.Parse(UCKreirajFakturu.textBox4.Text),
                JedinicnaCena = decimal.Parse(UCKreirajFakturu.textBox5.Text),
                PDV = decimal.Parse(UCKreirajFakturu.textBox7.Text),
                Popust = decimal.Parse(UCKreirajFakturu.textBox6.Text),
                BrojFakture = int.Parse(UCKreirajFakturu.textBox1.Text),
            };

            dodateStavke.Add(stavka);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(dodateStavke.Count == 0)
            {
                MessageBox.Show("Niste dodali stavke");
                return;
            }

            Valuta valuta = (Valuta)UCKreirajFakturu.comboBox1.SelectedItem;

            Firma prodavac = (Firma)UCKreirajFakturu.dataGridView1.SelectedRows[0].DataBoundItem;

            Faktura faktura = new Faktura
            {
                Stavke = dodateStavke.ToList(),
                BrojFakture = int.Parse(UCKreirajFakturu.textBox1.Text),
                PozivNaBroj = UCKreirajFakturu.textBox2.Text,
                Napomena = UCKreirajFakturu.textBox3.Text,
                Valuta = valuta,
                Prodavac = prodavac,
                Kupac = Session.Instance.Navip,
                DatumIzdavanja = DateTime.Now,
            };

            try
            {
                Kontroler.Instance.KreirajFakturu(faktura);
                MessageBox.Show("Sistem je uspesno kreirao fakturu");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sistem nije uspesno kreirao fakturu");
            }
        }

        private void PostaviPodatke()
        {
            UCKreirajFakturu.comboBox1.DataSource = Kontroler.Instance.VratiValute();
            UCKreirajFakturu.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajFakturu.dataGridView1.DataSource = Kontroler.Instance.VratiFirme();
            UCKreirajFakturu.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajFakturu.dataGridView2.DataSource = Kontroler.Instance.VratiMaterijale();
            UCKreirajFakturu.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCKreirajFakturu.dataGridView3.DataSource = dodateStavke;
        }
    }
}
