using Avalonia.Platform;
using Avalonia;
using CityEvents.Models;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;

namespace CityEvents.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static string Error { get => CollectionDeserializer.Item.error; }
        ObservableCollection<Tabs> tabsItems = new()
        {
            new Tabs("Для детей", "Assets/Icons/for_kids.png"),
            new Tabs("Спорт", "Assets/Icons/sport.png"),
            new Tabs("Культура", "Assets/Icons/culture.png"),
            new Tabs("Экскурсии", "Assets/Icons/excursen.png"),
            new Tabs("Образ жизни", "Assets/Icons/lifestyle.png"),
            new Tabs("Вечеринки", "Assets/Icons/party.png"),
            new Tabs("Образование", "Assets/Icons/education.png"),
            new Tabs("Онлайн", "Assets/Icons/online.png"),
            new Tabs("Шоу", "Assets/Icons/show.png"),
        };
        public ObservableCollection<Tabs> TabsItems { get => tabsItems; }
    }
}