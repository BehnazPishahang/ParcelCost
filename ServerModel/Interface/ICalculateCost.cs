using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerModel.Interface
{
    public interface ICalculateCost
    {
        public decimal ParcelCost(int Weight, int Volume);
    }
}
