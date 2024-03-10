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
    public class Faktura : IEntity
    {
        public int BrojFakture { get; set; }
        public double UkupnoPDV { get; set; }
        public string PozivNaBroj { get; set; }
        public double UkupanIznos { get; set; }
        public string Napomena { get; set; }
        public Firma Prodavac { get; set; }
        [Browsable(false)]
        public Firma Kupac { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public Valuta Valuta { get; set; }
        [Browsable(false)]
        public List<StavkaFakture> Stavke { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string Update { get; set; }
        [Browsable(false)]
        public string ImeTabele => "FakturaView";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojFakture}, {UkupnoPDV}, '{PozivNaBroj}', {UkupanIznos}, '{Napomena}', {Valuta.ValutaId}, {Prodavac.MaticniBroj}, {Kupac.MaticniBroj}, '{DatumIzdavanja}'";
        [Browsable(false)]
        public string IdName => "BrojFakture";
        [Browsable(false)]
        public string JoinUslov => "join Firma fi on (fi.MaticniBroj = f.Kupac) join Valuta v on (v.IdValute = f.IdValute)";
        [Browsable(false)]
        public string Alias => "f";
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
                entiteti.Add(new Faktura
                {
                    BrojFakture = (int)reader[0],
                    UkupnoPDV = (double)(decimal)reader[1],
                    PozivNaBroj = (string)reader[2],
                    UkupanIznos = (double)(decimal)reader[3],
                    Napomena = (string)reader[4],
                    DatumIzdavanja = (DateTime)reader[8],
                    Prodavac = new Firma
                    {
                        MaticniBroj = (int)reader[9],
                        Adresa = (string)reader[10],
                        PoslovnoIme = (string)reader[11],
                        PIB = (string)reader[12],
                    },
                    Valuta = new Valuta
                    {
                        ValutaId = (int)reader[14],
                        Zapis = (string)reader[15]
                    }
                });
            }

            return entiteti;
        }
    }
}
