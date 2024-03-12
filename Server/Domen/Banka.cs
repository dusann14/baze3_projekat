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
    internal class Banka : IEntity
    {
        [Browsable(false)]
        public int IdBanke { get; set; }
        public string ImeBanke { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Banka";
        [Browsable(false)]
        public string UbaciVrednosti => $"{IdBanke}, '{ImeBanke}'";
        [Browsable(false)]
        public string IdName => "IdBanke";
        [Browsable(false)]
        public string JoinUslov => "";
        [Browsable(false)]
        public string Alias => "ba";
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
                entiteti.Add(new Banka
                {
                    IdBanke = (int)reader[0],
                    ImeBanke = (string)reader[1],
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{ImeBanke}";
        }
    }
}
