using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesInfoLibrary.Models
{
    public class Transport : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<IModel> GenerateData()
        {
            List<IModel> data = new List<IModel>();
            data.Add(new Transport() { Id = 1, Name = "Автобус" });
            data.Add(new Transport() { Id = 2, Name = "Троллейбус" });
            return data;
        }
    }
}
