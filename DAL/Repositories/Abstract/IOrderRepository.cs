using ADO.Net.Models;
using ADO.Net.Repositories.Interfaces;
using DAL.Models.StoredProcedureModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Net.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        // 1.1
        List<Order> GetOrdersById(List<int> ordersIdList);
        // 1.2
        Order GetOrderDetails(int orderId);

        void ChangeStatusToWork(Order order);
        void ChangeStatusToComplete(Order order);
        List<CustOrderDetails> CustOrderDetails(int orderId);
        List<CustOrderHist> CustOrderHist(string customerId);
    }
}
