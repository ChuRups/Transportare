//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transportare.Models.Seguridad
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsignarUsuarioRol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AsignarUsuarioRol()
        {
            this.AsignarPrivilegio = new HashSet<AsignarPrivilegio>();
        }
    
        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignarPrivilegio> AsignarPrivilegio { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}