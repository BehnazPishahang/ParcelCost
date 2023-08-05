using Common;
using Microsoft.AspNetCore.Mvc;
using ParcelCostCalculation.Controller;
using ServiceModel.Parcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ServerModel.Class.Cost;
using ServerModel.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ParcelCostCalculation.Test
{
    public class ParcelCostCalculationTest
    {
        private readonly ParcelCostCalculator calculator;
        public ParcelCostCalculationTest()
        {
            calculator = new ParcelCostCalculator();
        }

        [Theory]
        [InlineData(60)]
        [InlineData(51)]
        public async Task ParcelCost_Reject_ShouldReturn_P1_RejectParcel(int Weight)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, 10, 10, 10);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert

            Assert.Equal(Constants.Category.Reject, result.Category);
            Assert.Equal("N/A", result.Cost);
        }


        [Theory]
        [InlineData(49)]
        [InlineData(11)]
        public async Task ParcelCost_HeavyParcel_ShouldReturn_P2_HeavyParcel(int Weight)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, 10, 10, 10);


            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Heavy, result.Category);
            Assert.Equal((Constants.Ratio.HeavyRatio * parcel.Weight).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(8, 10, 10, 10)]
        [InlineData(9, 1, 15, 10)]
        public async Task ParcelCost_SmallParcel_ShouldReturn_P3_SmallParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Small, result.Category);
            Assert.Equal((Constants.Ratio.SmallRatio * parcel.GetVolume()).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(8, 23, 10, 10)]
        [InlineData(9, 10, 24, 10)]
        public async Task ParcelCost_MediumParcel_ShouldReturn_P4_MediumParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Medium, result.Category);
            Assert.Equal((Constants.Ratio.MediumRatio * parcel.GetVolume()).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(8, 25, 100, 10)]
        [InlineData(9, 10, 26, 10)]
        public async Task ParcelCost_LargeParcel_ShouldReturn_P5_LargeParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Large, result.Category);
            Assert.Equal((Constants.Ratio.LargeRatio * parcel.GetVolume()).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(60, 10, 10, 10)]
        public async Task ParcelCost_RejectANDSmallParcel_ShouldReturn_P1_RejectParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Reject, result.Category);
            Assert.Equal("N/A", result.Cost);
        }

        [Theory]
        [InlineData(60, 10, 14, 10)]
        public async Task ParcelCost_RejectANDMediumParcel_ShouldReturn_P1_RejectParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Reject, result.Category);
            Assert.Equal("N/A", result.Cost);
        }

        [Theory]
        [InlineData(60, 10, 26, 10)]
        public async Task ParcelCost_RejectANDLargeParcel_ShouldReturn_P1_RejectParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Reject, result.Category);
            Assert.Equal("N/A", result.Cost);
        }

        [Theory]
        [InlineData(12, 10, 14, 10)]
        public async Task ParcelCost_HeavyParcelANDSmallParcel_ShouldReturn_P2_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Heavy, result.Category);
            Assert.Equal((Constants.Ratio.HeavyRatio * parcel.Weight).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(12, 10, 24, 10)]
        public async Task ParcelCost_HeavyParcelANDMediumParcel_ShouldReturn_P2_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Heavy, result.Category);
            Assert.Equal((Constants.Ratio.HeavyRatio * parcel.Weight).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(12, 10, 26, 10)]
        public async Task ParcelCost_HeavyParcelANDLargeParcel_ShouldReturn_P2_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal(Constants.Category.Heavy, result.Category);
            Assert.Equal((Constants.Ratio.HeavyRatio * parcel.Weight).ToString("F2"), result.Cost);
        }

        [Theory]
        [InlineData(-12, -10, -26, -10)]
        public async Task ParcelCost_LessThanZeroInput_ShouldReturn_UnKnown(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelContract parcel = new ParcelContract(Weight, Height, Width, Depth);

            //Act
            var result = await calculator.CalculateCost(parcel);

            //Assert
            Assert.Equal("Unknown", result.Category);
            Assert.Equal("-1", result.Cost);
        }
    }
}
