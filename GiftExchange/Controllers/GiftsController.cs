using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftExchange.Services;
using GiftExchange.Models;
using System.Data.SqlClient;

namespace GiftExchange.Controllers
{
    public class GiftsController : Controller
    {
        // View a List of all current presents
        public ActionResult Index()
        {
            var Presents = new GiftService().GetGiftList();
            return View(Presents);
        }
        // Add a Present to the Collection
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (FormCollection collection)
        {
            var present = new Presents();
            UpdateModel(present);
            var newPresent = new GiftService().AddGiftDB(present);
            return RedirectToAction("Index");
        }
    }
}