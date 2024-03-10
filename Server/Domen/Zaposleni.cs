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
    public class Zaposleni : IEntity
    {
        [Browsable(false)]
        public int ZaposleniId { get; set; }
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
        [Browsable(false)]
        public string Lozinka { get; set; }
        public OrganizacionaJedinica OrganizacionaJedinica { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Zaposleni";
        [Browsable(false)]
        public string UbaciVrednosti => "";
        [Browsable(false)]
        public string IdName => "IdZaposlenog";
        [Browsable(false)]
        public string JoinUslov => "join OrganizacionaJedinica o on (z.OrganizacionaJedinica = o.IdJedinice)";
        [Browsable(false)]
        public string Alias => "z";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => "";

        public IEntity VratiJednog(SqlDataReader reader)
        {
            return new Zaposleni
            {
                ZaposleniId = (int)reader[0],
                ImePrezime = (string)reader[1],
                KorisnickoIme = (string)reader[4],
                OrganizacionaJedinica = new OrganizacionaJedinica
                {
                    OrganizacionaJedinicaId = (int)reader[5],
                    Naziv = (string)reader[6]
                }
            };
        }

        public List<IEntity> VratiVise(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();

            while (reader.Read())
            {
                entiteti.Add(new Zaposleni
                {
                    ZaposleniId = (int)reader[0],
                    ImePrezime = (string)reader[1],
                    KorisnickoIme = (string)reader[4],
                    OrganizacionaJedinica = new OrganizacionaJedinica
                    {
                        OrganizacionaJedinicaId = (int)reader[5],
                        Naziv = (string)reader[6]
                    }
                });
            }

            return entiteti;
        }
    }
}
