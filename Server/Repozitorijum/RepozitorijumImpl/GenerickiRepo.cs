using Common.Domen;
using Server.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repozitorijum.RepozitorijumImpl
{
    internal class GenerickiRepo : IDBRepozitorijum<IEntity>
    {
        public void Close()
        {
            DBConnectionFactory.Instance.GetDbConnection().Close();
        }

        public void Commit()
        {
            DBConnectionFactory.Instance.GetDbConnection().Commit();
        }

        public void Rollback()
        {
            DBConnectionFactory.Instance.GetDbConnection().Rollback();
        }

        public int Dodaj(IEntity entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"insert into {entitet.ImeTabele} output inserted.{entitet.IdName} values ({entitet.UbaciVrednosti})");
            int newID = (int)command.ExecuteScalar();
            if (newID == null)
            {
                throw new Exception("Greska u bazi!");
            }
            return newID;
        }

        public void DodajView(IEntity entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"insert into {entitet.ImeTabele} values ({entitet.UbaciVrednosti})");
            command.ExecuteNonQuery();
        }

        public void Obrisi(IEntity entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"delete from {entitet.ImeTabele} where {entitet.WhereUslov}");
            command.ExecuteNonQuery();
        }

        public void Promeni(IEntity entitet)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"update {entitet.ImeTabele} set {entitet.UpdateVrednosti} where {entitet.WhereUslov}");
            command.ExecuteNonQuery();
        }

        public List<IEntity> VratiPoUslovu(IEntity entitet)
        {
            List<IEntity> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

        public IEntity VratiJednog(IEntity entitet)
        {
            IEntity pronadjeni = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov} where {entitet.WhereUslov};");
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                pronadjeni = entitet.VratiJednog(reader);
            }
            reader.Close();
            return pronadjeni;
        }

        public List<IEntity> VratiSve(IEntity entitet)
        {
            List<IEntity> entiteti = null;
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select {entitet.Select} from {entitet.ImeTabele} {entitet.Alias} {entitet.JoinUslov};");
            SqlDataReader reader = command.ExecuteReader();
            entiteti = entitet.VratiVise(reader);
            reader.Close();
            return entiteti;
        }

        public int VratiMax(string kolona, string imeTabele)
        {
            SqlCommand command = DBConnectionFactory.Instance.GetDbConnection().CreateCommand($"select max({kolona}) from {imeTabele}");
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if(reader.IsDBNull(0))
            {
                reader.Close();
                return 0;
            }
            int id = (int)reader[0];
            reader.Close();
            return id;
        }
    }
}
