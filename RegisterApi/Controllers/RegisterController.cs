using Dominio.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.Models;
using System.Net;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public  IEnumerable<Register> GetAll()
        {
            List<Register> registerList = new List<Register>();

             _registerService.GetAllAsync().Result.ToList().ForEach(x => registerList.Add(
                new RegisterApi.Models.Register()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }
                ));

            return registerList.ToList();
        }

        [HttpPost]
        public HttpResponseMessage Add(RegisterApi.Models.Register obj)
        {
            if (ModelState.IsValid)
            {

                Dominio.Models.Register register = new Dominio.Models.Register()
                {
                    Email = obj.Email,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                };

                bool success = false;
                success = _registerService.AddRegisterAsync(register).Result;

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
