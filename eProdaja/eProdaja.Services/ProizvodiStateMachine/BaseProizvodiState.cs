using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;

using Microsoft.Extensions.DependencyInjection;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class BaseProizvodiState
    {
        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public BaseProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = context;
            Mapper = mapper; 
            ServiceProvider = serviceProvider;
        }
        public virtual Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            throw new Exception("Method not allowed");
        }

        public virtual Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            throw new Exception("Method not allowed");
        }

        public virtual Model.Proizvodi Activate(int id)
        {
            throw new Exception("Method not allowed");
        }

        public virtual Model.Proizvodi Hide(int id)
        {
            throw new Exception("Method not allowed");
        }

        public BaseProizvodiState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialProizvodiState>();
                case "draft":
                    return ServiceProvider.GetService<DraftProizvodiState>();
                case "active":
                    return ServiceProvider.GetService<ActiveProizvodiState>();
                default : throw new Exception("State not recognized");
            }
        }
    }
}
//initial, draft, active, hidden