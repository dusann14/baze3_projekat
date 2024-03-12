using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class StavkaZapisnika : IEntity
    {
        [Browsable(false)]
        public int BrojZapisnika { get; set; }
        [Browsable(false)]
        public int IdStavke { get; set; }
        public int Kolicina { get; set; }
        public Materijal Materijal { get; set; }
        [Browsable(false)]
        public string ImeTabele => "StavkaZapisnika";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojZapisnika}, {IdStavke}, {Kolicina}, {Materijal.Sifra}";
        [Browsable(false)]
        public string IdName => "BrojZapisnika";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "sz";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => "";
        [Browsable(false)]
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
