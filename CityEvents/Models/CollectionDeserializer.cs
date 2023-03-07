using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CityEvents.Models
{
    public class CollectionDeserializer
    { 
        public ObservableCollection<CityEvent> eventsList;
        public string error = "";
        private static readonly CollectionDeserializer item = new();
        public static CollectionDeserializer Item { get => item; }

        public CollectionDeserializer() 
        {
            eventsList = Loader();
        }
        private ObservableCollection<CityEvent> Loader()
        {
            ObservableCollection<CityEvent> list = new();
            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load("../../../EventsCollection1.xml");
            }
            catch (Exception ex) 
            {
                error = ex.Message; return list; 
            }
            XElement? eventsArray = xdoc.Element("ArrayOfCityEvent");

            foreach (XElement Event in eventsArray.Elements("CityEvent"))
            {
                string title = Event.Element("Header").Attribute("data")?.Value;
                string desc = Event.Element("Description").Attribute("data")?.Value;
                string img = Event.Element("Image").Attribute("data")?.Value;
                string date = Event.Element("Date").Attribute("data")?.Value;
                string category = Event.Element("Category").Attribute("data")?.Value;
                string price = Event.Element("Price").Attribute("data")?.Value;
                list.Add(new CityEvent(title, desc, img, date, category, price));
            }
            return list;
        }
    }

}
