using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class OrganizacionaJedinica : IEntity
    {
        public int OrganizacionaJedinicaId { get; set; }
        public string Naziv { get; set; }
        public string ImeTabele => "OrganizacionaJedinica";

        public string UbaciVrednosti => "";

        public string IdName => "IdOrganizacionaJedinica";

        public string JoinUslov => "";

        public string Alias => "oj";

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
                entiteti.Add(new OrganizacionaJedinica
                {
                    OrganizacionaJedinicaId = (int)reader[0],
                    Naziv = (string)reader[1],
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
