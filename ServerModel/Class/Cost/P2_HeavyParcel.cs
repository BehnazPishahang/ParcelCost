using ServerModel.Interface;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Class.Cost
{
    public  class P2_HeavyParcel : ICalculateCost
    {
        public decimal ParcelCost(int Weight, int Volume)
        {
            
            return Convert.ToDecimal(Weight * Constants.Ratio.HeavyRatio);

        }

    }
}
