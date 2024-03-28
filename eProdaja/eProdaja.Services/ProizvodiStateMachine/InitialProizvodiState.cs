using eProdaja.Model;
using eProdaja.Model.Requests;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class InitialProizvodiState : BaseProizvodiState
    {
        public InitialProizvodiState(Database.EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var set = Context.Set<Database.Proizvodi>();
            var entity =Mapper.Map<Database.Proizvodi>(request);
            entity.StateMachine = "draft";
            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Proizvodi>(entity);
        }

      
    }
}
