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
    public class StavkaDostavnice : IEntity
    {
        [Browsable(false)]
        public int BrojDostavnice { get; set; }
        [Browsable(false)]
        public int IdStavke { get; set; }
        public int Kolicina { get; set; }
        public string Jacina { get; set; }
        public Materijal Materijal { get; set; }
        [Browsable(false)]
        public string ImeTabele => "StavkaDostavnice";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojDostavnice}, {IdStavke}, {Kolicina}, '{Jacina}', {Materijal.Sifra}";
        [Browsable(false)]
        public string IdName => "BrojDostavnice";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "sd";
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
