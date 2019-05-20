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

    public partial class ARTICULO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Descripción del articulo requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "precio del articulo requerido")]
        public Nullable<double> Precio { get; set; }
        [Required(ErrorMessage = "Marca del articulo requerido")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Unidad de medida del articulo requerido")]
        [Display(Name ="Unidad")]
        public string Unidad_Medida { get; set; }
        [Required(ErrorMessage = "Existencia del articulo requerido")]
        public Nullable<int> Existencia { get; set; }
        [Required(ErrorMessage = "Precio Unitario de medida del articulo requerido")]
        [Display(Name = "Precio Unitario")]
        public Nullable<double> Precio_Unitario { get; set; }
        [Required(ErrorMessage = "Precio Venta de medida del articulo requerido")]
        [Display(Name = "Precio Venta")]
        public Nullable<double> Precio_Venta { get; set; }        
        [Display(Name = "Creado el")]
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        [Display(Name = "Modificado el")]
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
        public Nullable<bool> Estatus { get; set; }
    }
}
