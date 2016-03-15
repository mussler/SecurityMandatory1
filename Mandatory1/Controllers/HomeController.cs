using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mandatory1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Shift()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Shift(ViewModels.CipherModel m)
        {

            if (!ModelState.IsValid || (m.type != "enc" && m.type != "dec"))
            {
                ViewBag.Error = true;
                return View();
            }
            m.process("shift");
            ViewBag.m = m;
            return View(m);
        }
        [HttpGet]
        public ActionResult Vigenere()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Vigenere(ViewModels.CipherModel m)
        {
            if (!ModelState.IsValid || (m.type != "enc" && m.type != "dec"))
            {
                ViewBag.Error = true;
                return View();
            }
            m.process("vigenere");
            ViewBag.m = m;
            return View(m);
        }
        [HttpGet]
        public ActionResult GCD()
        {


            return View();
        }
        [HttpPost]
        public ActionResult GCD(ViewModels.CipherModel m)
        {
            if (!ModelState.IsValid || (m.type != "enc" && m.type != "dec"))
            {
                ViewBag.Error = true;
                return View();
            }
            m.process("gcd");
            ViewBag.m = m;
            return View(m);
        }
    }
}