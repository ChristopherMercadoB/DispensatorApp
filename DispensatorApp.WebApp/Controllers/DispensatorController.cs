using DispensatorApp.Application.Services;
using DispensatorApp.Database.ViewModel;
using DispensatorApp.WebApp.Middleware;
using DispensatorApp.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DispensatorApp.WebApp.Controllers
{
    public class DispensatorController : Controller
    {
        private readonly DispensationModeService _modeService;
        private readonly DispensationQuantitiesService _quantitiesService;
        public DispensatorController(DispensationModeService modeService, DispensationQuantitiesService quantitiesService)
        {
            _modeService = modeService;
            _quantitiesService = quantitiesService;
        }

        public IActionResult Index(int? dispensationMode)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DispensationModeViewModel vm)
        {
            _modeService.Add(vm);
            return View("Dispensate");
        }

        public IActionResult Dispensate()
        {
            var entity = _modeService.GetEntityFromJson();
            ViewBag.DispensationMode = entity.DispensationMode;
            return View();
        }

        [HttpPost]
        public IActionResult Dispensate(DispensationModeViewModel vm)
        {
            DispensationModeViewModel dvm = _modeService.GetEntityFromJson();
            vm.DispensationMode = dvm.DispensationMode;
            ValidationsCheck check = new ValidationsCheck(ModelState);
            check.checkValidation(vm);

            if (ModelState.IsValid)
            {
                _modeService.Add(vm);
                var dqvm = _modeService.Dispensate(vm);
                _quantitiesService.Add(dqvm);
                return RedirectToRoute(new { controller = "Dispensator", action = "Result" });
            }      

            return View(vm);
            
        }

        public IActionResult Result()
        {
            DispensationQuantitiesViewModel vm = _quantitiesService.GetEntityFromJson();
            return View(vm);
        }

        public IActionResult GoBack(DispensationModeViewModel? dvm, DispensationQuantitiesViewModel dqvm)
        {
            if (dvm == null)
            {
                dvm = _modeService.GetEntityFromJson();
            }
            if (dqvm == null)
            {
                dqvm = _quantitiesService.GetEntityFromJson();
                dvm.DispensationMode = dqvm.DispensationMode;
            }

            return View("Index", dvm);
            

        }
    }
}
