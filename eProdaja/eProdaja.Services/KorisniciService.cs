using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;


namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public KorisniciService(EProdajaContext context, IMapper mapper) { 
            Context = context;
            Mapper = mapper;
        }

        public virtual  PagedResult<Model.Korisnici> GetList(KorisniciSearchObject searchObject)
        {
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            var query = Context.Korisnicis.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x => x.Ime.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Email))
            {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == searchObject.KorisnickoIme);
            }

            if (searchObject.IsKorisniciUlogeIncluded == true)
            {
                query = query.Include(x => x.KorisniciUloges).ThenInclude(x => x.Uloga);
            }

            int count = query.Count();


            if (!string.IsNullOrWhiteSpace(searchObject.OrderBy))
            {
                //var items = searchObject.OrderBy.Split(' ');
                //if (items.Length > 2 || items.Length == 0)
                //{
                //    throw new ApplicationException("You can only sort by one field");
                //}
                //if (items.Length == 1)
                //{
                //    query = query.OrderBy("@0", searchObject.OrderBy);
                //}
                //else
                //{
                //    query = query.OrderBy(string.Format("{0} {1}", items[0], items[1]));
                //}

                //query = query.OrderBy(searchObject.OrderBy);
            }

            if (searchObject?.Page.HasValue == true && searchObject?.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
            }

            //if (!string.IsNullOrWhiteSpace(searchObject.OrderBy))
            //{
            //    switch (searchObject.OrderBy)
            //    {
            //        case "KorisnickoIme ASC":
            //            query = query.OrderBy(x => x.KorisnickoIme);
            //            break;

            //        case "KorisnickoIme DESC":
            //            query = query.OrderByDescending(x => x.KorisnickoIme);
            //            break;

            //        case "Ime ASC":
            //            query = query.OrderBy(x => x.Ime);
            //            break;

            //        case "Ime DESC":
            //            query = query.OrderByDescending(x => x.Ime);
            //            break;
            //    }
                    
                
            //}



            var list = query.ToList();

           var resultList = Mapper.Map(list, result);

            PagedResult<Model.Korisnici> response = new PagedResult<Model.Korisnici>();

            response.ResultList = resultList;
            response.Count = count;

            return response;

        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste");
            }

            Database.Korisnici entity = new Database.Korisnici();
            Mapper.Map(request, entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            Context.Add(entity);
            Context.SaveChanges();


            return Mapper.Map<Model.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = Context.Korisnicis.Find(id);

            Mapper.Map(request, entity);

            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }

            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(entity);
        }
    }
}
