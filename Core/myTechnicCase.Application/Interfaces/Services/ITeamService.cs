using myTechnicCase.Application.Dtos.Team;

namespace myTechnicCase.Application.Interfaces.Services;

public interface ITeamService
{
	bool CreateTeam(TeamCreateDto teamDto);
	List<TeamListDto> GetAllTeams();
	bool DeleteById(int teamId);
	bool Update(TeamListDto teamDto);

	
}