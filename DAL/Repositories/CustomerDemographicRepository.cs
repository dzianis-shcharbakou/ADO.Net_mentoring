using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class CustomerDemographicRepository : BaseRepository<CustomerDemographic>
    {
        public CustomerDemographicRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }

        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteCustomerDemographic";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllCustomerDemographics";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdCustomerDemographic";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(CustomerDemographic entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertCustomerDemographic";

            var paramType = cmd.CreateParameter();
            paramType.ParameterName = "@CustomerTypeID";
            paramType.Value = entity.CustomerTypeID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@CustomerDesc";
            paramDescription.Value = entity.CustomerDesc;

            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramType);
        }

        protected override CustomerDemographic Map(DbDataReader reader)
        {
            CustomerDemographic entity = new CustomerDemographic();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.CustomerTypeID = reader["CustomerTypeID"].ToString();
                    entity.CustomerDesc = reader["CustomerDesc"].ToString();
                }
            }
            return entity;
        }

        protected override List<CustomerDemographic> Maps(DbDataReader reader)
        {
            List<CustomerDemographic> entityList = new List<CustomerDemographic>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustomerDemographic entity = new CustomerDemographic
                    {
                        CustomerTypeID = reader["CustomerTypeID"].ToString(),
                        CustomerDesc = reader["CustomerDesc"].ToString()
                    };
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(CustomerDemographic entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateCustomerDemographic";

            var paramType = cmd.CreateParameter();
            paramType.ParameterName = "@CustomerTypeID";
            paramType.Value = entity.CustomerTypeID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@CustomerDesc";
            paramDescription.Value = entity.CustomerDesc;

            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramType);
        }
    }
}
