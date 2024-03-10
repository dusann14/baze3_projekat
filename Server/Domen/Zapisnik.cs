using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class Zapisnik : IEntity
    {
        public int BrojZapisnika { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public Faktura Faktura { get; set; }
        public Dostavnica Dostavnica { get; set; }
        public Otpremnica Otpremnica { get; set; }
        public Zaposleni Overio { get; set; }
        public OrganizacionaJedinica OrganizacionaJedinica { get; set; }
        public Firma Firma { get; set; }
        public string Aktivnost { get; set; }
        public string ImeTabele => "Zapisnik";

        public string UbaciVrednosti => $"{BrojZapisnika}, '{DatumIzdavanja}', {Faktura.BrojFakture}, {Dostavnica.BrojDostavnice}, {Otpremnica.BrojOtpremnice}, {Overio.ZaposleniId}, {OrganizacionaJedinica.OrganizacionaJedinicaId}, {Firma.MaticniBroj}, '{Aktivnost}'";

        public string IdName => "BrojZapisnika";

        public string JoinUslov => "";

        public string Alias => "zap";

        public string Select => "*";

        public string WhereUslov => "";

        public string UpdateVrednosti => "";

        public IEntity VratiJednog(SqlDataReader reader)
        {
            return null;
        }

        public List<IEntity> VratiVise(SqlDataReader reader)
        {
            return null;
        }
    }
}
