using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Models
{
    public class Tabs
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ObservableCollection<CityEvent> EventsCollection
        {
            get
            {
                var res = new ObservableCollection<CityEvent>();
                foreach (var Event in CollectionDeserializer.Item.eventsCollection)
                    if (Event.Category == Name) res.Add(Event);
                return res;
            }
        }
        public Tabs(string name, string source)
        {
            Name = name;
            ImagePath = source;
        }
    }
}
