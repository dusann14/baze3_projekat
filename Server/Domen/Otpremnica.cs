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
    public class Otpremnica : IEntity
    {
        public int BrojOtpremnice { get; set; }
        [Browsable(false)]
        public string Napomena { get; set; }
        [Browsable(false)]
        public Firma Izdala { get; set; }
        [Browsable(false)]
        public Firma Kupila { get; set; }
        [Browsable(false)]
        public Zaposleni Isporucio { get; set; }
        [Browsable(false)]
        public Zaposleni Primio { get; set; }
        [Browsable(false)]
        public OrganizacionaJedinica OJIzdala { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        [Browsable(false)]
        public List<StavkaOtpremnice> Stavke { get; set; }
        [Browsable(false)]
        public string ImeTabele => "OtpremnicaView";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojOtpremnice}, '{Napomena}', {Izdala.MaticniBroj}, {Kupila.MaticniBroj}, {Isporucio.ZaposleniId}, {Primio.ZaposleniId}, {OJIzdala.OrganizacionaJedinicaId}, '{DatumIzdavanja}'";
        [Browsable(false)]
        public string IdName => "BrojOtpremnice";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "o";
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
            List<IEntity> entiteti = new List<IEntity>();

            while (reader.Read())
            {
                entiteti.Add(new Otpremnica
                {
                    BrojOtpremnice = (int)reader[0],
                    DatumIzdavanja = (DateTime)reader[7],
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{BrojOtpremnice}";
        }
    }
}
