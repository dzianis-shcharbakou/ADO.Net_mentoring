using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class CustomerDemoRepository : BaseRepository<CustomerDemo>
    {
        public CustomerDemoRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteCustomerDemo";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllCustomerDemo";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdCustomerDemo";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(CustomerDemo entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertCustomerDemo";

            var paramCategoryID = cmd.CreateParameter();
            paramCategoryID.ParameterName = "@CustomerID";
            paramCategoryID.Value = entity.CategoryID;

            var paramCustomerTypeID = cmd.CreateParameter();
            paramCustomerTypeID.ParameterName = "@CustomerTypeID";
            paramCustomerTypeID.Value = entity.CustomerTypeID;

            cmd.Parameters.Add(paramCategoryID);
            cmd.Parameters.Add(paramCustomerTypeID);

        }

        protected override CustomerDemo Map(DbDataReader reader)
        {
            CustomerDemo entity = new CustomerDemo();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.CategoryID = reader["CustomerID"].ToString();
                    entity.CustomerTypeID = reader["CustomerTypeID"].ToString();
                }
            }
            return entity;
        }

        protected override List<CustomerDemo> Maps(DbDataReader reader)
        {
            List<CustomerDemo> entityList = new List<CustomerDemo>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustomerDemo entity = new CustomerDemo
                    {
                        CategoryID = reader["CustomerID"].ToString(),
                        CustomerTypeID = reader["CustomerTypeID"].ToString(),
                    };
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(CustomerDemo entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateCustomerDemo";

            var paramCategoryID = cmd.CreateParameter();
            paramCategoryID.ParameterName = "@CustomerID";
            paramCategoryID.Value = entity.CategoryID;

            var paramCustomerTypeID = cmd.CreateParameter();
            paramCustomerTypeID.ParameterName = "@CustomerTypeID";
            paramCustomerTypeID.Value = entity.CustomerTypeID;

            cmd.Parameters.Add(paramCategoryID);
            cmd.Parameters.Add(paramCustomerTypeID);
        }
    }
}
