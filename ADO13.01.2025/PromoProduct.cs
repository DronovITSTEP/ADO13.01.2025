//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADO13._01._2025
{
    using System;
    using System.Collections.Generic;
    
    public partial class PromoProduct
    {
        public int PromoProductId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Country { get; set; }
        public int SectionId { get; set; }
    
        public virtual Section Sections { get; set; }

        public override string ToString()
        {
            return $"{Name} {StartDate} {EndDate} {Country} {Sections}";
        }
    }
}
