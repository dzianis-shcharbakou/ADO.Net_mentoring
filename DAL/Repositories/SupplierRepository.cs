using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class SupplierRepository : BaseRepository<Supplier>
    {
        public SupplierRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteSupplier";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllSupplier";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdSupplier";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void InsertCommandParameters(Supplier entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertSupplier";

            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@CompanyName";
            param1.Value = entity.CompanyName;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@ContactName";
            param2.Value = entity.ContactName;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@ContactTitle";
            param3.Value = entity.ContactTitle;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@Address";
            param4.Value = entity.Address;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@City";
            param5.Value = entity.City;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@Region";
            param6.Value = entity.Region;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@PostalCode";
            param7.Value = entity.PostalCode;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@Country";
            param8.Value = entity.Country;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Phone";
            param9.Value = entity.Phone;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@Fax";
            param10.Value = entity.Fax;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@HomePage";
            param11.Value = entity.HomePage;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            cmd.Parameters.Add(param11);

        }

        protected override Supplier Map(DbDataReader reader)
        {
            Supplier entity = new Supplier();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.SupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                    entity.CompanyName = reader["CompanyName"].ToString();
                    entity.ContactName = reader["ContactName"].ToString();
                    entity.ContactTitle = reader["ContactTitle"].ToString();
                    entity.Address = reader["Address"].ToString();
                    entity.City = reader["City"].ToString();
                    entity.Region = reader["Region"].ToString();
                    entity.PostalCode = reader["PostalCode"].ToString();
                    entity.Country = reader["Country"].ToString();
                    entity.Phone = reader["Phone"].ToString();
                    entity.Fax = reader["Fax"].ToString();
                    entity.HomePage = reader["HomePage"].ToString();
                }
            }
            return entity;
        }

        protected override List<Supplier> Maps(DbDataReader reader)
        {
            List<Supplier> entityList = new List<Supplier>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Supplier entity = new Supplier();
                    entity.SupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                    entity.CompanyName = reader["CompanyName"].ToString();
                    entity.ContactName = reader["ContactName"].ToString();
                    entity.ContactTitle = reader["ContactTitle"].ToString();
                    entity.Address = reader["Address"].ToString();
                    entity.City = reader["City"].ToString();
                    entity.Region = reader["Region"].ToString();
                    entity.PostalCode = reader["PostalCode"].ToString();
                    entity.Country = reader["Country"].ToString();
                    entity.Phone = reader["Phone"].ToString();
                    entity.Fax = reader["Fax"].ToString();
                    entity.HomePage = reader["HomePage"].ToString();
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Supplier entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateSupplier";

            var param12 = cmd.CreateParameter();
            param12.ParameterName = "@SupplierID";
            param12.Value = entity.SupplierID;

            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@CompanyName";
            param1.Value = entity.CompanyName;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@ContactName";
            param2.Value = entity.ContactName;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@ContactTitle";
            param3.Value = entity.ContactTitle;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@Address";
            param4.Value = entity.Address;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@City";
            param5.Value = entity.City;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@Region";
            param6.Value = entity.Region;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@PostalCode";
            param7.Value = entity.PostalCode;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@Country";
            param8.Value = entity.Country;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Phone";
            param9.Value = entity.Phone;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@Fax";
            param10.Value = entity.Fax;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@HomePage";
            param11.Value = entity.HomePage;

            cmd.Parameters.Add(param12);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            cmd.Parameters.Add(param11);
        }
    }

}
