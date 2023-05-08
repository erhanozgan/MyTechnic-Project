using Microsoft.EntityFrameworkCore;
using myTechnicCase.Application.Dtos.Shift;
using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Application.Interfaces.Services;
using myTechnicCase.Domain.Entity;

namespace myTechnicCase.Application.Concrete
{
    public class ShiftService : IShiftService
    {
        readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public bool AddShift(ShiftCreateDto shiftDto)
        {
            bool isAdded = _shiftRepository.Insert(new()
            {
                StartDate = shiftDto.StartDate,
                EndDate = shiftDto.EndDate,
                Name = shiftDto.Name,
                Type = shiftDto.Type,
                TeamId = shiftDto.TeamId,
            });
            return isAdded;
        }
        public bool AssignTeamToShift(int teamId, int shiftId)
        {
            Shift shift = _shiftRepository.GetById(shiftId);
            shift.TeamId = teamId;
            return _shiftRepository.Update(shift);
        }
        public List<ShiftListDto> GetAllShifts()
        {
            List<ShiftListDto> shiftList = _shiftRepository.GetAll().Include(x => x.Team).
                Select(x => new ShiftListDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Type = x.Type,
                    TeamName = x.Team.Name,
                }).ToList();
            return shiftList;
        }
        public bool DeleteById(int shiftId) => _shiftRepository.DeleteById(shiftId);
        
        public bool Update(ShiftListDto shiftDto)
        {
            Shift shift = _shiftRepository.GetById(shiftDto.Id);
            shift.Name = shiftDto.Name;
            shift.Type = shiftDto.Type;
            shift.StartDate = shiftDto.StartDate;
            shift.EndDate = shiftDto.EndDate;
            return _shiftRepository.Update(shift);

        }
    }
}
