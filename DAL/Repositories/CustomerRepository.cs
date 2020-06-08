using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteCustomer";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllCustomer";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdCustomer";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Customer entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertCustomer";

            var paramCustomerID = cmd.CreateParameter();
            paramCustomerID.ParameterName = "@CustomerID";
            paramCustomerID.Value = entity.CustomerID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CompanyName";
            paramName.Value = entity.CompanyName;

            var paramContactName = cmd.CreateParameter();
            paramContactName.ParameterName = "@ContactName";
            paramContactName.Value = entity.ContactName;

            var paramContactTitle = cmd.CreateParameter();
            paramContactTitle.ParameterName = "@ContactTitle";
            paramContactTitle.Value = entity.ContactTitle;

            var paramAddress = cmd.CreateParameter();
            paramAddress.ParameterName = "@Address";
            paramAddress.Value = entity.Address;

            var paramCity = cmd.CreateParameter();
            paramCity.ParameterName = "@City";
            paramCity.Value = entity.City;

            var paramRegion = cmd.CreateParameter();
            paramRegion.ParameterName = "@Region";
            paramRegion.Value = entity.Region;

            var paramPostalCode = cmd.CreateParameter();
            paramPostalCode.ParameterName = "@PostalCode";
            paramPostalCode.Value = entity.PostalCode;

            var paramCountry = cmd.CreateParameter();
            paramCountry.ParameterName = "@Country";
            paramCountry.Value = entity.Country;

            var paramPhone = cmd.CreateParameter();
            paramPhone.ParameterName = "@Phone";
            paramPhone.Value = entity.Phone;

            var paramFax = cmd.CreateParameter();
            paramFax.ParameterName = "@Fax";
            paramFax.Value = entity.Fax;

            cmd.Parameters.Add(paramCustomerID);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramContactName);
            cmd.Parameters.Add(paramContactTitle);
            cmd.Parameters.Add(paramAddress);
            cmd.Parameters.Add(paramCity);
            cmd.Parameters.Add(paramRegion);
            cmd.Parameters.Add(paramPostalCode);
            cmd.Parameters.Add(paramCountry);
            cmd.Parameters.Add(paramPhone);
            cmd.Parameters.Add(paramFax);
        }

        protected override Customer Map(DbDataReader reader)
        {
            Customer entity = new Customer();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.CustomerID = reader["CustomerID"].ToString();
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
                }
            }
            return entity;
        }

        protected override List<Customer> Maps(DbDataReader reader)
        {
            List<Customer> entityList = new List<Customer>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer entity = new Customer
                    {
                        CustomerID = reader["CustomerID"].ToString(),
                        CompanyName = reader["CompanyName"].ToString(),
                        ContactName = reader["ContactName"].ToString(),
                        ContactTitle = reader["ContactTitle"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        Region = reader["Region"].ToString(),
                        PostalCode = reader["PostalCode"].ToString(),
                        Country = reader["Country"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Fax = reader["Fax"].ToString(),
                    };
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Customer entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateCustomer";

            var paramCustomerID = cmd.CreateParameter();
            paramCustomerID.ParameterName = "@CustomerID";
            paramCustomerID.Value = entity.CustomerID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CompanyName";
            paramName.Value = entity.CompanyName;

            var paramContactName = cmd.CreateParameter();
            paramContactName.ParameterName = "@ContactName";
            paramContactName.Value = entity.ContactName;

            var paramContactTitle = cmd.CreateParameter();
            paramContactTitle.ParameterName = "@ContactTitle";
            paramContactTitle.Value = entity.ContactTitle;

            var paramAddress = cmd.CreateParameter();
            paramAddress.ParameterName = "@Address";
            paramAddress.Value = entity.Address;

            var paramCity = cmd.CreateParameter();
            paramCity.ParameterName = "@City";
            paramCity.Value = entity.City;

            var paramRegion = cmd.CreateParameter();
            paramRegion.ParameterName = "@Region";
            paramRegion.Value = entity.Region;

            var paramPostalCode = cmd.CreateParameter();
            paramPostalCode.ParameterName = "@PostalCode";
            paramPostalCode.Value = entity.PostalCode;

            var paramCountry = cmd.CreateParameter();
            paramCountry.ParameterName = "@Country";
            paramCountry.Value = entity.Country;

            var paramPhone = cmd.CreateParameter();
            paramPhone.ParameterName = "@Phone";
            paramPhone.Value = entity.Phone;

            var paramFax = cmd.CreateParameter();
            paramPhone.ParameterName = "@Fax";
            paramPhone.Value = entity.Fax;

            cmd.Parameters.Add(paramCustomerID);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramContactName);
            cmd.Parameters.Add(paramContactTitle);
            cmd.Parameters.Add(paramAddress);
            cmd.Parameters.Add(paramCity);
            cmd.Parameters.Add(paramRegion);
            cmd.Parameters.Add(paramPostalCode);
            cmd.Parameters.Add(paramCountry);
            cmd.Parameters.Add(paramPhone);
            cmd.Parameters.Add(paramFax);
        }
    }
}
