using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        protected IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Korisnici> GetList()
        {
            return _service.GetList();
        }

        [HttpPost]
        public Korisnici Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
