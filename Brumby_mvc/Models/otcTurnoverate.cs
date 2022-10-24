using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brumby_mvc.Models
{
    public class otcTurnoverate
    {
        public int Id { get; set; }
        public string s_date { get; set; }
        public int s_rank { get; set; }
        public string s_id { get; set; }
        public string s_name { get; set; }
        public string s_deal { get; set; }
        public string s_market { get; set; }
        public double s_turnoverate { get; set; }
    }
}