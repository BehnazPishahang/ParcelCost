
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace ServiceModel.Parcel
{
    public class ParcelResponse
    {
        public string Cost { get; set; }
        public string Message { get; set; }
        public Enumerations.Category Category { get; set; }

        public Enumerations.InputNull InputNull { get; set; }
    }
}
