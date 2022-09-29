using System;
using System.Collections.Generic;

namespace shoppingAPI.Model.EF
{
    public partial class Product
    {
        public int PId { get; set; }
        public string? PName { get; set; }
        public string? PCategory { get; set; }
        public int? PPrice { get; set; }
        public bool? PisInStock { get; set; }
    }
}
