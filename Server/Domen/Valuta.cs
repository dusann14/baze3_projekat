using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class Valuta : IEntity
    {
        public int ValutaId { get; set; }
        public string Zapis { get; set; }
        public string ImeTabele => "Valuta";

        public string UbaciVrednosti => "";

        public string IdName => "IdValute";

        public string JoinUslov => "";

        public string Alias => "v";

        public string Select => "*";

        public string WhereUslov => "";

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
                entiteti.Add(new Valuta
                {
                    ValutaId = (int)reader[0],
                    Zapis = (string)reader[1],
                });
            }

            return entiteti;
        }

        public override string ToString()
        {
            return $"{Zapis}";
        }
    }
}
