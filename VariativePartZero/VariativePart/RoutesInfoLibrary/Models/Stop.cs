using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RoutesInfoLibrary.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Image { get => new BitmapImage(new Uri(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), $@"../../../RoutesInfoLibrary/Resources/Stops/{Id}.png")))); }

        public Stop()
        {

        }

        public Stop(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
