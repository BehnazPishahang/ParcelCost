
using ServiceModel.CustomFilter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Parcel
{
    public class ParcelRequest
    {
        [Required(ErrorMessage = "Request is null.")]
        [AllPropertiesGreaterThanZero(ErrorMessage = "All properties must be greater than zero.")]
        public ParcelContract theParcelContract { get; set; }
    }
}
