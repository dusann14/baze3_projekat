﻿using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domen
{
    public class JedinicaMere : IEntity
    {
        public int JedinicaId { get; set; }
        public string Naziv { get; set; }
        public string ImeTabele => "JedinicaMere";

        public string UbaciVrednosti => "";

        public string IdName => "IdJedinice";

        public string JoinUslov => "";

        public string Alias => "jm";

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
                entiteti.Add(new JedinicaMere
                {
                    JedinicaId = (int)reader[0],
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
