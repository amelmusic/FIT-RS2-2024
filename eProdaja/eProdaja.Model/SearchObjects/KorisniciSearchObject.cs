using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.SearchObjects
{
    public class KorisniciSearchObject : BaseSearchObject
    {
        public string? ImeGTE { get; set; }
        public string? PrezimeGTE { get; set; }

        public string? Email { get; set; }

        public string? KorisnickoIme { get; set; }

        public bool? IsKorisniciUlogeIncluded { get; set; }

        public string? OrderBy { get; set; }

    }
}
