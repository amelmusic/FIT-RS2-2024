using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VrsteProizvodumController : BaseController<VrsteProizvodum, VrsteProizvodumSearchObject>
    {
        
        public VrsteProizvodumController(IVrsteProizvodumService service)
        : base(service) {
        }

    }
}
