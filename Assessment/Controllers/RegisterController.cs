using Assessment.Models;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Models;
using Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        public async Task<IActionResult> Index()
        {     
            List<RegisterViewModel> registerList = new List<RegisterViewModel>();

            _registerService.GetAllAsync().Result.ToList().ForEach(x => registerList.Add(
                new RegisterViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }
                ));

            return View(registerList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {

                Dominio.Models.Register register  = new Dominio.Models.Register()
                {                 
                    Email = obj.Email,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,                    
                };

                bool success = false;
                success = _registerService.AddRegisterAsync(register).Result;

                if (success)
                    TempData["success"] = "Register created successfully";
                else
                    TempData["success"] = "Register unsuccessfully";
            }

            return RedirectToAction("Index", "Register");

        }
    }
}
