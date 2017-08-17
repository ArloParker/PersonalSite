using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MileageTracker.Models;

namespace MileageTracker.Controllers
{




    public class TitrationController : Controller
    {

        private decimal? result;
        private TDataDBContext db = new TDataDBContext();
        // GET: Titration
        public ActionResult Index()
        {
           
            //ViewBag.message =  " %";
            


            //ViewBag.message = massunknown;


            return View();
        }

        public ActionResult Submit([Bind(Include = "ID,unknown,mbase,result")] TData tdata)
        {
            decimal mwunknown = 60;
            decimal mwbase = 84;

            if (!(tdata.unknown == 0 || tdata.mbase == 0))
            {

                decimal massacid = ((tdata.mbase / mwbase) * mwunknown);
                decimal percent = (decimal)(massacid / tdata.unknown) * 100;
                ViewBag.message = " % Acetic Acid";
                tdata.result = decimal.Round(massacid, 2);
            }
            if (ModelState.IsValid)
            {
                db.TDataList.Add(tdata);
                db.SaveChanges();
              
            }

           
            return View("Index", tdata);

        }

    



    }
}
