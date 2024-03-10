using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class Dostavnica : IEntity
    {
        public int BrojDostavnice { get; set; }
        public Firma Firma { get; set; }
        public Zaposleni Isporucio { get; set; }
        public Zaposleni Primio { get; set; }
        public OrganizacionaJedinica OJPrimila { get; set; }
        public OrganizacionaJedinica OJIsporucila { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public List<StavkaDostavnice> Stavke { get; set; }
        public string ImeTabele => "DostavnicaView";

        public string UbaciVrednosti => $"{BrojDostavnice}, {Firma.MaticniBroj}, {Isporucio.ZaposleniId}, {Primio.ZaposleniId}, {OJIsporucila.OrganizacionaJedinicaId}, {OJPrimila.OrganizacionaJedinicaId}, '{DatumIzdavanja}'";

        public string IdName => "BrojDostavnice";

        public string JoinUslov => "";

        public string Alias => "d";

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
