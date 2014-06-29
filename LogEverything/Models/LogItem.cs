using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogEverything.Models
{
    public class LogItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
    }
}