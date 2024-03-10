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
    public class Firma : IEntity
    {
        public int MaticniBroj { get; set; }
        public string Adresa { get; set; }
        public string PoslovnoIme { get; set; }
        public string PIB { get; set; }
        public Grad Grad { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Firma";
        [Browsable(false)]
        public string UbaciVrednosti => "";
        [Browsable(false)]
        public string IdName => "MaticniBroj";
        [Browsable(false)]
        public string JoinUslov => "join Grad g on (g.PostanskiBroj = fi.PostanskiBroj)";
        [Browsable(false)]
        public string Alias => "fi";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
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
                entiteti.Add(new Firma
                {
                    MaticniBroj = (int)reader[0],
                    Adresa = (string)reader[1],
                    PoslovnoIme = (string)reader[2],
                    PIB = (string)reader[3],
                    Grad = new Grad
                    {
                        PostanskiBroj = (int)reader[5],
                        Naziv = (string)reader[6]
                    }
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{PoslovnoIme}";
        }
    }
}
