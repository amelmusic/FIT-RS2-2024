using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKorisniciService
    {
        PagedResult<Korisnici> GetList(KorisniciSearchObject searchObject);
        Korisnici Insert(KorisniciInsertRequest request);

        Korisnici Update(int id, KorisniciUpdateRequest request);
    }
}
