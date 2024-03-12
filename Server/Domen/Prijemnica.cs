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
    public class Prijemnica : IEntity
    {
        public int BrojPrijemnice { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string PrevoznoSredstvo { get; set; }
        public string Napomena { get; set; }
        [Browsable(false)]
        public int UkupnaKolicina { get; set; }
        [Browsable(false)]
        public Faktura Faktura { get; set; }
        [Browsable(false)]
        public Dostavnica Dostavnica { get; set; }
        [Browsable(false)]
        public Otpremnica Otpremnica { get; set; }
        [Browsable(false)]
        public Zaposleni Isporucio { get; set; }
        public Zaposleni Primio { get; set; }
        public OrganizacionaJedinica OrganizacionaJedinica { get; set; }
        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public List<StavkaPrijemnice> Stavke { get; set; }
        [Browsable(false)]
        public Firma Firma { get; set; }
        [Browsable(false)]
        public string ImeTabele => "Prijemnica";
        [Browsable(false)]
        public string UbaciVrednosti => $"{BrojPrijemnice}, '{DatumIzdavanja}', '{PrevoznoSredstvo}', '{Napomena}', {UkupnaKolicina}, {ValidacijaFaktura}, {ValidacijaDostavnica}, {ValidacijaOtpremnica}, {Isporucio.ZaposleniId}, {Primio.ZaposleniId}, {OrganizacionaJedinica.OrganizacionaJedinicaId}, {Firma.MaticniBroj}";
        [Browsable(false)]
        public string IdName => "BrojPrijemnice";
        [Browsable(false)]
        public string JoinUslov => "join Zaposleni z on (z.IdZaposlenog = p.ZaposleniPrimio) join OrganizacionaJedinica o on (o.IdJedinice = p.OrganizacionaJedinica)";
        [Browsable(false)]
        public string Alias => "p";
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
                entiteti.Add(new Prijemnica
                {
                    BrojPrijemnice = (int)reader[0],
                    DatumIzdavanja = (DateTime)reader[1],
                    PrevoznoSredstvo = (string)reader[2],
                    Napomena = (string)reader[3],
                    Primio = new Zaposleni
                    {
                        ZaposleniId = (int)reader[12],
                        ImePrezime = (string)reader[13]
                    },
                    OrganizacionaJedinica = new OrganizacionaJedinica
                    {
                        OrganizacionaJedinicaId = (int)reader[17],
                        Naziv = (string)reader[18]
                    }
                });
            }

            return entiteti;
        }
        [Browsable(false)]
        public string ValidacijaFaktura => Faktura is null ? "null" : Faktura.BrojFakture.ToString();
        [Browsable(false)]
        public string ValidacijaOtpremnica => Otpremnica is null ? "null" : Otpremnica.BrojOtpremnice.ToString();
        [Browsable(false)]
        public string ValidacijaDostavnica => Dostavnica is null ? "null" : Dostavnica.BrojDostavnice.ToString();
    }
}
