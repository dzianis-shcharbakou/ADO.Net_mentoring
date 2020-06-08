using ADO.Net.Models;
using ADO.Net.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace UnitTestProject1
{
    public class OrderRepositoryTest
    {
        private IOrderRepository orderRepository;

        [SetUp]
        public void Setup()
        {
            string connString = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;
            string provider = ConfigurationManager.ConnectionStrings["NorthwindDB"].ProviderName;

            orderRepository = new OrderRepository(connString, provider);
        }

        [Test]
        public void GetOrdersById()
        {
            List<int> ordersId = new List<int>();
            ordersId.Add(10250);
            ordersId.Add(10251);

            var orders = orderRepository.GetOrdersById(ordersId);
            // first order
            Assert.AreEqual(10250, orders[0].OrderID);
            Assert.AreEqual("HANAR", orders[0].CustomerID);
            Assert.AreEqual(4, orders[0].EmployeeID);
            Assert.AreEqual("1996-07-08 00:00:00", orders[0].OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1996-08-05 00:00:00", orders[0].RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1996-07-12 00:00:00", orders[0].ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(2, orders[0].ShipVia);
            Assert.AreEqual(65.83, orders[0].Freight);
            Assert.AreEqual("Hanari Carnes", orders[0].ShipName);
            Assert.AreEqual("Rua do Paço, 67", orders[0].ShipAddress);
            Assert.AreEqual("Rio de Janeiro", orders[0].ShipCity);
            Assert.AreEqual("RJ", orders[0].ShipRegion);
            Assert.AreEqual("05454-876", orders[0].ShipPostalCode);
            Assert.AreEqual("Brazil", orders[0].ShipCountry);
            Assert.AreEqual(OrderStatus.Complete, orders[0].Status);

            // second order
            Assert.AreEqual(10251, orders[1].OrderID);
            Assert.AreEqual("VICTE", orders[1].CustomerID);
            Assert.AreEqual(3, orders[1].EmployeeID);
            Assert.AreEqual("1996-07-08 00:00:00", orders[1].OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1996-08-05 00:00:00", orders[1].RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1996-07-15 00:00:00", orders[1].ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(1, orders[1].ShipVia);
            Assert.AreEqual(41.34, orders[1].Freight);
            Assert.AreEqual("Victuailles en stock", orders[1].ShipName);
            Assert.AreEqual("2, rue du Commerce", orders[1].ShipAddress);
            Assert.AreEqual("Lyon", orders[1].ShipCity);
            Assert.AreEqual(string.Empty, orders[1].ShipRegion);
            Assert.AreEqual("69004", orders[1].ShipPostalCode);
            Assert.AreEqual("France", orders[1].ShipCountry);
            Assert.AreEqual(OrderStatus.Complete, orders[1].Status);
        }

        [Test]
        public void GetOrderDetailsById()
        {
            int id = 11060;
            var order = orderRepository.GetOrderDetails(id);

            // order
            Assert.AreEqual(11060, order.OrderID);
            Assert.AreEqual("FRANS", order.CustomerID);
            Assert.AreEqual(2, order.EmployeeID);
            Assert.AreEqual("1998-04-30 00:00:00", order.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1998-05-28 00:00:00", order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1998-05-04 00:00:00", order.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(2, order.ShipVia);
            Assert.AreEqual(10.98, order.Freight);
            Assert.AreEqual("Franchi S.p.A.", order.ShipName);
            Assert.AreEqual("Via Monte Bianco 34", order.ShipAddress);
            Assert.AreEqual("Torino", order.ShipCity);
            Assert.AreEqual(string.Empty, order.ShipRegion);
            Assert.AreEqual("10100", order.ShipPostalCode);
            Assert.AreEqual("Italy", order.ShipCountry);
            Assert.AreEqual(order.Status, OrderStatus.Complete);
            // order details
            // 1 product
            Assert.AreEqual(60, order.OrderDetails[0].ProductID);
            Assert.AreEqual("Camembert Pierrot", order.OrderDetails[0].Product.ProductName);
            Assert.AreEqual(34.00, order.OrderDetails[0].UnitPrice);
            Assert.AreEqual(4, order.OrderDetails[0].Quantity);
            Assert.AreEqual(0, order.OrderDetails[0].Discount);
            // 2 product
            Assert.AreEqual(77, order.OrderDetails[1].ProductID);
            Assert.AreEqual("Original Frankfurter grüne Soße", order.OrderDetails[1].Product.ProductName);
            Assert.AreEqual(13.00, order.OrderDetails[1].UnitPrice);
            Assert.AreEqual(10, order.OrderDetails[1].Quantity);
            Assert.AreEqual(0, order.OrderDetails[1].Discount);
        }

        [Test]
        public void CreateNewOrderWithStatusNew()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = null,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));
            var order = orderRepository.GetById(orderIdWithStatusNew);
            Assert.AreEqual(newOrder.CustomerID, order.CustomerID);
            Assert.AreEqual(newOrder.EmployeeID, order.EmployeeID);
            Assert.AreEqual(newOrder.ShipVia, order.ShipVia);
            Assert.AreEqual(newOrder.Freight, order.Freight);
            Assert.AreEqual(newOrder.ShipName, order.ShipName);
            Assert.AreEqual(newOrder.ShipAddress, order.ShipAddress);
            Assert.AreEqual(newOrder.ShipCity, order.ShipCity);
            Assert.AreEqual(newOrder.ShipRegion, order.ShipRegion);
            Assert.AreEqual(newOrder.ShipPostalCode, order.ShipPostalCode);
            Assert.AreEqual(newOrder.ShipCountry, order.ShipCountry);
            Assert.AreEqual(order.Status, OrderStatus.NewOrder);
        }

        [Test]
        public void CreateNewOrderWithStatusWork()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1Work",
                ShipAddress = "ShipAddress1Work",
                ShipCity = "ShipCity1Work",
                ShipRegion = "ShipRegion1Work",
                ShipPostalCode = "ShipPostal",
                ShipCountry = "ShipCountryWork"
            };

            int orderIdWithStatusWork = Convert.ToInt32(orderRepository.Add(newOrder));
            var order = orderRepository.GetById(orderIdWithStatusWork);
            Assert.AreEqual(newOrder.CustomerID, order.CustomerID);
            Assert.AreEqual(newOrder.EmployeeID, order.EmployeeID);
            Assert.AreEqual(newOrder.ShipVia, order.ShipVia);
            Assert.AreEqual(newOrder.Freight, order.Freight);
            Assert.AreEqual(newOrder.ShipName, order.ShipName);
            Assert.AreEqual(newOrder.ShipAddress, order.ShipAddress);
            Assert.AreEqual(newOrder.ShipCity, order.ShipCity);
            Assert.AreEqual(newOrder.ShipRegion, order.ShipRegion);
            Assert.AreEqual(newOrder.ShipPostalCode, order.ShipPostalCode);
            Assert.AreEqual(newOrder.ShipCountry, order.ShipCountry);
            Assert.AreEqual(order.Status, OrderStatus.Work);
        }

        [Test]
        public void CreateNewOrderWithStatusComplete()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1Work",
                ShipAddress = "ShipAddress1Work",
                ShipCity = "ShipCity1Work",
                ShipRegion = "ShipRegion1Work",
                ShipPostalCode = "ShipPost",
                ShipCountry = "ShipCountryWork"
            };

            int orderIdWithStatusComplete = Convert.ToInt32(orderRepository.Add(newOrder));
            var order = orderRepository.GetById(orderIdWithStatusComplete);
            Assert.AreEqual(newOrder.CustomerID, order.CustomerID);
            Assert.AreEqual(newOrder.EmployeeID, order.EmployeeID);
            Assert.AreEqual(newOrder.ShipVia, order.ShipVia);
            Assert.AreEqual(newOrder.Freight, order.Freight);
            Assert.AreEqual(newOrder.ShipName, order.ShipName);
            Assert.AreEqual(newOrder.ShipAddress, order.ShipAddress);
            Assert.AreEqual(newOrder.ShipCity, order.ShipCity);
            Assert.AreEqual(newOrder.ShipRegion, order.ShipRegion);
            Assert.AreEqual(newOrder.ShipPostalCode, order.ShipPostalCode);
            Assert.AreEqual(newOrder.ShipCountry, order.ShipCountry);
            Assert.AreEqual(order.Status, OrderStatus.Complete);
        }

        [Test]
        public void UpdateOrderOrderWithStatusNew()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = null,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            var order = orderRepository.GetById(orderIdWithStatusNew);

            order.OrderID = orderIdWithStatusNew;
            order.CustomerID = "TOMSP";
            order.EmployeeID = 6;
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Now;
            order.ShippedDate = DateTime.Now;
            order.ShipVia = 2;
            order.Freight = 150;
            order.ShipName = "Ship1Up";
            order.ShipAddress = "ShipAddressUp";
            order.ShipCity = "ShipCity1Up";
            order.ShipRegion = "ShipRegion1Up";
            order.ShipPostalCode = "ShipCodeUp";
            order.ShipCountry = "ShipCountryUp";
            order.Status = OrderStatus.Complete;

            orderRepository.Change(order);

            var orderUpdateResult = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(order.CustomerID, orderUpdateResult.CustomerID);
            Assert.AreEqual(order.EmployeeID, orderUpdateResult.EmployeeID);

            Assert.AreEqual(newOrder.OrderDate.GetValueOrDefault(), orderUpdateResult.OrderDate.GetValueOrDefault());
            Assert.AreEqual(order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), orderUpdateResult.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(newOrder.ShippedDate.GetValueOrDefault(), orderUpdateResult.ShippedDate.GetValueOrDefault());

            Assert.AreEqual(order.ShipVia, orderUpdateResult.ShipVia);
            Assert.AreEqual(order.Freight, orderUpdateResult.Freight);
            Assert.AreEqual(order.ShipName, orderUpdateResult.ShipName);
            Assert.AreEqual(order.ShipAddress, orderUpdateResult.ShipAddress);
            Assert.AreEqual(order.ShipCity, orderUpdateResult.ShipCity);
            Assert.AreEqual(order.ShipRegion, orderUpdateResult.ShipRegion);
            Assert.AreEqual(order.ShipPostalCode, orderUpdateResult.ShipPostalCode);
            Assert.AreEqual(order.ShipCountry, orderUpdateResult.ShipCountry);
            Assert.AreEqual(OrderStatus.NewOrder, orderUpdateResult.Status);
        }

        [Test]
        public void UpdateOrderOrderWithStatusNotANew()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            var order = orderRepository.GetById(orderIdWithStatusNew);

            order.OrderID = orderIdWithStatusNew;
            order.CustomerID = "TOMSP";
            order.EmployeeID = 6;
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Now;
            order.ShippedDate = DateTime.Now;
            order.ShipVia = 2;
            order.Freight = 150;
            order.ShipName = "Ship1Up";
            order.ShipAddress = "ShipAddressUp";
            order.ShipCity = "ShipCity1Up";
            order.ShipRegion = "ShipRegion1Up";
            order.ShipPostalCode = "ShipCodeUp";
            order.ShipCountry = "ShipCountryUp";
            order.Status = OrderStatus.Complete;

            orderRepository.Change(order);

            var orderUpdateResult = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(newOrder.CustomerID, orderUpdateResult.CustomerID);
            Assert.AreEqual(newOrder.EmployeeID, orderUpdateResult.EmployeeID);

            Assert.AreEqual(newOrder.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), orderUpdateResult.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(newOrder.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), orderUpdateResult.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(newOrder.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"), orderUpdateResult.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            Assert.AreEqual(newOrder.ShipVia, orderUpdateResult.ShipVia);
            Assert.AreEqual(newOrder.Freight, orderUpdateResult.Freight);
            Assert.AreEqual(newOrder.ShipName, orderUpdateResult.ShipName);
            Assert.AreEqual(newOrder.ShipAddress, orderUpdateResult.ShipAddress);
            Assert.AreEqual(newOrder.ShipCity, orderUpdateResult.ShipCity);
            Assert.AreEqual(newOrder.ShipRegion, orderUpdateResult.ShipRegion);
            Assert.AreEqual(newOrder.ShipPostalCode, orderUpdateResult.ShipPostalCode);
            Assert.AreEqual(newOrder.ShipCountry, orderUpdateResult.ShipCountry);
            Assert.AreEqual(OrderStatus.Complete, orderUpdateResult.Status);
        }

        [Test]
        public void DeleteOrderWithNewStatus()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = null,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            orderRepository.Delete(orderIdWithStatusNew);

            var result = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(null, result.CustomerID);
            Assert.AreEqual(0, result.EmployeeID);

            Assert.AreEqual(0, result.ShipVia);
            Assert.AreEqual(0, result.Freight);
            Assert.AreEqual(null, result.ShipName);
            Assert.AreEqual(null, result.ShipAddress);
            Assert.AreEqual(null, result.ShipCity);
            Assert.AreEqual(null, result.ShipRegion);
            Assert.AreEqual(null, result.ShipPostalCode);
            Assert.AreEqual(null, result.ShipCountry);
        }

        [Test]
        public void DeleteOrderWithWorkStatus()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            orderRepository.Delete(orderIdWithStatusNew);

            var result = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(null, result.CustomerID);
            Assert.AreEqual(0, result.EmployeeID);
            Assert.AreEqual(0, result.ShipVia);
            Assert.AreEqual(0, result.Freight);
            Assert.AreEqual(null, result.ShipName);
            Assert.AreEqual(null, result.ShipAddress);
            Assert.AreEqual(null, result.ShipCity);
            Assert.AreEqual(null, result.ShipRegion);
            Assert.AreEqual(null, result.ShipPostalCode);
            Assert.AreEqual(null, result.ShipCountry);
        }

        [Test]
        public void DeleteOrderWithCompleteStatus()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            orderRepository.Delete(orderIdWithStatusNew);

            var result = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(newOrder.CustomerID, result.CustomerID);
            Assert.AreEqual(newOrder.EmployeeID, result.EmployeeID);
            Assert.AreEqual(newOrder.ShipVia, result.ShipVia);
            Assert.AreEqual(newOrder.Freight, result.Freight);
            Assert.AreEqual(newOrder.ShipName, result.ShipName);
            Assert.AreEqual(newOrder.ShipAddress, result.ShipAddress);
            Assert.AreEqual(newOrder.ShipCity, result.ShipCity);
            Assert.AreEqual(newOrder.ShipRegion, result.ShipRegion);
            Assert.AreEqual(newOrder.ShipPostalCode, result.ShipPostalCode);
            Assert.AreEqual(newOrder.ShipCountry, result.ShipCountry);
        }



        [Test]
        public void GetByID()
        {
            int id = 11060;
            var order = orderRepository.GetById(id);

            Assert.AreEqual(11060, order.OrderID);
            Assert.AreEqual("FRANS", order.CustomerID);
            Assert.AreEqual(2, order.EmployeeID);
            Assert.AreEqual("1998-04-30 00:00:00", order.OrderDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1998-05-28 00:00:00", order.RequiredDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual("1998-05-04 00:00:00", order.ShippedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(2, order.ShipVia);
            Assert.AreEqual(10.98, order.Freight);
            Assert.AreEqual("Franchi S.p.A.", order.ShipName);
            Assert.AreEqual("Via Monte Bianco 34", order.ShipAddress);
            Assert.AreEqual("Torino", order.ShipCity);
            Assert.AreEqual(string.Empty, order.ShipRegion);
            Assert.AreEqual("10100", order.ShipPostalCode);
            Assert.AreEqual("Italy", order.ShipCountry);
            Assert.AreEqual(order.Status, OrderStatus.Complete);
        }


        [Test]
        public void ChangeStatusToWork()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = null,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            var order = orderRepository.GetById(orderIdWithStatusNew);

            order.OrderDate = DateTime.Now;

            orderRepository.ChangeStatusToWork(order);

            var result = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(OrderStatus.Work, result.Status);
        }

        [Test]
        public void ChangeStatusToComplete()
        {
            Order newOrder = new Order
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = null,
                ShipVia = 1,
                Freight = 100,
                ShipName = "Ship1New",
                ShipAddress = "ShipAddress1New",
                ShipCity = "ShipCity1New",
                ShipRegion = "ShipRegion1New",
                ShipPostalCode = "ShipCode1N",
                ShipCountry = "ShipCountry1New"
            };

            int orderIdWithStatusNew = Convert.ToInt32(orderRepository.Add(newOrder));

            var order = orderRepository.GetById(orderIdWithStatusNew);

            order.ShippedDate = DateTime.Now;

            orderRepository.ChangeStatusToComplete(order);

            var result = orderRepository.GetById(orderIdWithStatusNew);

            Assert.AreEqual(OrderStatus.Complete, result.Status);
        }

        // complete
        [Test]
        public void GetCustOrderHist()
        {

            string customerID = "BOLID";

            var items = orderRepository.CustOrderHist(customerID);

            Assert.AreEqual(items.Count, 6);
            Assert.AreEqual(items[0].ProductName, "Alice Mutton");
            Assert.AreEqual(items[0].Total, 40);
            Assert.AreEqual(items[1].ProductName, "Chef Anton's Cajun Seasoning");
            Assert.AreEqual(items[1].Total, 24);
        }

        // complete
        [Test]
        public void GetCustOrdersDetail()
        {

            int orderID = 10261;

            var items = orderRepository.CustOrderDetails(orderID);

            Assert.AreEqual(items.Count, 2);
            Assert.AreEqual(items[0].ProductName, "Sir Rodney's Scones");
            Assert.AreEqual(items[0].UnitPrice, 8.00);
            Assert.AreEqual(items[0].Quantity, 20);
            Assert.AreEqual(items[0].Discount, 0);
            Assert.AreEqual(items[0].ExtendedPrice, 160.00);

            Assert.AreEqual(items[1].ProductName, "Steeleye Stout");
            Assert.AreEqual(items[1].UnitPrice, 14.40);
            Assert.AreEqual(items[1].Quantity, 20);
            Assert.AreEqual(items[1].Discount, 0);
            Assert.AreEqual(items[1].ExtendedPrice, 288.00);
        }

       
    }
}
