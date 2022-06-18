using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class LoginController : Controller
    {
        private NLNEntities db = new NLNEntities();
     
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //Login =Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,Password")] Account account)
        {

            Account usr = db.Accounts.Where(p => p.Username.Equals(account.Username)).FirstOrDefault();
            if (usr != null && usr.Password.Equals(account.Password))
            {
                Session["User"] = usr;
                return RedirectToAction("Index", "Home");


            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}
