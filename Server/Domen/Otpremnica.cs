using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class Otpremnica : IEntity
    {
        public int BrojOtpremnice { get; set; }
        public string Napomena { get; set; }
        public Firma Izdala { get; set; }
        public Firma Kupila { get; set; }
        public Zaposleni Isporucio { get; set; }
        public Zaposleni Primio { get; set; }
        public OrganizacionaJedinica OJIzdala { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public List<StavkaOtpremnice> Stavke { get; set; }
        public string ImeTabele => "OtpremnicaView";

        public string UbaciVrednosti => $"{BrojOtpremnice}, '{Napomena}', {Izdala.MaticniBroj}, {Kupila.MaticniBroj}, {Isporucio.ZaposleniId}, {Primio.ZaposleniId}, {OJIzdala.OrganizacionaJedinicaId}, '{DatumIzdavanja}'";

        public string IdName => "BrojOtpremnice";

        public string JoinUslov => "";

        public string Alias => "o";

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
