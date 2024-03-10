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
    public class Materijal : IEntity
    {
        [Browsable(false)]
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public JedinicaMere JedinicaMere { get; set; }
        public VrstaFlase VrstaFlase { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Materijal";
        [Browsable(false)]
        public string UbaciVrednosti => "";
        [Browsable(false)]
        public string IdName => "Sifra";
        [Browsable(false)]
        public string JoinUslov => "join JedinicaMere jm on (m.JedinicaMere = jm.IdJedinice) join VrstaFlase vf on (m.VrstaFlase = vf.IdFlase)";
        [Browsable(false)]
        public string Alias => "m";
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
                entiteti.Add(new Materijal
                {
                    Sifra = (int)reader[0],
                    Naziv = (string)reader[1],
                    JedinicaMere = new JedinicaMere
                    {
                        JedinicaId = (int)reader[4],
                        Naziv = (string)reader[5],
                    },
                    VrstaFlase = new VrstaFlase
                    {
                        IdFlase = (int)reader[6],
                        Naziv = (string)reader[7],
                    }
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{Naziv}, Sifra {Sifra}";
        }
    }
}
