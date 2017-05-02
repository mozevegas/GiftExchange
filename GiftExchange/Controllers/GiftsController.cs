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
        // View a List of all current presents === READ
        public ActionResult Index()
        {
            var Presents = new GiftService().GetGiftList();
            return View(Presents);
        }
        // Add a Present to the Collection ===  CREATE
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
        // Edit a Present with ID  ====  UPDATE
        public ActionResult Edit(int Id)
        {
            var present = GiftService.GetPresent(Id);
            return View(present);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var present = new Presents();
            UpdateModel(present);
            var newPresent = new GiftService().EditPresent(present);
            return RedirectToAction("Index");
        }
        // Delete Present  ===  DELETE
        public ActionResult Delete(int Id)
        {
            var present = GiftService.GetPresent(Id);
            return View(present);
        }
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            var present = new Presents();
            present.Id = Id;
            var newPresent = new GiftService().DeletePresent(present);
            return RedirectToAction("Index");
        }
    }
}