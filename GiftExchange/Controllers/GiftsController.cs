using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiftExchange.Controllers
{
    public class GiftsController : Controller
    {
        // GET: Gifts
        public ActionResult Index()
        {
            return View();
        }
    }
}