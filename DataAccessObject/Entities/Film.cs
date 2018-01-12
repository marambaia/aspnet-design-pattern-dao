using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessObject.Entities
{
    public class Film
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string photo { get; set; }
        public string year { get; set; }
    }
}