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
        // GET: Gifts
        public ActionResult Index()
        {
            // get all gifts
            var gifts = new GiftService().GetGiftList();
            // pass to view
            return View(gifts);
        }

        public ActionResult GiftList()
        {
            var gifts = new GiftService().GetGiftList();
            return View(gifts);
        }

        [HttpGet]
        public ActionResult AddGift()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGift(FormCollection collection)
        {
            //// reading the forms
            //var Contents = collection["Contents"];
            //var GiftHint = collection["GiftHint"];
            //var ColorWrapper = collection["ColorWrapper"];
            //var Height = collection["Height"];
            //var Width = collection["Width"];
            //var Depth = collection["Depth"];
            //var Weight = collection["Weight"];
            //var IsOpened = collection["IsOpened"];

            // make a new gift
            var PresentNew = new Presents()
            {
                // id = int.Parse(collection["id"]),
                Contents = collection["Contents"].ToString(),
                GiftHint = collection["GiftHint"].ToString(),
                ColorWrapper = collection["ColorWrapper"].ToString(),
                Height = double.Parse(collection["Height"]),
                Width = double.Parse(collection["Width"]),
                Depth = double.Parse(collection["Depth"]),
                Weight = double.Parse(collection["Weight"]),
                IsOpened = false //bool.Parse(collection["IsOpened"])
            };

            // put it in the database

            GiftService.AddGiftDB(PresentNew);

            // send to index page
            return RedirectToAction("Index");
        }

    }
}