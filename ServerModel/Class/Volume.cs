namespace ServerModel.Class
{
    public abstract class Volume
    {
        public int VolumCalculation(int Height, int Width, int Depth)
        {
            return Height * Width * Depth;  
        }
    }
}