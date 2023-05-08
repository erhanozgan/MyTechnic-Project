using myTechnicCase.Application.Dtos.Personnel;

namespace myTechnicCase.Application.Interfaces.Services;

public interface IPersonnelService
{
    bool AddPersonnel(PersonelCreateDto personnelDto);
    List<PersonnelListDto> GetAllPersonnels();
    bool DeleteById(int id);
    bool TransferPersonnelToAnotherTeam(int personnelId, int teamId);
    List<PersonnelListDto> GetPersonnelsThatHasNoTeams();
    
    bool Update(PersonnelListDto personnelDto);


}
