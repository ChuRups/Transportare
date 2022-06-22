﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SeguridadEntities : DbContext
    {
        public SeguridadEntities()
            : base("name=SeguridadEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsignarPrivilegio> AsignarPrivilegio { get; set; }
        public virtual DbSet<AsignarUsuarioRol> AsignarUsuarioRol { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<RecupContra> RecupContra { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SubMenu> SubMenu { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        public virtual ObjectResult<SpAsignarPrivilegio_List_Result> SpAsignarPrivilegio_List(Nullable<int> opc, Nullable<int> dNI)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("Opc", opc) :
                new ObjectParameter("Opc", typeof(int));
    
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpAsignarPrivilegio_List_Result>("SpAsignarPrivilegio_List", opcParameter, dNIParameter);
        }
    
        public virtual ObjectResult<SpPrivilegioMenu_List_Result> SpPrivilegioMenu_List(Nullable<int> opc, Nullable<int> dNI, string idModulo)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("Opc", opc) :
                new ObjectParameter("Opc", typeof(int));
    
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            var idModuloParameter = idModulo != null ?
                new ObjectParameter("IdModulo", idModulo) :
                new ObjectParameter("IdModulo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpPrivilegioMenu_List_Result>("SpPrivilegioMenu_List", opcParameter, dNIParameter, idModuloParameter);
        }
    
        public virtual ObjectResult<SpPrivilegioModulo_List_Result> SpPrivilegioModulo_List(Nullable<int> opc, Nullable<int> dNI)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("Opc", opc) :
                new ObjectParameter("Opc", typeof(int));
    
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpPrivilegioModulo_List_Result>("SpPrivilegioModulo_List", opcParameter, dNIParameter);
        }
    
        public virtual ObjectResult<SpPrivilegioSubMenu_List_Result> SpPrivilegioSubMenu_List(Nullable<int> opc, Nullable<int> dNI, string idModulo, string idMenu)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("Opc", opc) :
                new ObjectParameter("Opc", typeof(int));
    
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            var idModuloParameter = idModulo != null ?
                new ObjectParameter("IdModulo", idModulo) :
                new ObjectParameter("IdModulo", typeof(string));
    
            var idMenuParameter = idMenu != null ?
                new ObjectParameter("IdMenu", idMenu) :
                new ObjectParameter("IdMenu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpPrivilegioSubMenu_List_Result>("SpPrivilegioSubMenu_List", opcParameter, dNIParameter, idModuloParameter, idMenuParameter);
        }
    
        public virtual int SpRecupContra_Delete(Nullable<int> dNI)
        {
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpRecupContra_Delete", dNIParameter);
        }
    
        public virtual int SpRecupContra_Insert(Nullable<int> dNI, string email, string token)
        {
            var dNIParameter = dNI.HasValue ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpRecupContra_Insert", dNIParameter, emailParameter, tokenParameter);
        }
    
        public virtual int SpUsuario_Insert(string usu, string pass, string dNI)
        {
            var usuParameter = usu != null ?
                new ObjectParameter("Usu", usu) :
                new ObjectParameter("Usu", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpUsuario_Insert", usuParameter, passParameter, dNIParameter);
        }
    
        public virtual ObjectResult<SpUsuario_List_Result> SpUsuario_List(Nullable<int> opc, string usuario, string pass)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("Opc", opc) :
                new ObjectParameter("Opc", typeof(int));
    
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpUsuario_List_Result>("SpUsuario_List", opcParameter, usuarioParameter, passParameter);
        }
    
        public virtual int SpUsuario_Update(string usu, string pass, string dNI)
        {
            var usuParameter = usu != null ?
                new ObjectParameter("Usu", usu) :
                new ObjectParameter("Usu", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            var dNIParameter = dNI != null ?
                new ObjectParameter("DNI", dNI) :
                new ObjectParameter("DNI", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpUsuario_Update", usuParameter, passParameter, dNIParameter);
        }
    }
}