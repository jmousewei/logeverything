using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QConnectSDK;
using QConnectSDK.Models;

namespace LogEverything.Controllers
{
    public class QQController : Controller
    {
        //
        // GET: /QQ/
        public ActionResult Index(string clientId, string access_token, string expires_in)
        {
            if (!string.IsNullOrEmpty(access_token)
                && !string.IsNullOrEmpty(clientId))
            {
                var qzone = new QOpenClient(access_token, expires_in, clientId);
                var currentUser = qzone.GetCurrentUser();
                return JsonNet(currentUser);
            }
            return View();
        }

        //
        // GET: /QQ/Info
        public ActionResult Info(string url)
        {
            User qqInfo = new User();

            //if (!string.IsNullOrEmpty(access_token)
            //    && !string.IsNullOrEmpty(url))
            //{
            //    var rawUri = new Uri(url, UriKind.Absolute);
            //    var nc = HttpUtility.ParseQueryString(rawUri.Query);
            //    var clientId = nc["clientId"];
            //    var qzone = new QOpenClient(access_token, expires_in, clientId);
            //    var currentUser = qzone.GetCurrentUser();
            //}

            return JsonNet(qqInfo);
        }

        protected virtual JsonNetResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        }
	}
}