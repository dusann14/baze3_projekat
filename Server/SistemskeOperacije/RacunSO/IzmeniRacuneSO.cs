using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Server.SistemskeOperacije.RacunSO
{
    internal class IzmeniRacuneSO : SistemskaOperacijaBaza
    {
        private List<Racun> racuni;
        public IzmeniRacuneSO(List<Racun> racuni)
        {
            this.racuni = racuni;
        }

        protected override void Izvrsi()
        {
            foreach (Racun racun in racuni)
            {
                racun.Uslov = $"IdBanke = {racun.Banka.IdBanke} and MaticniBroj = {racun.Firma.MaticniBroj}";
                repozitorijum.Promeni(racun);
            }
        }
    }
}
