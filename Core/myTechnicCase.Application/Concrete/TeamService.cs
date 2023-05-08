using Microsoft.AspNetCore.Mvc.Rendering;
using myTechnicCase.Application.Dtos.Personnel;
using myTechnicCase.Application.Dtos.Team;
using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Application.Interfaces.Services;
using myTechnicCase.Domain.Entity;

namespace myTechnicCase.Application.Concrete
{
	public class TeamService : ITeamService
	{
		readonly ITeamRepository _teamRepository;
		readonly IPersonnelRepository _personnelRepository;
		public TeamService(ITeamRepository teamRepository, IPersonnelRepository personnelRepository)
		{
			_teamRepository = teamRepository;
			_personnelRepository = personnelRepository;
		}

		public bool CreateTeam(TeamCreateDto teamDto)
		{
			List<Personnel> teamPersonnels = new();
			foreach (Personnel personel in _personnelRepository.GetAll())
			{
				if (teamDto.PersonnelsId.Contains(personel.Id))
					teamPersonnels.Add(personel);
			}
			var team = new Team()
			{
				Name = teamDto.Name,
				SupervisorPersonnelId = teamDto.SupervisorPersonnelId,
				Personnels = teamPersonnels
			};
			return _teamRepository.Insert(team);
		}
		public List<TeamListDto> GetAllTeams()
		{
			List<TeamListDto> teamListDto = new();
			foreach (var team in _teamRepository.GetAll())
			{
				var allPersonnels = _personnelRepository.GetAll().ToList();
				var teamPersonnels = allPersonnels.Where(x => x.TeamId == team.Id).ToList();
				TeamListDto dto = new()
				{
					Id = team.Id,
					Name = team.Name,
					Personnels = teamPersonnels.Select(x => new PersonnelListDto()
					{
						Name = x.Name,
						Active = x.Active,
						Address = x.Address,
						Email = x.Email,
						Id = x.Id,
						PersonnelCode = x.PersonnelCode,
						Phone = x.Phone,
						Surname = x.Surname,
						Title = x.Title,
						UserName = x.UserName
					}).ToList(),
					PersonnelsDd= allPersonnels.Select(x => new SelectListItem()
					{
						Text = x.Name + " " + x.Surname,
						Value = x.Id.ToString()
					}).ToList(),
					SupervisorPersonnel = allPersonnels.Where(x => x.Id == team.SupervisorPersonnelId).Select(x => new PersonnelListDto()
					{
						Name = x.Name,
						Active = x.Active,
						Address = x.Address,
						Email = x.Email,
						Id = x.Id,
						PersonnelCode = x.PersonnelCode,
						Phone = x.Phone,
						Surname = x.Surname,
						Title = x.Title,
						UserName = x.UserName
					}).FirstOrDefault()
				};
				teamListDto.Add(dto);
			}
			return teamListDto;
		}
		public bool DeleteById(int teamId) => _teamRepository.DeleteById(teamId);

		public bool Update(TeamListDto teamDto)
		{
			Team team = _teamRepository.GetById(teamDto.Id);
			
			// if (teamDto.PersonnelsId != null)
			// 	team.Personnels = _personnelRepository.GetAll().Where(e=> teamDto.PersonnelsId.Contains(e.Id)).ToList();

			var personells = _personnelRepository.GetAll().Where(e => e.TeamId == teamDto.Id);
			foreach (var p in personells)
			{
					p.TeamId = null;
					_personnelRepository.Update(p);
			}
			
			var personellsUpdated = _personnelRepository.GetAll().Where(e => teamDto.PersonnelsId.Contains(e.Id));
			foreach (var p in personellsUpdated)
			{
				p.TeamId = team.Id;
				_personnelRepository.Update(p);
			}
			
			team.Name = teamDto.Name;
			
			if (teamDto.SupervisorPersonnel != null)
				team.SupervisorPersonnelId = teamDto.SupervisorPersonnel.Id;

			return _teamRepository.Update(team);
		}
	}
}
