//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cardealership.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Марки_автомобилей
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Марки_автомобилей()
        {
            this.Автомобили = new HashSet<Автомобили>();
        }
    
        public int Номер_марки { get; set; }
        public string Название_марки { get; set; }
        public string Страна_производитель { get; set; }
        public string Завод_производитель { get; set; }
        public string Адрес { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автомобили> Автомобили { get; set; }
    }
}
