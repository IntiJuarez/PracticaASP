using System;
using System.Collections.Generic;

namespace PracticaASP.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Shoes = new HashSet<Shoes>();
        }

        public int BrandId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Shoes> Shoes { get; set; }
    }
}
