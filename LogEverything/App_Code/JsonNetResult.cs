using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LogEverything
{
    public class JsonNetResult : ActionResult
    {
        private readonly object _data;

        public object Data
        {
            get { return _data; }
        }

        public JsonNetResult(object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (_data == null)
            {
                throw new InvalidOperationException("No data assigned.");
            }

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var json = JsonConvert.SerializeObject(_data, jsonSettings);
            response.Write(json);
            response.Flush();
        }
    }
}