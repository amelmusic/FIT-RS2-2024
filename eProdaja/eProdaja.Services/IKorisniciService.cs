using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IKorisniciService
    {
        List<Korisnici> GetList();
        Korisnici Insert(KorisniciInsertRequest request);

        Korisnici Update(int id, KorisniciUpdateRequest request);
    }
}
