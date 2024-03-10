using Klijent.KontroleriForme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Koordinator
    {
        public Klijent KlijentForma { get; set; }

        public Login LoginForma { get; set; }

        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }

        }

        private Koordinator()
        {
            loginKontroler = new LoginKontroler();
            kontrolerForme = new KontrolerForme();
        }

        private LoginKontroler loginKontroler;
        private KontrolerForme kontrolerForme;

        internal void OtvoriLoginFormu()
        {
            try
            {
                Komunikacija.Instance.PoveziSe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da se poveze na server");
                return;
            }
            
            LoginForma = loginKontroler.NapraviLoginFormu();
            LoginForma.ShowDialog();
        }

        internal void OtvoriGlavnuFormu()
        {
            KlijentForma = kontrolerForme.NapraviGlavnuFormu();
            KlijentForma.ShowDialog();
        }
    }
}
