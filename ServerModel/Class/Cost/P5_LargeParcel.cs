using Common;
using ServerModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Class.Cost
{
    public class P5_LargeParcel : ICalculateCost
    {
        public decimal ParcelCost(int Weight, int Volume)
        {
            return Convert.ToDecimal(Constants.Ratio.LargeRatio * Volume);

        }
    }
}
