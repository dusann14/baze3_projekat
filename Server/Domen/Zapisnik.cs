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
        public List<StavkaZapisnika> Stavke { get; set; }
        public string ImeTabele => "Zapisnik";

        public string UbaciVrednosti => $"{BrojZapisnika}, '{DatumIzdavanja}', {ValidacijaFaktura}, {ValidacijaDostavnica}, {ValidacijaOtpremnica}, {Overio.ZaposleniId}, {OrganizacionaJedinica.OrganizacionaJedinicaId}, {Firma.MaticniBroj}, '{Aktivnost}'";

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

        public string ValidacijaFaktura => Faktura is null ? "null" : Faktura.BrojFakture.ToString();
        public string ValidacijaOtpremnica => Otpremnica is null ? "null" : Otpremnica.BrojOtpremnice.ToString();
        public string ValidacijaDostavnica => Dostavnica is null ? "null" : Dostavnica.BrojDostavnice.ToString();
    }
}
