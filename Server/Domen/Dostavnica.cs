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
    public class Dostavnica : IEntity
    {
        public int BrojDostavnice { get; set; }
        [Browsable(false)]
        public Firma Firma { get; set; }
        [Browsable(false)]
        public Zaposleni Isporucio { get; set; }
        [Browsable(false)]
        public Zaposleni Primio { get; set; }
        [Browsable(false)]
        public OrganizacionaJedinica OJPrimila { get; set; }
        [Browsable(false)]
        public OrganizacionaJedinica OJIsporucila { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        [Browsable(false)]
        public List<StavkaDostavnice> Stavke { get; set; }
        [Browsable(false)]
        public string ImeTabele => "DostavnicaView";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojDostavnice}, {Firma.MaticniBroj}, {Isporucio.ZaposleniId}, {Primio.ZaposleniId}, {OJIsporucila.OrganizacionaJedinicaId}, {OJPrimila.OrganizacionaJedinicaId}, '{DatumIzdavanja}'";
        [Browsable(false)]
        public string IdName => "BrojDostavnice";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "d";
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
                entiteti.Add(new Dostavnica
                {
                    BrojDostavnice = (int)reader[0],
                    DatumIzdavanja = (DateTime)reader[6],
                });
            }

            return entiteti;
        }


        public override string ToString()
        {
            return $"{BrojDostavnice}";
        }
    }
}
