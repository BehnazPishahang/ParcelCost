using ServiceModel.Parcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Interface
{
    public interface ICalculateCost
    {
        bool IsCorrectRule(ParcelContract parcel);
        public string ParcelCost(ParcelContract parcel);
    }
}
