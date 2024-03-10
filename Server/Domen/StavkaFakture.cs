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
    public class StavkaFakture : IEntity
    {
        [Browsable(false)]
        public int BrojFakture { get; set; }
        [Browsable(false)]
        public int IdStavke { get; set; }
        public Materijal Materijal { get; set; }
        [Browsable(false)]
        public double UkupanIznos { get; set; }
        public double IznosBezPDV { get; set; }
        public int Kolicina { get; set; }
        public decimal JedinicnaCena { get; set; }
        public decimal PDV { get; set; }
        public decimal Popust { get; set; }

        [Browsable(false)]
        public string Update { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string ImeTabele => "StavkaFakture";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojFakture}, {IdStavke}, {UkupanIznos}, {IznosBezPDV}, {Kolicina}, {JedinicnaCena}, {PDV}, {Popust}, CONVERT(KalkulatorPorezaTip, '{Kolicina},{JedinicnaCena},{PDV},{Popust}'), {Materijal.Sifra}";
        [Browsable(false)]
        public string IdName => "BrojFakture";
        [Browsable(false)]
        public string JoinUslov => "join Materijal m on (m.Sifra = sf.SifraMaterijala) join JedinicaMere jm on (jm.IdJedinice = m.JedinicaMere)";
        [Browsable(false)]
        public string Alias => "sf";
        [Browsable(false)]
        public string Select => "*";
        [Browsable(false)]
        public string WhereUslov => $"{Uslov}";
        [Browsable(false)]
        public string UpdateVrednosti => $"{Update}";

        public IEntity VratiJednog(SqlDataReader reader)
        {
            return null;
        }

        public List<IEntity> VratiVise(SqlDataReader reader)
        {
            List<IEntity> entiteti = new List<IEntity>();

            while (reader.Read())
            {
                entiteti.Add(new StavkaFakture
                {
                    BrojFakture = (int)reader[0],
                    IznosBezPDV = (double)(decimal)reader[3],
                    Kolicina = (int)reader[4],
                    JedinicnaCena = (decimal)reader[5],
                    Popust = (decimal)reader[6],
                    PDV = (decimal)reader[7],
                    Materijal = new Materijal
                    {
                        Sifra = (int)reader[10],
                        Naziv = (string)reader[11],
                        JedinicaMere = new JedinicaMere
                        {
                            JedinicaId = (int)reader[14],
                            Naziv = (string)reader[15]
                        }
                    }
                });
            }

            return entiteti;
        }
    }
}
