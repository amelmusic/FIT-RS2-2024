using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class VrsteProizvodumService : BaseCRUDService<Model.VrsteProizvodum, VrsteProizvodumSearchObject, Database.VrsteProizvodum, VrsteProizvodumUpsertRequest, VrsteProizvodumUpsertRequest>, IVrsteProizvodumService
    {

        public VrsteProizvodumService(EProdajaContext context, IMapper mapper)
        : base(context, mapper){ 

        }
    }
}
