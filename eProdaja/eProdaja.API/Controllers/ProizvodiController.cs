using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase
    {
        protected IProizvodiService _service;

        public ProizvodiController(IProizvodiService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Proizvodi> GetList()
        {
            return _service.GetList();
        }
    }
}
