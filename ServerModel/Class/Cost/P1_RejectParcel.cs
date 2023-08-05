using ServerModel.Interface;
using ServiceModel.Parcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Class.Cost
{
    public class P1_RejectParcel : ICalculateCost
    {
        public bool IsCorrectRule(ParcelContract parcel)
        {
            return parcel.Weight > 50;
        }

        public string ParcelCost(ParcelContract parcel)
        {
            return "N/A";
        }
    }
}
