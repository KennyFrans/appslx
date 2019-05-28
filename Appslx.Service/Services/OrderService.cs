using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Orders;
using Appslx.Service.Base;

namespace Appslx.Service.Services
{
    public interface IOrderService:IEntityService<Order>
    {
        Tuple<int?, int?, IEnumerable<Order>> GetDataTable(int skip,int length,string input);
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

        public Tuple<int?, int?, IEnumerable<Order>> GetDataTable(int skip, int length,string input)
        {
            var entity = _orderRepository.GetWithDetails().ToList();

            //filter
            var filteredData = entity;
            if (!string.IsNullOrEmpty(input))
            {
                filteredData = filteredData.Where(x=>x.Id.ToString().Contains(input)).ToList();
            }
            var dataPage = filteredData.Skip(skip).Take(length);

            return new Tuple<int?, int?, IEnumerable<Order>>(entity.Count(),filteredData.Count(),dataPage);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
