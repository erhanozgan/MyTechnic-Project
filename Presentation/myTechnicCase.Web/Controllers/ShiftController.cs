using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myTechnicCase.Application.Dtos.Shift;
using myTechnicCase.Application.Interfaces.Services;

namespace myTechnicCase.Web.Controllers;

public class ShiftController : Controller
{
    private readonly IShiftService _shiftService;
    private readonly ITeamService _teamService;
    public ShiftController(IShiftService shiftService, ITeamService teamService)
    {
        _shiftService = shiftService;
        _teamService = teamService;
    }
    // GET
    public IActionResult Index()
    {
        List<ShiftListDto> shiftList = _shiftService.GetAllShifts().ToList();
        return View(shiftList);
    }

    private void FillDropdownItems(ShiftCreateDto dto)
    {
        dto.Teams = _teamService.GetAllTeams().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = $"{e.Name}" }).ToList();
    }
    [HttpGet]
    public IActionResult Create()
    {
        var shiftDto = new ShiftCreateDto();
        FillDropdownItems(shiftDto);
        return View(shiftDto);
    }

    [HttpPost]
    public ActionResult Create(ShiftCreateDto shiftCreateDto)
    {
        if (ModelState.IsValid)
            _shiftService.AddShift(shiftCreateDto);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        if (ModelState.IsValid)
        {
            _shiftService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    
    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (id is null)
            return RedirectToAction(nameof(Index));
        var data = _shiftService.GetAllShifts().Find(x => x.Id == id);
        return View(data);
    }

    [HttpPost]
    public IActionResult Update(ShiftListDto dto)
    {
        bool isUpdated = _shiftService.Update(dto);
        return RedirectToAction("Index");
    }
}