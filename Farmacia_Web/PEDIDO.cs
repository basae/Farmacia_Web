//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farmacia_Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            this.PEDIDO_DETALLE = new HashSet<PEDIDO_DETALLE>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Pedido el")]
        public Nullable<System.DateTime> Fecha_Pedido { get; set; }
        [Required(ErrorMessage ="Cliente invalido")]
        [Display(Name ="Cliente")]
        public int Id_Cliente { get; set; }
        public Nullable<double> Total { get; set; }
        [Display(Name ="Creado el")]
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        [Display(Name = "Modificado el")]
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
        public Nullable<bool> Estatus { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO_DETALLE> PEDIDO_DETALLE { get; set; }
    }
}
