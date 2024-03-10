using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class StavkaZapisnika : IEntity
    {
        public int BrojZapisnika { get; set; }
        public int IdStavke { get; set; }
        public int Kolicina { get; set; }
        public Materijal Materijal { get; set; }
        public string ImeTabele => "StavkaZapisnika";

        public string UbaciVrednosti => $"{BrojZapisnika}, {IdStavke}, {Kolicina}, {Materijal.Sifra}";

        public string IdName => "BrojZapisnika";

        public string JoinUslov => "";

        public string Alias => "sz";

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
