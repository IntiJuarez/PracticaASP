using System;
using System.Collections.Generic;

namespace PracticaASP.Models
{
    public partial class Shoes
    {
        public int ShoesId { get; set; }
        public string? Name { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
    }
}
