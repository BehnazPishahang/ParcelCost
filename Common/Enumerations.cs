using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Enumerations
    {
        public enum Category
        {
            Reject=1,
            HeavyParcel=2,
            SmallParcel=3,
            MediumParcel=4,
            LargeParce=5

        }

        public enum InputNull
        {
            WeightNull = 1,
            WidthNull = 2,
            DepthNull = 3,
            HeightNull = 4,

        }
    }
}
