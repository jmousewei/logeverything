using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogEverything.Controllers
{
    public class RedirectController : Controller
    {
        //
        // GET: /Redirect/
        public ActionResult UnsafeRedirect(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                return Redirect(url);
            }

            return View();
        }
	}
}