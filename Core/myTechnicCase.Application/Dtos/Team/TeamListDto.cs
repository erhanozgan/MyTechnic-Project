using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using myTechnicCase.Application.Dtos.Personnel;

namespace myTechnicCase.Application.Dtos.Team
{
    public class TeamListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        [DisplayName("Personnel")]
        public ICollection<int> PersonnelsId { get; set; }

        public ICollection<PersonnelListDto>? Personnels { get; set; }
        public List<SelectListItem> PersonnelsDd { get; set; }

        public PersonnelListDto? SupervisorPersonnel { get; set; }
    }
}
