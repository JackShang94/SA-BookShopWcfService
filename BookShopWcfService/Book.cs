//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShopWcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    
        public virtual Book Book1 { get; set; }
        public virtual Book Book2 { get; set; }
    }
}
