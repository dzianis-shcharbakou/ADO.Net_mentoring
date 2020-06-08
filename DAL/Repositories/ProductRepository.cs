using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteProduct";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllProduct";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdProduct";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void InsertCommandParameters(Product entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertProduct";

            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@ProductName";
            param1.Value = entity.ProductName;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@SupplierID";
            param2.Value = entity.SupplierID;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@CategoryID";
            param3.Value = entity.CategoryID;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@QuantityPerUnit";
            param4.Value = entity.QuantityPerUnit;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@UnitPrice";
            param5.Value = entity.UnitPrice;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@UnitsInStock";
            param6.Value = entity.UnitsInStock;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@UnitsOnOrder";
            param7.Value = entity.UnitsOnOrder;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@ReorderLevel";
            param8.Value = entity.ReorderLevel;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Discontinued";
            param9.Value = entity.Discontinued;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);

        }

        protected override Product Map(DbDataReader reader)
        {
            Product entity = new Product();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    entity.ProductName = reader["ProductName"].ToString();
                    entity.SupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                    entity.CategoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    entity.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    entity.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    entity.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"].ToString());
                    entity.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"].ToString());
                    entity.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"].ToString());
                    entity.Discontinued = Convert.ToInt32(reader["Discontinued"].ToString());
                }
            }
            return entity;
        }

        protected override List<Product> Maps(DbDataReader reader)
        {
            List<Product> entityList = new List<Product>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product entity = new Product();
                    entity.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    entity.ProductName = reader["ProductName"].ToString();
                    entity.SupplierID = Convert.ToInt32(reader["SupplierID"].ToString());
                    entity.CategoryID = Convert.ToInt32(reader["CategoryID"].ToString());
                    entity.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    entity.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    entity.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"].ToString());
                    entity.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"].ToString());
                    entity.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"].ToString());
                    entity.Discontinued = Convert.ToInt32(reader["Discontinued"].ToString());
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Product entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateProduct";

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@ProductID";
            param10.Value = entity.ProductID;

            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@ProductName";
            param1.Value = entity.ProductName;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@SupplierID";
            param2.Value = entity.SupplierID;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@CategoryID";
            param3.Value = entity.CategoryID;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@QuantityPerUnit";
            param4.Value = entity.QuantityPerUnit;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@UnitPrice";
            param5.Value = entity.UnitPrice;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@UnitsInStock";
            param6.Value = entity.UnitsInStock;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@UnitsOnOrder";
            param7.Value = entity.UnitsOnOrder;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@ReorderLevel";
            param8.Value = entity.ReorderLevel;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@Discontinued";
            param9.Value = entity.Discontinued;

            cmd.Parameters.Add(param10);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
        }
    }
}
