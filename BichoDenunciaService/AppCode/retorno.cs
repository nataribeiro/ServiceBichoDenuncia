//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BichoDenunciaService.AppCode
{
    using System;
    using System.Collections.Generic;
    
    public partial class retorno
    {
        public int id { get; set; }
        public Nullable<int> id_denuncia { get; set; }
        public string entidade { get; set; }
        public string descricao { get; set; }
        public Nullable<System.DateTime> data { get; set; }
    
        public virtual denuncia denuncia { get; set; }
    }
}
