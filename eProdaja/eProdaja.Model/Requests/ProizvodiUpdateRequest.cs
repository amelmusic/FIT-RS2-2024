using System;
using System.Collections.Generic;

namespace eProdaja.Model.Requests
{
    public partial class ProizvodiUpdateRequest
    {

        public string? Naziv { get; set; }

        public decimal Cijena { get; set; }

        public int VrstaId { get; set; }

        public int JedinicaMjereId { get; set; }

        //public byte[]? Slika { get; set; }

        //public byte[]? SlikaThumb { get; set; }

        //public bool? Status { get; set; }

        //public string? StateMachine { get; set; }

       
    }

}
