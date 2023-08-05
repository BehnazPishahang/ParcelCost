namespace Common
{
    public static class Constants
    {

        #region Ratio
        public static class Ratio
        {
            public const double HeavyRatio = 15;

            public const double SmallRatio = 0.05;

            public const double MediumRatio = 0.04;

            public const double LargeRatio = 0.03;
        } 
        #endregion

        #region Category
        //These categories use in asserting in the test project
        public static class Category
        {
            public const string Reject = "P1_RejectParcel";

            public const string Heavy = "P2_HeavyParcel";

            public const string Small = "P3_SmallParcel";

            public const string Medium = "P4_MediumParcel";

            public const string Large = "P5_LargeParcel";

        }

        #endregion


    }
}