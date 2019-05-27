using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Orders;
using Appslx.Service.Base;

namespace Appslx.Service.Services
{
    public interface IOrderService:IEntityService<Order>
    {
        Order GetById(int id);
    }
    public class OrderService:EntityService<Order>,IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : base(unitOfWork, orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
