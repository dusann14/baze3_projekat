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
    public class StavkaPrijemnice : IEntity
    {
        [Browsable(false)]
        public int BrojPrijemnice { get; set; }
        [Browsable(false)]
        public int IdStavke { get; set; }
        public double Jacina { get; set; }
        public int Kolicina { get; set; }
        public Materijal Materijal { get; set; }
        [Browsable(false)]
        public StatusStavkePrijemnice Status { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "StavkaPrijemnice";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojPrijemnice}, {IdStavke}, {Jacina}, {Kolicina}, {Materijal.Sifra}";
        [Browsable(false)]
        public string IdName => "BrojPrijemnice";
        [Browsable(false)]
        public string JoinUslov => "join Materijal m on (m.Sifra = sp.SifraMaterijala)";
        [Browsable(false)]
        public string Alias => "sp";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"Kolicina = {Kolicina}";

        public IEntity VratiJednog(SqlDataReader reader)
        {
            return null;
        }

        public List<IEntity> VratiVise(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();

            while (reader.Read())
            {
                entiteti.Add(new StavkaPrijemnice
                {
                    BrojPrijemnice = (int)reader[0],
                    IdStavke = (int)reader[1],
                    Jacina = (double)(decimal)reader[2],
                    Kolicina = (int)reader[3],
                    Materijal = new Materijal
                    {
                        Sifra = (int)reader[5],
                        Naziv = (string)reader[6]
                    },
                });
            }

            return entiteti;
        }
    }
    public enum StatusStavkePrijemnice
    {
        PROMENJEN,
        OBRISAN,
    }
}
