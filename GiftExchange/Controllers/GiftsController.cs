using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftExchange.Services;
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
            // put into the database
            var Contents = collection["Contents"];
            var GiftHint = collection["GiftHint"];
            var ColorWrapper = collection["ColorWrapper"];
            var Height = collection["Height"];
            var Width = collection["Width"];
            var Depth = collection["Depth"];
            var Weight = collection["Weight"];
            var IsOpened = collection["IsOpened"];

            const string connectionString =
                            @"Server=localhost\SQLEXPRESS;Database=GiftExchangeDB;Trusted_Connection=True;";
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[PresentsFinal]([Contents],[GiftHint],[ColorWrapper],[Height],[Width],[Depth],[Weight],[IsOpened])" +
                    $"VALUES({Contents},{GiftHint},{ColorWrapper},{Height},{Width},{Depth},{Weight},{IsOpened})GO";
                    var cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rv.Add(new Models.Presents(reader));
                    }
                    connection.Close();

                }




            // send to index page
            return RedirectToAction("Index");
        }

    }
}