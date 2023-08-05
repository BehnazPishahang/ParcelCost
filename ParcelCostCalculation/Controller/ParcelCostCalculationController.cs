using Microsoft.AspNetCore.Mvc;
using ServiceModel.Parcel;
using ServerModel;
using ServerModel.Class;
using ServerModel.Interface;
using ServerModel.Class.Cost;

namespace ParcelCostCalculation.Controller
{

    public class ParcelCostCalculationController : ControllerBase
    {
        [HttpPost]
        [Route("api/v1/[controller]/[action]")]
        public async Task<ActionResult<ParcelResponse>> ParcelCost([FromBody] ParcelRequest request)
        {

            #region Validation

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errorMessages);
            }

            if (request == null)
            {
                return BadRequest("Please fill all of the items.");
            }

            #endregion

            ParcelContract parcel = new ParcelContract(request.theParcelContract.Weight, request.theParcelContract.Height, request.theParcelContract.Width, request.theParcelContract.Depth);
            ParcelCostCalculator calculator = new ParcelCostCalculator();
            ParcelResponse response = await calculator.CalculateCost(parcel);
            return Ok(response);

        }
    }
}
