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
    public class StavkaOtpremnice : IEntity
    {
        [Browsable(false)]
        public int BrojOtpremnice { get; set; }
        [Browsable(false)]
        public int IdStavke { get; set; }
        public int Kolicina { get; set; }
        public string Jacina { get; set; }
        public Proizvod Prozivod { get; set; }
        [Browsable(false)]
        public string ImeTabele => "StavkaOtpremnice";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojOtpremnice}, {IdStavke}, {Kolicina}, {Jacina}, {Prozivod.ProzivodId}";
        [Browsable(false)]
        public string IdName => "BrojOtpremnice";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "so";
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
