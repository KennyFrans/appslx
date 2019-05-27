using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.OrderDetails;
using Appslx.Service.Base;

namespace Appslx.Service.Services
{
    public interface IOrderDetailService:IEntityService<OrderDetail>
    {
        OrderDetail GetById(int id);
    }
    public class OrderDetailService:EntityService<OrderDetail>,IOrderDetailService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository) : base(unitOfWork, orderDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
