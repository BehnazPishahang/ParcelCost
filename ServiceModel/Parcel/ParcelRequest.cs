using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Parcel
{
    public class ParcelRequest
    {
        public ParcelRequest()
        {
            theParcelContract = new ParcelContract();
        }

        public ParcelContract theParcelContract { get; set; }
    }
}
