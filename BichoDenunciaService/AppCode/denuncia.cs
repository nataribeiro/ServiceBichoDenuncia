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
    
    public partial class denuncia
    {
        public denuncia()
        {
            this.hashtag = new HashSet<hashtag>();
            this.midia = new HashSet<midia>();
            this.retorno = new HashSet<retorno>();
        }
    
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string situacao { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public string categoria_animal { get; set; }
        public string tipo_animal { get; set; }
        public string endereco { get; set; }
        public Nullable<double> endereco_latitude { get; set; }
        public Nullable<double> endereco_longitude { get; set; }
        public string denunciante_email { get; set; }
        public string denunciante_telefone { get; set; }
    
        public virtual ICollection<hashtag> hashtag { get; set; }
        public virtual ICollection<midia> midia { get; set; }
        public virtual ICollection<retorno> retorno { get; set; }
    }
}
