using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Windows.Forms;
using Common.Domen;
using Server.Domen;
using Server;

namespace Klijent.KontroleriForme
{
    public class LoginKontroler
    {
        public Login Forma { get; set; }

        public Login NapraviLoginFormu()
        {
            Forma = new Login();
            Forma.StartPosition = FormStartPosition.CenterScreen;
            Forma.button1.Click += Button1_Click;
            return Forma;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Forma.textBox1.Text) || string.IsNullOrEmpty(Forma.textBox2.Text))
            {
                MessageBox.Show("Niste uneli korisnicko ime ili lozinku");
                return;
            }

            Zaposleni zaposleni = new Zaposleni
            {
                KorisnickoIme = Forma.textBox1.Text,
                Lozinka = Forma.textBox2.Text,
            };

            zaposleni = Kontroler.Instance.Prijava(zaposleni);

            if(zaposleni == null)
            {
                MessageBox.Show("Zaposleni sa unetim kredencijalima ne postoji");
                return;
            }

            Session.Instance.Zaposleni = zaposleni;
            Forma.Dispose();
            Koordinator.Instance.OtvoriGlavnuFormu();
        }
    }
}
