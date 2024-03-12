using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.KontroleriForme
{
    public class KontrolerForme
    {
        public Klijent Forma { get; set; }
        internal Klijent NapraviGlavnuFormu()
        {
            Forma = new Klijent();
            Forma.WindowState = FormWindowState.Maximized;
            Forma.FormBorderStyle = FormBorderStyle.Sizable;
            Forma.StartPosition = FormStartPosition.CenterScreen;
            Forma.kreirajFakturuToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriKreirajFakturu();
            };
            Forma.pretragaFakturaToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCPretragaFaktura();
            };
            Forma.kreirajDostavnicuToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCKreirajDostavnicu();
            };

            Forma.kreirajOtpremnicuToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCKreirajOtpremnicu();
            };
            Forma.kreirajZapisnikToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCKreirajZapisnik();
            };
            Forma.kreirajPrijemnicuToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCKreirajPrijemnicu();
            };
            Forma.pretragaPrijemnicaToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCPretragaPrijemnica();
            };
            Forma.kreirajRacunToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCKreirajRacun();
            };
            Forma.pretragaRacunaToolStripMenuItem.Click += (s, e) =>
            {
                Koordinator.Instance.OtvoriUCPretragaRacuna();
            };
            Forma.FormClosed += OdjaviSe;
            return Forma;
        }

        internal void OdjaviSe(object sender, FormClosedEventArgs e)
        {
            try
            {
                MessageBox.Show("Uspesno ste se odjavili");
                Forma.Dispose();
                Session.Instance.Zaposleni = null;
                Koordinator.Instance.OtvoriLoginFormu();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }
    }
}
