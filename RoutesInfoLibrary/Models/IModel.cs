using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutesInfoLibrary.Models
{
    public interface IModel
    {
        List<IModel> GenerateData();
    }
}
