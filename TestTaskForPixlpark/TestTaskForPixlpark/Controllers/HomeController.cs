using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTaskForPixlpark.Models;
using TestTaskForPixlpark.Tools;

namespace TestTaskForPixlpark.Controllers
{
    public class HomeController : Controller
    {
        static List<Order> orders = new List<Order>();

        [HttpGet]
        public ActionResult Index()
        {
            AnswerResult answer = Tool.GetOrders();
            orders = answer.Orders;

            ViewBag.Orders = orders;
            return View();
        }

        [HttpGet]
        public ActionResult LearnMore(string id)
        {
            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    ViewBag.Order = order;
                    break;
                }
            }
            return View();
        }
    }
}