using Server.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SistemskeOperacije.BankaSO
{
    internal class IzmeniBankeSO : SistemskaOperacijaBaza
    {
        private List<Banka> banke;
        public IzmeniBankeSO(List<Banka> banke)
        {
            this.banke = banke;
        }

        protected override void Izvrsi()
        {
            foreach(Banka banka in banke)
            {
                banka.Uslov = $"IdBanke = {banka.IdBanke}";
                repozitorijum.Promeni(banka);
            }
        }
    }
}
