using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Models
{
    public class CityEvent
    {
        public CityEvent(string name, string desc, string source, string date, string category, string price)
        {
            Header = name;
            Description = desc;
            Image = source;
            Date = date;
            Category = category;
            Price = price;
        }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
    }
}
