using Microsoft.EntityFrameworkCore;
using myTechnicCase.Application.Dtos.Personnel;
using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Application.Interfaces.Services;
using myTechnicCase.Domain.Entity;

namespace myTechnicCase.Application.Concrete;

public class PersonnelService : IPersonnelService
{
    private readonly IPersonnelRepository _personnelRepository;
    private readonly ITeamRepository _teamRepository;

    public PersonnelService(IPersonnelRepository personnelRepository, ITeamRepository teamRepository)
    {
        _personnelRepository = personnelRepository;
        _teamRepository = teamRepository;
    }
    public bool AddPersonnel(PersonelCreateDto personnelDto)
    {
        bool isAdded = _personnelRepository.Insert(new Personnel
        {
            PersonnelCode = personnelDto.PersonnelCode,
            Name = personnelDto.Name,
            Surname = personnelDto.Surname,
            UserName = personnelDto.UserName,
            Email = personnelDto.Email,
            Phone = personnelDto.Phone,
            Address = personnelDto.Address,
            Title = personnelDto.Title,
        });
        return isAdded;
    }
    public bool DeleteById(int id)
    {
        bool isDeleted = _personnelRepository.DeleteById(id);
        return isDeleted;
    }
    public List<PersonnelListDto> GetAllPersonnels()
    {
        List<PersonnelListDto> personnels = _personnelRepository.GetAll().Include(x => x.TeamFk).
            Select(x => new PersonnelListDto
            {
                Id = x.Id,
                PersonnelCode = x.PersonnelCode,
                Name = x.Name,
                Surname = x.Surname,
                UserName = x.UserName,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                Title = x.Title,
                Active = true,
                TeamName = x.TeamFk.Name
            }).ToList();
        return personnels;
    }

    public List<PersonnelListDto> GetPersonnelsThatHasNoTeams()
    {
        var personnels = _personnelRepository.GetAll().Where(x => x.TeamId == null).Select(x => new PersonnelListDto
        {
            Id = x.Id,
            PersonnelCode = x.PersonnelCode,
            Name = x.Name,
            Surname = x.Surname,
            UserName = x.UserName,
            Email = x.Email,
            Phone = x.Phone,
            Address = x.Address,
            Title = x.Title,
            Active = true,
        }).ToList();
        return personnels;
    }

    public bool TransferPersonnelToAnotherTeam(int personnelId, int teamId)
    {
        var personnel = _personnelRepository.GetById(personnelId);
        foreach (var team in _teamRepository.GetAll())
        {
            if (team.SupervisorPersonnelId == personnelId)
                return false;
        }
        personnel.TeamId = teamId;
        return _personnelRepository.Update(personnel);
    }
    
    public bool Update(PersonnelListDto personnelDto)
    {
        Personnel personnel = _personnelRepository.GetById(personnelDto.Id);
        personnel.PersonnelCode = personnelDto.PersonnelCode;
        personnel.Name = personnelDto.Name;
        personnel.Surname = personnelDto.Surname;
        personnel.UserName = personnelDto.UserName;
        personnel.Email = personnelDto.Email;
        personnel.Phone = personnelDto.Phone;
        personnel.Address = personnelDto.Address;
        personnel.Title = personnelDto.Title;
        return _personnelRepository.Update(personnel);
    }
}