using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class KorisniciUpdateRequest
    {
        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string? Telefon { get; set; }

        public string? Lozinka { get; set; }
        public string? LozinkaPotvrda { get; set; }

        public bool? Status { get; set; }
        public string? Email { get; set; }
    }
}
