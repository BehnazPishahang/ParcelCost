using Microsoft.AspNetCore.Mvc;
using ServiceModel.Parcel;
using ServerModel;
using ServerModel.Class;
using ServerModel.Interface;
using ServerModel.Class.Cost;

namespace ParcelCostCalculation.Controller
{
    public class ParcelCostCalculationController : Volume
    {
        [HttpPost]
        [Route("api/v1/[controller]/[action]")]
        public async Task<ParcelResponse> ParcelCost([FromBody] ParcelRequest request)
        {
            ParcelResponse response = new ParcelResponse();

            #region Validation

            #region Check null value
            if (request == null || request.theParcelContract == null)
            {
                response.Message = "The Request is null.";
                response.Cost = null;
                return response;
            }

            if (request.theParcelContract.Weight == null || request.theParcelContract.Weight==0)
            {
                response.Message = "Please fill the value of weight.";
                response.InputNull = Common.Enumerations.InputNull.WeightNull;
                return response;
            }

            if (request.theParcelContract.Height == null || request.theParcelContract.Height == 0)
            {
                response.Message = "Please fill the value of height.";
                response.InputNull = Common.Enumerations.InputNull.HeightNull;
                return response;
            }

            if (request.theParcelContract.Width == null || request.theParcelContract.Width == 0)
            {
                response.Message = "Please fill the value of width.";
                response.InputNull = Common.Enumerations.InputNull.WidthNull;
                return response;
            }

            if (request.theParcelContract.Depth == null || request.theParcelContract.Depth == 0)
            {
                response.Message = "Please fill the value of depth.";
                response.InputNull = Common.Enumerations.InputNull.DepthNull;
                return response;
            }

            #endregion

            
            #endregion

            int Volume = VolumCalculation(request.theParcelContract.Height, request.theParcelContract.Width, request.theParcelContract.Depth);


            #region Reject
            if (request.theParcelContract.Weight > 50)
            {
                response.Cost = "N/A";
                response.Category = Common.Enumerations.Category.Reject;

            }
            #endregion

            #region HeavyParcel
            else if (request.theParcelContract.Weight > 10)
            {
                P2_HeavyParcel HeavyParcel = new P2_HeavyParcel();
                decimal HeavyParcelCost = HeavyParcel.ParcelCost(request.theParcelContract.Weight, Volume);
                response.Cost = HeavyParcelCost.ToString();
                response.Category = Common.Enumerations.Category.HeavyParcel;
            }
            #endregion

            #region SmallParcel
            else if (Volume < 1500)
            {
                P3_SmallParcel SmallParcel = new P3_SmallParcel();
                decimal SmallParcelCost = SmallParcel.ParcelCost(request.theParcelContract.Weight, Volume);
                response.Cost = SmallParcelCost.ToString();
                response.Category = Common.Enumerations.Category.SmallParcel;
            }
            #endregion

            #region MediumParcel
            else if (Volume < 2500)
            {
                P4_MediumParcel MediumParcel = new P4_MediumParcel();
                decimal MediumParcelCost = MediumParcel.ParcelCost(request.theParcelContract.Weight, Volume);
                response.Cost = MediumParcelCost.ToString();
                response.Category = Common.Enumerations.Category.MediumParcel;
            }
            #endregion

            #region LargeParcel
            else
            {
                P5_LargeParcel LargeParcel = new P5_LargeParcel();
                decimal LargeParcelCost = LargeParcel.ParcelCost(request.theParcelContract.Weight, Volume);
                response.Cost = LargeParcelCost.ToString();
                response.Category = Common.Enumerations.Category.LargeParce;
            } 
            #endregion

            return response;

        }
    }
}
