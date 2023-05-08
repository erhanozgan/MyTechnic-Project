using myTechnicCase.Application.Dtos.Shift;

namespace myTechnicCase.Application.Interfaces.Services;

public interface IShiftService
{
	bool AddShift(ShiftCreateDto shiftDto);
	List<ShiftListDto> GetAllShifts();
	bool AssignTeamToShift(int teamId, int shiftId);
	bool DeleteById(int shiftId);
	
	bool Update(ShiftListDto shiftDto);

}