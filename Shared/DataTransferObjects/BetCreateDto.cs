using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
   
    public record BetCreateDto(
        [Required(ErrorMessage = "betOn is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        string BetOn,
         [Required(ErrorMessage = "betOn  is a required field.")]
        [Range(0.01, double.MaxValue,ErrorMessage = "should be  positive amount.")]
        decimal BetValue);
}
