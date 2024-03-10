using Server.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.KontroleriForme.UCKontroleri
{
    internal class KontrolerUCKreirajZapisnik
    {
        public UCKreirajZapisnik UCKreirajZapisnik { get; set; }

        public UCKreirajZapisnik GenerisiUC()
        {
            UCKreirajZapisnik = new UCKreirajZapisnik();
            return UCKreirajZapisnik;
        }
    }
}
