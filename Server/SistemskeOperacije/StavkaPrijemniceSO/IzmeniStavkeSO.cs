using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.StavkaPrijemniceSO
{
    internal class IzmeniStavkeSO : SistemskaOperacijaBaza
    {
        private List<StavkaPrijemnice> stavkePrijemnice;

        public IzmeniStavkeSO(List<StavkaPrijemnice> stavkePrijemnice)
        {
            this.stavkePrijemnice = stavkePrijemnice;
        }

        protected override void Izvrsi()
        {
            foreach(StavkaPrijemnice stavkaPrijemnice in stavkePrijemnice)
            {
                stavkaPrijemnice.Uslov = $"IdStavke = {stavkaPrijemnice.IdStavke} and BrojPrijemnice = {stavkaPrijemnice.BrojPrijemnice}";
                if(stavkaPrijemnice.Status == StatusStavkePrijemnice.PROMENJEN)
                {
                    repozitorijum.Promeni(stavkaPrijemnice);
                }else if(stavkaPrijemnice.Status == StatusStavkePrijemnice.OBRISAN)
                {
                    repozitorijum.Obrisi(stavkaPrijemnice);
                }
            }
        }
    }
}
