using Common;
using ServerModel.Interface;
using ServiceModel.Parcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Class.Cost
{
    public class P3_SmallParcel : ICalculateCost
    {
        public bool IsCorrectRule(ParcelContract parcel)
        {
            return parcel.GetVolume() > 0 && parcel.GetVolume() < 1500;
        }

        public string ParcelCost(ParcelContract parcel)
        {
            double Cost = Constants.Ratio.SmallRatio * parcel.GetVolume();
            return Cost.ToString("F2");
        }
    }
}
