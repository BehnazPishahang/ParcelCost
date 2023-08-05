using ServerModel.Interface;
using ServiceModel.Parcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Class.Cost
{
    public class ParcelCostCalculator
    {
        //For creating instances of these classes should follow the priority orders
        private readonly ICalculateCost[] rules = {
        new P1_RejectParcel(),
        new P2_HeavyParcel(),
        new P3_SmallParcel(),
        new P4_MediumParcel(),
        new P5_LargeParcel()
    };

        public async Task<ParcelResponse> CalculateCost(ParcelContract parcel)
        {
            foreach (var rule in rules)
            {
                if (rule.IsCorrectRule(parcel))
                    return new ParcelResponse { Category = rule.GetType().Name, Cost = rule.ParcelCost(parcel) };
            }

            return new ParcelResponse { Category = "Unknown", Cost = "-1" };
        }
    }


}
