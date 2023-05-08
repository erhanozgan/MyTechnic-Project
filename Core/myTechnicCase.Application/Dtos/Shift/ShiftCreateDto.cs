using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace myTechnicCase.Application.Dtos.Shift
{
    public class ShiftCreateDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TeamId { get; set; }

        [NotMapped]
        [ValidateNever]
        public List<SelectListItem>? Teams { get; set; }
    }
}
