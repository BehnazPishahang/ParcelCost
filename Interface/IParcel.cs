using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IParcel
    {
        public decimal ParcelCost(int Weight, int Height, int Width, int Depth);
    }
}
