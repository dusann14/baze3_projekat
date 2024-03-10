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
    public class Proizvod : IEntity
    {
        [Browsable(false)]
        public int ProzivodId { get; set; }
        public string Naziv { get; set; }
        public VrstaFlase VrstaFlase { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Proizvod";
        [Browsable(false)]
        public string UbaciVrednosti => "";
        [Browsable(false)]
        public string IdName => "ProzivodId";
        [Browsable(false)]
        public string JoinUslov => "join VrstaFlase vf on (vf.IdFlase = p.VrstaFlase)";
        [Browsable(false)]
        public string Alias => "p";
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
                entiteti.Add(new Proizvod
                {
                    ProzivodId = (int)reader[0],
                    Naziv = (string)reader[1],
                    VrstaFlase = new VrstaFlase
                    {
                        IdFlase = (int)reader[3],
                        Naziv = (string)reader[4],
                    }
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }
    }
}
