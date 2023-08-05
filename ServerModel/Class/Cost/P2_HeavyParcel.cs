using ServerModel.Interface;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ServiceModel.Parcel;
using static Common.Constants;

namespace ServerModel.Class.Cost
{
    public class P2_HeavyParcel : ICalculateCost
    {
        public bool IsCorrectRule(ParcelContract parcel)
        {
            return parcel.Weight > 10;
        }

        public string ParcelCost(ParcelContract parcel)
        {
            double Cost = parcel.Weight * Constants.Ratio.HeavyRatio;
            return Cost.ToString("F2");
        }

    }
}
