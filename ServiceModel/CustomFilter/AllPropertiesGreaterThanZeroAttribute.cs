
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModel.Parcel;

namespace ServiceModel.CustomFilter
{
    public class AllPropertiesGreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is ParcelContract request)
            {
                if (request.Weight <= 0 ||
                    request.Height <= 0 ||
                    request.Width <= 0 ||
                    request.Depth <= 0)
                {
                    return new ValidationResult("All properties must be greater than zero.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
