using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CityEvents.Models
{
    public class CollectionDeserializer
    { 
        public CityEvent[] eventsCollection;
        public string error = "";
        private static readonly CollectionDeserializer item = new();
        public static CollectionDeserializer Item { get => item; }

        public CollectionDeserializer() 
        {
            eventsCollection = Loader();
        }

        private static string Val(XAttribute? a) => a == null ? "" : a.Value;
        private CityEvent[] Loader()
        {
            List<CityEvent> list = new();
            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load("../../../EventsCollection1.xml");
            }
            catch (Exception ex) { error = ex.Message; return list.ToArray(); }
            XElement? events = xdoc.Element("CityEventsCollection");
            if (events == null) { error = "Не найден корневой тег Events"; return list.ToArray(); }
            foreach (XElement Event in events.Elements("CityEvent"))
            {
                XElement? title = Event.Element("Header");
                XElement? desc = Event.Element("Description");
                XElement? img = Event.Element("Image");
                XElement? date = Event.Element("Date");
                XElement? cat = Event.Element("Category");
                XElement? price = Event.Element("Price");
                if (title == null || img == null || date == null || cat == null) continue;
                string s_title = Val(title.Attribute("data"));
                string s_desc = Val(desc.Attribute("data"));
                string s_img = Val(img.Attribute("data"));
                string s_date = Val(date.Attribute("data"));
                string s_cat = Val(cat.Attribute("data"));
                string s_price = Val(price.Attribute("data"));
                list.Add(new CityEvent(s_title, s_desc, s_img, s_date, s_cat, s_price));
            }
            return list.ToArray();
        }
    }

}
