using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myTechnicCase.Application.Interfaces.Services;
using myTechnicCase.Web.Models;

namespace myTechnicCase.Web.Controllers;

public class HomeController : Controller
{
    private readonly IPersonnelService _personnelService;
    private readonly ITeamService _teamService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IPersonnelService personnelService, ITeamService teamService)
    {
        _teamService = teamService;
        _personnelService = personnelService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var activePersonnels = _personnelService.GetAllPersonnels().Count;
        ViewBag.activePerson = activePersonnels.ToString();
        var activeTeam = _teamService.GetAllTeams().Count;
        ViewBag.activeTeam = activeTeam.ToString();
        var waitPersonnels = _personnelService.GetAllPersonnels().Where(x=>x.TeamName == null).Count();
        ViewBag.waitPersonnels = waitPersonnels.ToString();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}