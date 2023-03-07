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
                var itemsCollection = new ObservableCollection<CityEvent>();
                foreach (var Event in CollectionDeserializer.Item.eventsList)
                    if (Event.Category == Name) itemsCollection.Add(Event);
                return itemsCollection;
            }
        }
        public Tabs(string name, string source)
        {
            Name = name;
            ImagePath = source;
        }
    }
}
