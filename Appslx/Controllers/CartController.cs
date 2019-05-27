﻿using System.Collections.Generic;
using System.Linq;
using Appslx.Service.Services;
using Appslx.Web.Helper;
using Appslx.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appslx.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var listCart = GetCartData();
            return PartialView("_Index",listCart);
        }

        [HttpGet]
        public IActionResult DeleteItem(string code = "")
        {
            var listCart = GetCartData();
            var currentItem = listCart.FirstOrDefault(x=>x.Code == code);
            if (currentItem != null)
            {
                listCart.Remove(currentItem);
                SetCartData(listCart);
                //if (listCart.Any(x => x.Code == code && x.Qty > 1))
                //{
                //    listCart.Remove(currentItem);
                //    currentItem.Qty -= 1;
                //    currentItem.Price -= _productService.GetByCode(code).UnitPrice;
                //    listCart.Add(currentItem);
                //    SetCartData(listCart);
                //}
                //else
                //{
                //    listCart.Remove(currentItem);
                //    SetCartData(listCart);
                //}
            }
            

            return PartialView("_Index", listCart);
        }

        [HttpGet]
        public IActionResult AdjustQuantity(int qty = 0,string code="")
        {
            var listCart = GetCartData();
            var currentItem = listCart.FirstOrDefault(x => x.Code == code);
            if (currentItem != null)
            {
                listCart.Remove(currentItem);
                currentItem.Qty = qty;
                currentItem.Price = qty * _productService.GetByCode(code).UnitPrice;
                listCart.Add(currentItem);
                SetCartData(listCart);
            }

            return PartialView("_Index", listCart);
        }

        public IActionResult OrderItem()
        {
            var listCart = GetCartData();
            if (listCart.Count != 0)
            {
                RemoveCartData();
                return Json(
                    new
                    {
                        success = true,
                        responseText = $"{listCart.Count} {(listCart.Count > 1 ? "items" : "item")} requested"
                    }
                );
            }

            return Json(
                new
                {
                    success = false,
                    responseText = $"You dont order any item yet"
                }
            );

        }

        private List<CartViewModel> GetCartData()
        {
            if (HttpContext.Session.GetObject<List<CartViewModel>>("cart") == null)
            {
                HttpContext.Session.SetObject("cart", new List<CartViewModel>());
            }

            return HttpContext.Session.GetObject<List<CartViewModel>>("cart");

        }

        private void SetCartData(List<CartViewModel> obj)
        {
            HttpContext.Session.SetObject("cart", obj);
        }

        private void RemoveCartData()
        {
            HttpContext.Session.Remove("cart");
        }
    }
}