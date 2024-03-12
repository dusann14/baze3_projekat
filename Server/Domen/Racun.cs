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
    internal class Racun : IEntity
    {
        public Firma Firma { get; set; }
        public Banka Banka { get; set; }
        public string BrojRacuna { get; set; }
        public string ImeBanke { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Racun";
        [Browsable(false)]
        public string UbaciVrednosti => $"{Firma.MaticniBroj}, {Banka.IdBanke}, '{BrojRacuna}', ''";
        [Browsable(false)]
        public string IdName => "BrojRacuna";
        [Browsable(false)]
        public string JoinUslov => "join Firma f on (f.MaticniBroj = br.MaticniBroj) join Banka b on (b.IdBanke = br.IdBanke)";
        [Browsable(false)]
        public string Alias => "br";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"ImeBanke = '{ImeBanke}'";

        public IEntity VratiJednog(SqlDataReader reader)
        {
            return null;
        }

        public List<IEntity> VratiVise(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();

            while (reader.Read())
            {
                entiteti.Add(new Racun
                {
                    BrojRacuna = (string)reader[2],
                    ImeBanke = (string)reader[3],
                    Firma = new Firma
                    {
                        MaticniBroj = (int)reader[4],
                        PoslovnoIme = (string)reader[6]
                    },
                    Banka = new Banka
                    {
                        IdBanke = (int)reader[9],
                        ImeBanke = (string)reader[10]
                    }
                });
            }

            return entiteti;
        }
    }
}
