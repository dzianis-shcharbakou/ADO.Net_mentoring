using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ADO.Net.Repositories
{
    class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        public OrderDetailRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }
        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteOrderDetail";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllOrderDetail";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdOrderDetail";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);

        }

        protected override void InsertCommandParameters(OrderDetail entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertOrderDetail";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@OrderID";
            paramName.Value = entity.OrderID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@ProductID";
            paramDescription.Value = entity.ProductID;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@UnitPrice";
            paramPicture.Value = entity.UnitPrice;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@Quantity";
            param2.Value = entity.Quantity;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@Discount";
            param3.Value = entity.Discount;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);

        }

        protected override OrderDetail Map(DbDataReader reader)
        {
            OrderDetail entity = new OrderDetail();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                    entity.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    entity.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    entity.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    entity.Discount = Convert.ToInt32(reader["Discount"].ToString());
                }
            }
            return entity;
        }

        protected override List<OrderDetail> Maps(DbDataReader reader)
        {
            List<OrderDetail> entityList = new List<OrderDetail>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    OrderDetail entity = new OrderDetail();
                    entity.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                    entity.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                    entity.UnitPrice = Convert.ToDecimal(reader["UnitPrice"].ToString());
                    entity.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    entity.Discount = Convert.ToInt32(reader["Discount"].ToString());
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(OrderDetail entity, DbCommand cmd)
        {
            cmd.CommandText = "UpdateOrderDetail";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@OrderID";
            paramName.Value = entity.OrderID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@ProductID";
            paramDescription.Value = entity.ProductID;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@UnitPrice";
            paramPicture.Value = entity.UnitPrice;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@Quantity";
            param2.Value = entity.Quantity;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@Discount";
            param3.Value = entity.Discount;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
        }
    }
}
