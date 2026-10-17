using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMonolithic.ApplicationService.ApplicationService.Contracts;
using MvcMonolithic.ApplicationService.Dtos;
using MvcMonolithic.Models;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using System.Diagnostics;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        #region Ctor
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }

        #endregion

        #region GetAll
        public async Task<IActionResult> Index()
        {
            var people = await _personApplicationService.GetAllPeople();
            return View(people);
        } 
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _personApplicationService.RemovePerson(id);
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {

                await _personApplicationService.PostPerson(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            return View(postPersonDto);
        }
        #endregion

        #region Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var personDto = await _personApplicationService.GetbyId(id);

            if (personDto == null)
            {
                return NotFound();
            }

            return View(personDto);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var personDto = await _personApplicationService.GetbyId(id);

            if (personDto == null)
            {
                return NotFound();
            }

            return View(personDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EditPersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _personApplicationService.Update(dto);
            return RedirectToAction(nameof(Index));
        } 
        #endregion


    }
}
