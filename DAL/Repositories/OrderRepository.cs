using ADO.Net.Models;
using ADO.Net.Repositories.Abstract;
using DAL.Models.StoredProcedureModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Net.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {

        }

        #region CustOrderDetails
        public List<CustOrderDetails> CustOrderDetails(int orderId)
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetCustOrderDetailsCommandParameters(orderId, cmd);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        var result = CustOrderDetailsMaps(reader);
                        return result;
                    }
                }
            }
        }

        private void GetCustOrderDetailsCommandParameters(int orderID, DbCommand cmd)
        {
            cmd.CommandText = "CustOrdersDetail";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@OrderID";
            paramId.Value = orderID;

            cmd.Parameters.Add(paramId);
        }

        private List<CustOrderDetails> CustOrderDetailsMaps(DbDataReader reader)
        {
            List<CustOrderDetails> entityList = new List<CustOrderDetails>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustOrderDetails entity = new CustOrderDetails();
                    entity.ProductName = reader["ProductName"].ToString();
                    entity.UnitPrice = (decimal)reader["UnitPrice"];
                    entity.Quantity = (Int16)reader["Quantity"];
                    entity.Discount = (int)reader["Discount"];
                    entity.ExtendedPrice = (decimal)reader["ExtendedPrice"];

                    entityList.Add(entity);
                }
            }
            return entityList;
        }
        #endregion

        #region CustOrderHist
        public List<CustOrderHist> CustOrderHist(string customerId)
        {
            if (customerId == null)
            {
                throw new Exception("Set customer id");
            }

            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetCustOrderHistCommandParameters(customerId, cmd);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        var result = CustOrderHistMaps(reader);
                        return result;
                    }
                }
            }
        }

        private List<CustOrderHist> CustOrderHistMaps(DbDataReader reader)
        {
            List<CustOrderHist> entityList = new List<CustOrderHist>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustOrderHist entity = new CustOrderHist();
                    entity.ProductName = reader["ProductName"].ToString();
                    entity.Total = (int)reader["Total"];

                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        private void GetCustOrderHistCommandParameters(string customerID, DbCommand cmd)
        {
            cmd.CommandText = "CustOrderHist";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@CustomerID";
            paramId.Value = customerID;

            cmd.Parameters.Add(paramId);
        }
        #endregion


        #region ChangeStatus
        public void ChangeStatusToComplete(Order order)
        {
            if (order.Status != OrderStatus.Work)
            {
                throw new Exception("only Order with work status can be change to complete status");
            }
            if (order.ShippedDate == null)
            {
                throw new Exception("Set Shipped date");
            }

            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    UpdateOrderStatusCommandParameters(order, cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ChangeStatusToWork(Order order)
        {
            if (order.Status != OrderStatus.NewOrder)
            {
                throw new Exception("only Order with new status can be change to work status");
            }
            if (order.OrderDate == null)
            {
                throw new Exception("Set Order date");
            }
            if (order.ShippedDate != null)
            {
                throw new Exception("Shipped must not be to set because status move to work");
            }

            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    UpdateOrderStatusCommandParameters(order, cmd);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void UpdateOrderStatusCommandParameters(Order order, DbCommand cmd)
        {
            cmd.CommandText = "UpdateOrderStatus";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@OrderID";
            paramId.Value = order.OrderID;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@OrderDate";
            param2.Value = order.OrderDate;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@ShippedDate";
            param3.Value = order.ShippedDate;

            cmd.Parameters.Add(paramId);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
        }
        #endregion


        #region GetOrderWithDetails

        public Order GetOrderDetails(int orderId)
        {
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    GetOrderWithDetailsCommandParameters(orderId, cmd);
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        var result = MapWithDetails(reader);
                        result.OrderID = orderId;
                        return result;
                    }
                }
            }

        }

        private void GetOrderWithDetailsCommandParameters(int id, DbCommand cmd)
        {
            var result = new Order();

            cmd.CommandText = "GetOrderWithOrderDetils";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }


        private Order MapWithDetails(DbDataReader reader)
        {
            Order entity = new Order();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.CustomerID = reader["CustomerID"].ToString();
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    entity.RequiredDate = Convert.ToDateTime(reader["RequiredDate"].ToString());
                    entity.ShippedDate = Convert.ToDateTime(reader["ShippedDate"].ToString());
                    entity.ShipVia = Convert.ToInt32(reader["ShipVia"].ToString());
                    entity.Freight = Convert.ToDecimal(reader["Freight"].ToString());
                    entity.ShipName = reader["ShipName"].ToString();
                    entity.ShipAddress = reader["ShipAddress"].ToString();
                    entity.ShipCity = reader["ShipCity"].ToString();
                    entity.ShipRegion = reader["ShipRegion"].ToString();
                    entity.ShipPostalCode = reader["ShipPostalCode"].ToString();
                    entity.ShipCountry = reader["ShipCountry"].ToString();

                    if (entity.OrderDate == null)
                    {
                        entity.Status = OrderStatus.NewOrder;
                    }
                    else if (entity.ShippedDate == null)
                    {
                        entity.Status = OrderStatus.Work;
                    }
                    else if (entity.ShippedDate != null)
                    {
                        entity.Status = OrderStatus.Complete;
                    }

                    reader.NextResult();
                    entity.OrderDetails = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        var detail = new OrderDetail();

                        detail.Product = new Product();

                        detail.ProductID = (int)reader["ProductID"];
                        detail.Product.ProductID = detail.ProductID;
                        detail.Product.ProductName = (string)reader["ProductName"];
                        detail.UnitPrice = (decimal)reader["UnitPrice"];
                        detail.Quantity = Convert.ToInt16(reader["Quantity"]);
                        detail.Discount = (float)reader["Discount"];

                        entity.OrderDetails.Add(detail);
                    }
                }
            }
            return entity;
        }
        #endregion

        #region List Orders
        public List<Order> GetOrdersById(List<int> ordersIdList)
        {
            List<Order> result = new List<Order>();
            using (var connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                foreach (var orderId in ordersIdList)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        GetByIdCommandParameters(orderId, cmd);
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            result.Add(Map(reader));
                        }
                    }
                }
               
            }

            return result;
        }

        #endregion


        protected override void DeleteCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "DeleteOrder";

            Order currentOrderDb = GetById(id);

            if (currentOrderDb.Status != OrderStatus.NewOrder && currentOrderDb.Status != OrderStatus.Work)
            {
                var paramId = cmd.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = DBNull.Value;

                cmd.Parameters.Add(paramId);
            }
            else
            {
                var paramId = cmd.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;

                cmd.Parameters.Add(paramId);
            }
        }

        protected override void GetAllCommandParameters(DbCommand cmd)
        {
            cmd.CommandText = "GetAllOrder";
        }

        protected override void GetByIdCommandParameters(int id, DbCommand cmd)
        {
            cmd.CommandText = "GetByIdOrder";

            var paramId = cmd.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;

            cmd.Parameters.Add(paramId);
        }

        protected override void InsertCommandParameters(Order entity, DbCommand cmd)
        {
            cmd.CommandText = "InsertOrder";

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CustomerID";
            paramName.Value = entity.CustomerID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@EmployeeID";
            paramDescription.Value = entity.EmployeeID;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@OrderDate";
            paramPicture.Value = entity.OrderDate;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@RequiredDate";
            param2.Value = entity.RequiredDate;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@ShippedDate";
            param3.Value = entity.ShippedDate;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@ShipVia";
            param4.Value = entity.ShipVia;

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@Freight";
            param5.Value = entity.Freight;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@ShipName";
            param6.Value = entity.ShipName;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@ShipAddress";
            param7.Value = entity.ShipAddress;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@ShipCity";
            param8.Value = entity.ShipCity;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@ShipRegion";
            param9.Value = entity.ShipRegion;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@ShipPostalCode";
            param10.Value = entity.ShipPostalCode;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@ShipCountry";
            param11.Value = entity.ShipCountry;

            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
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


        protected override Order Map(DbDataReader reader)
        {
            Order entity = new Order();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    entity.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                    entity.CustomerID = reader["CustomerID"].ToString();
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.OrderDate = reader["OrderDate"] as DateTime? ?? null;
                    entity.RequiredDate = reader["RequiredDate"] as DateTime? ?? null;
                    entity.ShippedDate = reader["ShippedDate"] as DateTime? ?? null;
                    entity.ShipVia = Convert.ToInt32(reader["ShipVia"].ToString());
                    entity.Freight = Convert.ToDecimal(reader["Freight"].ToString());
                    entity.ShipName = reader["ShipName"].ToString();
                    entity.ShipAddress = reader["ShipAddress"].ToString();
                    entity.ShipCity = reader["ShipCity"].ToString();
                    entity.ShipRegion = reader["ShipRegion"].ToString();
                    entity.ShipPostalCode = reader["ShipPostalCode"].ToString();
                    entity.ShipCountry = reader["ShipCountry"].ToString();

                    if (entity.OrderDate == null)
                    {
                        entity.Status = OrderStatus.NewOrder;
                    }
                    else if (entity.ShippedDate == null)
                    {
                        entity.Status = OrderStatus.Work;
                    }
                    else if (entity.ShippedDate != null)
                    {
                        entity.Status = OrderStatus.Complete;
                    }

                    reader.NextResult();
                    entity.OrderDetails = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        var detail = new OrderDetail();

                        detail.Product = new Product();

                        detail.OrderID = entity.OrderID;

                        detail.ProductID = (int)reader["ProductID"];
                        detail.Product.ProductID = detail.ProductID;
                        detail.Product.ProductName = (string)reader["ProductName"];
                        detail.UnitPrice = (decimal)reader["UnitPrice"];
                        detail.Quantity = (int)reader["Quantity"];
                        detail.Discount = (float)reader["Discount"];

                        entity.OrderDetails.Add(detail);
                    }
                }
            }
            return entity;
        }

        protected override List<Order> Maps(DbDataReader reader)
        {
            List<Order> entityList = new List<Order>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Order entity = new Order();
                    entity.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                    entity.CustomerID = reader["CustomerID"].ToString();
                    entity.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    entity.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    entity.RequiredDate = Convert.ToDateTime(reader["RequiredDate"].ToString());
                    entity.ShippedDate = Convert.ToDateTime(reader["ShippedDate"].ToString());
                    entity.ShipVia = Convert.ToInt32(reader["ShipVia"].ToString());
                    entity.Freight = Convert.ToInt32(reader["Freight"].ToString());
                    entity.ShipName = reader["ShipName"].ToString();
                    entity.ShipAddress = reader["ShipAddress"].ToString();
                    entity.ShipCity = reader["ShipCity"].ToString();
                    entity.ShipRegion = reader["ShipRegion"].ToString();
                    entity.ShipPostalCode = reader["ShipPostalCode"].ToString();
                    entity.ShipCountry = reader["ShipCountry"].ToString();

                    if (entity.OrderDate == null)
                    {
                        entity.Status = OrderStatus.NewOrder;
                    }
                    else if (entity.ShippedDate == null)
                    {
                        entity.Status = OrderStatus.Work;
                    }
                    else if (entity.ShippedDate != null)
                    {
                        entity.Status = OrderStatus.Complete;
                    }

                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void UpdateCommandParameters(Order entity, DbCommand cmd)
        {
            Order currentOrderDb = GetById(entity.OrderID);

            cmd.CommandText = "UpdateOrder";

            if (currentOrderDb.Status != OrderStatus.NewOrder) 
            {
                entity = currentOrderDb;
            }

            var param12 = cmd.CreateParameter();
            param12.ParameterName = "@OrderID";
            param12.Value = entity.OrderID;

            var paramName = cmd.CreateParameter();
            paramName.ParameterName = "@CustomerID";
            paramName.Value = entity.CustomerID;

            var paramDescription = cmd.CreateParameter();
            paramDescription.ParameterName = "@EmployeeID";
            paramDescription.Value = entity.EmployeeID;

            var paramPicture = cmd.CreateParameter();
            paramPicture.ParameterName = "@OrderDate";
            paramPicture.Value = currentOrderDb.OrderDate;

            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@RequiredDate";
            param2.Value = entity.RequiredDate;

            var param3 = cmd.CreateParameter();
            param3.ParameterName = "@ShippedDate";
            param3.Value = currentOrderDb.ShippedDate;

            var param4 = cmd.CreateParameter();
            param4.ParameterName = "@ShipVia";
            param4.Value = entity.ShipVia;
                

            var param5 = cmd.CreateParameter();
            param5.ParameterName = "@Freight";
            param5.Value = entity.Freight;

            var param6 = cmd.CreateParameter();
            param6.ParameterName = "@ShipName";
            param6.Value = entity.ShipName;

            var param7 = cmd.CreateParameter();
            param7.ParameterName = "@ShipAddress";
            param7.Value = entity.ShipAddress;

            var param8 = cmd.CreateParameter();
            param8.ParameterName = "@ShipCity";
            param8.Value = entity.ShipCity;

            var param9 = cmd.CreateParameter();
            param9.ParameterName = "@ShipRegion";
            param9.Value = entity.ShipRegion;

            var param10 = cmd.CreateParameter();
            param10.ParameterName = "@ShipPostalCode";
            param10.Value = entity.ShipPostalCode;

            var param11 = cmd.CreateParameter();
            param11.ParameterName = "@ShipCountry";
            param11.Value = entity.ShipCountry;

            cmd.Parameters.Add(param12);
            cmd.Parameters.Add(paramName);
            cmd.Parameters.Add(paramDescription);
            cmd.Parameters.Add(paramPicture);
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
