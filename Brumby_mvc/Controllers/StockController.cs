using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brumby_mvc.Controllers
{
    public class StockController : Controller
    {
        List<Models.otc> data = new List<Models.otc>();
        // GET: Stock
        public ActionResult Listed()
        {
            return View();
        }

        public ActionResult OTC()
        {
            cs.Stock.OTC otc = new cs.Stock.OTC();
            data = otc.ParseOTCInfo("111/09/20");
            ViewBag.OTC = data;
            return View();
        }
        public ActionResult GetOTCturnoverate()
        {
            return RedirectToAction("OTC");
        }
    }
}