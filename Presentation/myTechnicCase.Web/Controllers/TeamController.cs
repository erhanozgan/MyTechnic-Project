using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myTechnicCase.Application.Dtos.Team;
using myTechnicCase.Application.Interfaces.Services;

namespace myTechnicCase.Web.Controllers;

public class TeamController : Controller
{
	private readonly ITeamService _teamService;
	private readonly IPersonnelService _personnelService;
	private readonly IShiftService _shiftService;

	public TeamController(ITeamService teamService, IPersonnelService personnelService)
	{
		_teamService = teamService;
		_personnelService = personnelService;
	}
	// GET
	public IActionResult Index()
	{
		var teams = _teamService.GetAllTeams();


		return View(teams);
	}
	[HttpGet]
	public IActionResult Create()
	{
		var team = new TeamCreateDto();
		FillDropdownItems(team);
		return View(team);
	}

	[HttpPost]
	public ActionResult Create(TeamCreateDto teamDto)
	{
		if (ModelState.IsValid)
			_teamService.CreateTeam(teamDto);
		return RedirectToAction(nameof(Index));
	}
	public void FillDropdownItems(TeamCreateDto dto)
	{
		dto.Personnels = _personnelService.GetPersonnelsThatHasNoTeams().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = $"{e.Name} {e.Surname}" })
			.ToList();
	}
	public IActionResult Delete(int id)
	{
		if (ModelState.IsValid)
		{
			_teamService.DeleteById(id);

			return RedirectToAction(nameof(Index));
		}
		return NotFound();
	}

	[HttpGet]
	public IActionResult Update(int? id)
	{
		if (id is null)
			return RedirectToAction(nameof(Index));
		var data = _teamService.GetAllTeams().Find(x=>x.Id == id);
		return View(data);
	}

	[HttpPost]
	public IActionResult Update(TeamListDto dto)
	{
		bool isUpdated = _teamService.Update(dto);
		return RedirectToAction("Index");
	}
}