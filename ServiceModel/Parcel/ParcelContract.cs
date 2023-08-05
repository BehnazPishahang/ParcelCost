
using System.ComponentModel.DataAnnotations;

namespace ServiceModel.Parcel
{
    public class ParcelContract
    {
        //according to kg
        [Required]
        public int Weight { get; set; }

        //according to cm
        [Required]
        public int Height { get; set; }

        //according to cm
        [Required]
        public int Width { get; set; }

        //according to cm
        [Required]
        public int Depth { get; set; }


        public ParcelContract(int weight, int height, int width, int depth)
        {
            this.Weight = weight;
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }

        public int GetVolume() => Height * Width * Depth;



    }
}