using RoutesInfoLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RoutesInfoLibrary.Models
{
    public class Route : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stop> Stops { get; set; }
        public int TransportId { get; set; }
        public Transport Transport
        {
            get
            {
                return DBService.Instance.GetModelData<Transport>().FirstOrDefault(x => x.Id == TransportId);
            }
        }
        public string RouteDescription
        {
            get
            {
                return string.Join(", ", Stops.Select(x => x.Name));
            }
        }
        public BitmapImage RouteMap { get => new BitmapImage(new Uri(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), $@"../../../RoutesInfoLibrary/Resources/{Id}.png")))); }

        public Route()
        {

        }

        public Route(int id, string name, List<Stop> stops, int transportId)
        {
            Id = id;
            Name = name;
            Stops = stops;
            TransportId = transportId;
        }

        public List<IModel> GenerateData()
        {
            List<IModel> data = new List<IModel>();
            data.Add(new Route(1, "30", new List<Stop>() { new Stop(1, "Урицкого"), new Stop(2, "Железнодорожный вокзал"), new Stop(3, "Чернышевского") }, 1));
            data.Add(new Route(2, "45", new List<Stop>() { new Stop(4, "Парк победы"), new Stop(5, "Разъезд восстания") }, 1));
            data.Add(new Route(3, "2", new List<Stop>() { new Stop(1, "Урицкого"), new Stop(2, "Железнодорожный вокзал") }, 1));
            data.Add(new Route(4, "12", new List<Stop>() { new Stop(6, "Площадь Тукая"), new Stop(7, "Филармония") }, 2));
            data.Add(new Route(5, "8", new List<Stop>() { new Stop(6, "Площадь Тукая"), new Stop(7, "Филармония") }, 2));
            data.Add(new Route(6, "10", new List<Stop>() { new Stop(8, "Саид Галеева"), new Stop(6, "Площадь Тукая") }, 1));
            data.Add(new Route(7, "63", new List<Stop>() { new Stop(9, "Советская площадь"), new Stop(10, "Парк Горького") }, 1));
            data.Add(new Route(8, "91", new List<Stop>() { new Stop(11, "Высокая гора"), new Stop(16, "Улица мира"), }, 1));
            data.Add(new Route(9, "7", new List<Stop>() { new Stop(12, "Дворец спорта"), new Stop(13, "ЦУМ") }, 2));
            data.Add(new Route(10, "6", new List<Stop>() { new Stop(14, "Театр кукол"), new Stop(15, "Улица Халева") }, 2));
            return data;
        }
    }
}
