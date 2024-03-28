using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class ActiveProizvodiState : BaseProizvodiState
    {
        public ActiveProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }
    }
}
