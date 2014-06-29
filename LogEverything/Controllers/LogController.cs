using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LogEverything.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LogEverything.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Log/
        public ActionResult Write(string src, string content)
        {
            var result = new LogResult { ErrorCode = 0, ErrorMsg = "" };
            do
            {
                if (string.IsNullOrEmpty(src) || string.IsNullOrEmpty(content))
                {
                    result.ErrorCode = -1;
                    result.ErrorMsg = "No content.";
                    break;
                }

                try
                {
                    using (var ctx = GetDataContext())
                    {
                        var logItem = new LogItem
                        {
                            Source = HttpUtility.UrlDecode(src),
                            Content = HttpUtility.UrlDecode(content)
                        };
                        ctx.Logs.Add(logItem);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    result.ErrorCode = -2;
                    result.ErrorMsg = "Unknown error.";
                    break;
                }

            } while (false);

            return JsonNet(result);
        }

        protected virtual JsonNetResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        }

        protected LogEverythingDataContext GetDataContext()
        {
            return new LogEverythingDataContext(ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"]);
        }
    }
}