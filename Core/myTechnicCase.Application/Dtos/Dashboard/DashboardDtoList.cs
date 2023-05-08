using System.ComponentModel;
using myTechnicCase.Application.Dtos.Personnel;
using myTechnicCase.Application.Dtos.Shift;
using myTechnicCase.Application.Dtos.Team;

namespace myTechnicCase.Application.Dtos.Dashboard;

public class DashboardDtoList
{
    public List<int> TeamsId { get; set; }
    
    [DisplayName("Team")]
    public List<TeamListDto>? Teams { get; set; }
    
    [DisplayName("Personnel")]
    public List<int> PersonnelsId { get; set; }

    public List<PersonnelListDto>? Personnels { get; set; }
    
    [DisplayName("Shift")]
    public List<int> ShiftId { get; set; }
    
    public List<ShiftListDto>? Shift { get; set; }
}