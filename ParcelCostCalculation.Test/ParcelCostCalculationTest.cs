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

namespace ParcelCostCalculation.Test
{
    public class ParcelCostCalculationTest
    {
        private readonly ParcelCostCalculationController controller;
        public ParcelCostCalculationTest()
        {
            controller = new ParcelCostCalculationController();
        }

        [Fact]
        public async Task ParcelCost_RequestIsNull_ShouldReturnRequestIsNullOrCorrupt()
        {

            //Arrange

            ParcelRequest request = new ParcelRequest();
            request = null;

            //Act

            var result = await controller.ParcelCost(request);


            //Assert

            Assert.Equal(result.Cost, null);
        }

        [Theory]
        [InlineData(0,10,10,10)]
        public async Task ParcelCost_InputWeightIsNull_ShouldReturn_WeightNull(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.InputNull, Enumerations.InputNull.WeightNull);
        }

        [Theory]
        [InlineData(10, 10, 0, 10)]
        public async Task ParcelCost_InputHeightIsNull_ShouldReturn_HeightNull(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.InputNull, Enumerations.InputNull.HeightNull);
        }

        [Theory]
        [InlineData(10, 0, 10, 10)]
        public async Task ParcelCost_InputWidthIsNull_ShouldReturn_WidthNull(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.InputNull, Enumerations.InputNull.WidthNull);
        }

        [Theory]
        [InlineData(10, 10, 10, 0)]
        public async Task ParcelCost_InputDepthIsNull_ShouldReturn_DepthNull(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.InputNull, Enumerations.InputNull.DepthNull);
        }

        [Theory]
        [InlineData(60)]
        [InlineData(51)]
        public async Task ParcelCost_Reject_ShouldReturn_Reject(int Weight)
        {
            //Arange
            ParcelRequest request=new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = 10;
            request.theParcelContract.Height = 10;
            request.theParcelContract.Depth= 10;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category,Enumerations.Category.Reject);
        }


        [Theory]
        [InlineData(49)]
        [InlineData(11)]
        public async Task ParcelCost_HeavyParcel_ShouldReturn_HeavyParcel(int Weight)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = 10;
            request.theParcelContract.Height = 10;
            request.theParcelContract.Depth = 10;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.HeavyParcel);
        }

        [Theory]
        [InlineData(8,10,10,10)]
        [InlineData(9,1,15,10)]
        public async Task ParcelCost_SmallParcel_ShouldReturn_SmallParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.SmallParcel);
        }

        [Theory]
        [InlineData(8, 23, 10, 10)]
        [InlineData(9, 10, 24, 10)]
        public async Task ParcelCost_MediumParcel_ShouldReturn_MediumParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.MediumParcel);
        }

        [Theory]
        [InlineData(8, 25, 100, 10)]
        [InlineData(9, 10, 26, 10)]
        public async Task ParcelCost_LargeParcel_ShouldReturn_LargeParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.LargeParce);
        }

        [Theory]
        [InlineData(60,10,10,10)]
        public async Task ParcelCost_RejectANDSmallParcel_ShouldReturn_Reject(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.Reject);
        }

        [Theory]
        [InlineData(60, 10, 14, 10)]
        public async Task ParcelCost_RejectANDMediumParcel_ShouldReturn_Reject(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.Reject);
        }

        [Theory]
        [InlineData(60, 10, 26, 10)]
        public async Task ParcelCost_RejectANDLargeParcel_ShouldReturn_Reject(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.Reject);
        }

        [Theory]
        [InlineData(12, 10, 14, 10)]
        public async Task ParcelCost_HeavyParcelANDSmallParcel_ShouldReturn_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.HeavyParcel);
        }

        [Theory]
        [InlineData(12, 10, 24, 10)]
        public async Task ParcelCost_HeavyParcelANDMediumParcel_ShouldReturn_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.HeavyParcel);
        }

        [Theory]
        [InlineData(12, 10, 26, 10)]
        public async Task ParcelCost_HeavyParcelANDLargeParcel_ShouldReturn_HeavyParcel(int Weight, int Width, int Height, int Depth)
        {
            //Arange
            ParcelRequest request = new ParcelRequest();
            request.theParcelContract.Weight = Weight;
            request.theParcelContract.Width = Width;
            request.theParcelContract.Height = Height;
            request.theParcelContract.Depth = Depth;

            //Act
            var result = await controller.ParcelCost(request);

            //Assert
            Assert.Equal(result.Category, Enumerations.Category.HeavyParcel);
        }

        
    }
}
