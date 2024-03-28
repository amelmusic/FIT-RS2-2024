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
    public abstract class BaseCRUDService<TModel, TSearch, TDbEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TDbEntity> where TModel : class where TSearch : BaseSearchObject where TDbEntity : class
    {
        public BaseCRUDService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            
            
            TDbEntity entity = Mapper.Map<TDbEntity>(request);

            //if (request.Lozinka != request.LozinkaPotvrda)
            //{
            //    throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste");
            //}


            //entity.LozinkaSalt = GenerateSalt();
            //entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            BeforeInsert(request, entity);

            Context.Add(entity);
            Context.SaveChanges();


            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert request, TDbEntity entity) { }

        public virtual TModel Update(int id, TUpdate request) {
            var set = Context.Set<TDbEntity>();

            var entity = set.Find(id);

            Mapper.Map(request, entity);

            BeforeUpdate(request, entity);

            Context.SaveChanges();

            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeUpdate(TUpdate request, TDbEntity entity) { }

    }
}
