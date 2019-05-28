﻿using System.Linq;
using Appslx.Service.Services;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;

namespace Appslx.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Get(IDataTablesRequest requestModel,string input)
        {
            var data = _orderService.GetDataTable(requestModel.Start,requestModel.Length,input);

            var entity = data.Item3.Select(x => new
            {
                x.Id,
                desc = x.OrderStatus.Descrition
            }).ToList();

            var response = DataTablesResponse.Create(requestModel, data.Item1.Value, data.Item2.Value, entity);
            return new DataTablesJsonResult(response, true);
            
        }
    }
}