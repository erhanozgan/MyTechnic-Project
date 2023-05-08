using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace myTechnicCase.Application.Dtos.Team
{
	public class TeamCreateDto
	{
		public string Name { get; set; }
		public int SupervisorPersonnelId { get; set; }
		public ICollection<int> PersonnelsId { get; set; }

		[NotMapped]
		[ValidateNever]
		public List<SelectListItem> Personnels { get; set; }
	}
}
