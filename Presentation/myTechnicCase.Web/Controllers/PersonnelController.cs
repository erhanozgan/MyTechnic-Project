using Microsoft.AspNetCore.Mvc;
using myTechnicCase.Application.Dtos.Personnel;
using myTechnicCase.Application.Interfaces.Services;

namespace myTechnicCase.Web.Controllers;

public class PersonnelController : Controller
{
    private readonly IPersonnelService _personnelService;

    public PersonnelController(IPersonnelService personnelService)
    {
        _personnelService = personnelService;
    }
    // GET
    public IActionResult Index()
    {
        List<PersonnelListDto> personnels = _personnelService.GetAllPersonnels().ToList();
        return View(personnels);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var personnelDto = new PersonelCreateDto();
        return View(personnelDto);
    }

    [HttpPost]
    public ActionResult Create(PersonelCreateDto personnelDto)
    {
        if (ModelState.IsValid)
            _personnelService.AddPersonnel(personnelDto);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        if (ModelState.IsValid)
        {
            _personnelService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    
    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (id is null)
            return RedirectToAction(nameof(Index));
        var data = _personnelService.GetAllPersonnels().Find(x => x.Id == id);
        return View(data);
    }

    [HttpPost]
    public IActionResult Update(PersonnelListDto dto)
    {
        bool isUpdated = _personnelService.Update(dto);
        return RedirectToAction("Index");
    }

}